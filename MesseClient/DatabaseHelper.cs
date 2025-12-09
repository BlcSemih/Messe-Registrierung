using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace MesseClient
{
    /// <summary>
    /// Verwaltet die lokale SQLite-Datenbank für Offline-Speicherung
    /// </summary>
    public class DatabaseHelper
    {
        private static readonly string DB_PATH = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MesseClient",
            "messe_local.db"
        );

        private static readonly string CONNECTION_STRING = $"Data Source={DB_PATH};Version=3;";

        /// <summary>
        /// Initialisiert die Datenbank (erstellt Tabellen wenn nicht vorhanden)
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                // Verzeichnis erstellen falls nicht vorhanden
                string directory = Path.GetDirectoryName(DB_PATH);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Datenbank erstellen falls nicht vorhanden
                if (!File.Exists(DB_PATH))
                {
                    SQLiteConnection.CreateFile(DB_PATH);
                }

                // Tabellen erstellen
                using (var connection = new SQLiteConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Registrations (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Vorname TEXT NOT NULL,
                            Nachname TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            Telefon TEXT,
                            Strasse TEXT NOT NULL,
                            PLZ TEXT NOT NULL,
                            Stadt TEXT NOT NULL,
                            Firma TEXT,
                            Username TEXT,
                            CreatedAt TEXT NOT NULL,
                            IsSynced INTEGER DEFAULT 0,
                            CategoryIds TEXT
                        )";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Initialisieren der Datenbank: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Speichert eine Registrierung lokal
        /// </summary>
        public static int SaveRegistration(Registration registration)
        {
            try
            {
                using (var connection = new SQLiteConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string insertQuery = @"
                        INSERT INTO Registrations 
                        (Vorname, Nachname, Email, Telefon, Strasse, PLZ, Stadt, Firma, Username, CreatedAt, IsSynced, CategoryIds)
                        VALUES 
                        (@Vorname, @Nachname, @Email, @Telefon, @Strasse, @PLZ, @Stadt, @Firma, @Username, @CreatedAt, @IsSynced, @CategoryIds)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Vorname", registration.Vorname);
                        command.Parameters.AddWithValue("@Nachname", registration.Nachname);
                        command.Parameters.AddWithValue("@Email", registration.Email);
                        command.Parameters.AddWithValue("@Telefon", registration.Telefon ?? "");
                        command.Parameters.AddWithValue("@Strasse", registration.Strasse);
                        command.Parameters.AddWithValue("@PLZ", registration.PLZ);
                        command.Parameters.AddWithValue("@Stadt", registration.Stadt);
                        command.Parameters.AddWithValue("@Firma", registration.Firma ?? "");
                        command.Parameters.AddWithValue("@Username", registration.Username ?? "");
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@IsSynced", 0);
                        command.Parameters.AddWithValue("@CategoryIds", string.Join(",", registration.CategoryIds ?? new List<int>()));

                        command.ExecuteNonQuery();

                        // Letzte eingefügte ID zurückgeben
                        command.CommandText = "SELECT last_insert_rowid()";
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Speichern der Registrierung: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Markiert eine Registrierung als synchronisiert
        /// </summary>
        public static void MarkAsSynced(int id, string username)
        {
            try
            {
                using (var connection = new SQLiteConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Registrations SET IsSynced = 1, Username = @Username WHERE Id = @Id";

                    using (var command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Username", username);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Aktualisieren des Sync-Status: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gibt alle nicht synchronisierten Registrierungen zurück
        /// </summary>
        public static List<Registration> GetUnsyncedRegistrations()
        {
            var registrations = new List<Registration>();

            try
            {
                using (var connection = new SQLiteConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Registrations WHERE IsSynced = 0";

                    using (var command = new SQLiteCommand(selectQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var registration = new Registration
                            {
                                Vorname = reader["Vorname"].ToString(),
                                Nachname = reader["Nachname"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Strasse = reader["Strasse"].ToString(),
                                PLZ = reader["PLZ"].ToString(),
                                Stadt = reader["Stadt"].ToString(),
                                Firma = reader["Firma"].ToString(),
                                Username = reader["Username"].ToString()
                            };

                            // CategoryIds parsen
                            string categoryIdsStr = reader["CategoryIds"].ToString();
                            if (!string.IsNullOrEmpty(categoryIdsStr))
                            {
                                registration.CategoryIds = new List<int>();
                                foreach (string id in categoryIdsStr.Split(','))
                                {
                                    if (int.TryParse(id, out int categoryId))
                                    {
                                        registration.CategoryIds.Add(categoryId);
                                    }
                                }
                            }

                            registrations.Add(registration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Abrufen nicht synchronisierter Registrierungen: {ex.Message}", ex);
            }

            return registrations;
        }
    }
}