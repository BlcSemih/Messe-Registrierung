using MesseAPI; // <-- DER KORREKTE IMPORT FÜR REGISTRATION UND PRODUCTCATEGORY
using Microsoft.AspNetCore.Mvc;
using System; // Hinzugefügt, da im Code verwendet
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace MesseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MesseController : ControllerBase
    {
        private readonly string _connectionString;

        public MesseController()
        {
            string projectPath = Directory.GetCurrentDirectory();
            string dbPath = Path.Combine(projectPath, "messe_data.db");
            _connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                
                string createRegistrations = @"
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
                        Username TEXT NOT NULL UNIQUE,
                        CreatedAt TEXT NOT NULL,
                        IsSynced INTEGER DEFAULT 0
                    )";

                string createProductCategories = @"
                    CREATE TABLE IF NOT EXISTS ProductCategories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE
                    )";

                string createRegistrationInterests = @"
                    CREATE TABLE IF NOT EXISTS RegistrationInterests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RegistrationId INTEGER NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        FOREIGN KEY (RegistrationId) REFERENCES Registrations(Id) ON DELETE CASCADE,
                        FOREIGN KEY (CategoryId) REFERENCES ProductCategories(Id),
                        UNIQUE(RegistrationId, CategoryId)
                    )";

                using (var command = new SQLiteCommand(createRegistrations, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createProductCategories, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createRegistrationInterests, connection))
                {
                    command.ExecuteNonQuery();
                }

                InsertProductCategories(connection);
            }
        }

        private void InsertProductCategories(SQLiteConnection connection)
        {
            string checkQuery = "SELECT COUNT(*) FROM ProductCategories";
            using (var cmd = new SQLiteCommand(checkQuery, connection))
            {
                long count = (long)cmd.ExecuteScalar();
                if (count > 0) return;
            }

            string[] categories = { "Software", "Hardware", "Cloud-Lösungen", "IT-Beratung", "Sicherheit" };

            foreach (var category in categories)
            {
                string insertSql = "INSERT INTO ProductCategories (Name) VALUES (@name)";
                using (var cmd = new SQLiteCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@name", category);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegistrationDto dto)
        {
            // DEBUG: Log what we received
            if (dto == null)
            {
                return BadRequest(new { success = false, message = "Keine Daten empfangen (dto ist null)" });
            }

            // Minimale Validierung
            if (string.IsNullOrWhiteSpace(dto.vorname) || string.IsNullOrWhiteSpace(dto.nachname))
            {
                return BadRequest(new { success = false, message = "Vorname und Nachname sind erforderlich" });
            }

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Username generieren
                    string baseUsername = $"{dto.vorname.ToLower()}.{dto.nachname.ToLower()}";
                    string username = baseUsername;
                    int counter = 1;

                    while (UsernameExists(connection, username))
                    {
                        username = $"{baseUsername}{counter}";
                        counter++;
                    }

                    // Defaults setzen
                    string email = string.IsNullOrWhiteSpace(dto.email) ? "keine@email.de" : dto.email;
                    string strasse = string.IsNullOrWhiteSpace(dto.strasse) ? "Unbekannt" : dto.strasse;
                    string plz = string.IsNullOrWhiteSpace(dto.plz) ? "00000" : dto.plz;
                    string stadt = string.IsNullOrWhiteSpace(dto.stadt) ? "Unbekannt" : dto.stadt;

                    // In DB speichern
                    string insertQuery = @"
                        INSERT INTO Registrations 
                        (Vorname, Nachname, Email, Telefon, Strasse, PLZ, Stadt, Firma, Username, CreatedAt, IsSynced)
                        VALUES 
                        (@vorname, @nachname, @email, @telefon, @strasse, @plz, @stadt, @firma, @username, @createdAt, 0)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@vorname", dto.vorname);
                        command.Parameters.AddWithValue("@nachname", dto.nachname);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@telefon", dto.telefon ?? "");
                        command.Parameters.AddWithValue("@strasse", strasse);
                        command.Parameters.AddWithValue("@plz", plz);
                        command.Parameters.AddWithValue("@stadt", stadt);
                        command.Parameters.AddWithValue("@firma", dto.firma ?? "");
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.ExecuteNonQuery();
                    }

                    long registrationId = GetLastInsertId(connection);

                    // Produktinteressen
                    if (dto.categoryIds != null && dto.categoryIds.Count > 0)
                    {
                        foreach (var categoryId in dto.categoryIds)
                        {
                            string insertInterest = "INSERT INTO RegistrationInterests (RegistrationId, CategoryId) VALUES (@regId, @catId)";
                            using (var cmd = new SQLiteCommand(insertInterest, connection))
                            {
                                cmd.Parameters.AddWithValue("@regId", registrationId);
                                cmd.Parameters.AddWithValue("@catId", categoryId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    return Ok(new
                    {
                        success = true,
                        username = username,
                        id = (int)registrationId,
                        message = "Registrierung erfolgreich"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Fehler: {ex.Message}" });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var registrations = new List<Registration>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT r.*, GROUP_CONCAT(pc.Name, ', ') as Interests
                        FROM Registrations r
                        LEFT JOIN RegistrationInterests ri ON r.Id = ri.RegistrationId
                        LEFT JOIN ProductCategories pc ON ri.CategoryId = pc.Id
                        GROUP BY r.Id
                        ORDER BY r.CreatedAt DESC";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            registrations.Add(new Registration
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Vorname = reader["Vorname"].ToString(),
                                Nachname = reader["Nachname"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Strasse = reader["Strasse"].ToString(),
                                PLZ = reader["PLZ"].ToString(),
                                Stadt = reader["Stadt"].ToString(),
                                Firma = reader["Firma"].ToString(),
                                Username = reader["Username"].ToString(),
                                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()),
                                IsSynced = Convert.ToInt32(reader["IsSynced"]) == 1,
                                InterestsText = reader["Interests"]?.ToString()
                            });
                        }
                    }
                }
                return Ok(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler: {ex.Message}");
            }
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categories = new List<ProductCategory>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM ProductCategories ORDER BY Name";
                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new ProductCategory
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest("Suchbegriff fehlt");

            var registrations = new List<Registration>();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Registrations WHERE Vorname LIKE @term OR Nachname LIKE @term OR Email LIKE @term ORDER BY CreatedAt DESC";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@term", $"%{term}%");
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                registrations.Add(new Registration
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Vorname = reader["Vorname"].ToString(),
                                    Nachname = reader["Nachname"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString())
                                });
                            }
                        }
                    }
                }
                return Ok(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fehler: {ex.Message}");
            }
        }

        private bool UsernameExists(SQLiteConnection connection, string username)
        {
            string query = "SELECT COUNT(*) FROM Registrations WHERE Username = @username";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private long GetLastInsertId(SQLiteConnection connection)
        {
            string query = "SELECT last_insert_rowid()";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                return (long)cmd.ExecuteScalar();
            }
        }
    }

    // DTO mit lowercase properties für JSON binding - Bleibt in dieser Datei
    public class RegistrationDto
    {
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string strasse { get; set; }
        public string plz { get; set; }
        public string stadt { get; set; }
        public string firma { get; set; }
        public List<int> categoryIds { get; set; }
    }
}