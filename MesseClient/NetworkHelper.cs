using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MesseClient
{
    internal class NetworkHelper
    {
        private static readonly string BASE_URL = "https://localhost:7159/";

        /// <summary>
        /// Registriert einen neuen Benutzer über die API
        /// </summary>
        public static async Task<ApiResponse> RegisterUser(Registration registration)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // SSL-Zertifikatsprüfung ignorieren (nur für Entwicklung!)
                    var handler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                    };

                    using (var clientWithHandler = new HttpClient(handler))
                    {
                        clientWithHandler.BaseAddress = new Uri(BASE_URL);
                        clientWithHandler.DefaultRequestHeaders.Accept.Clear();
                        clientWithHandler.DefaultRequestHeaders.Accept.Add(
                            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        // Timeout setzen
                        clientWithHandler.Timeout = TimeSpan.FromSeconds(10);

                        // JSON erstellen
                        string jsonPayload = JsonConvert.SerializeObject(registration);
                        var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                        // POST-Request senden
                        HttpResponseMessage response = await clientWithHandler.PostAsync("Messe", httpContent);

                        if (response.IsSuccessStatusCode)
                        {
                            // Erfolgreiche Antwort
                            string responseContent = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                            return result;
                        }
                        else
                        {
                            // Fehler-Antwort
                            string errorContent = await response.Content.ReadAsStringAsync();
                            return new ApiResponse
                            {
                                Success = false,
                                Message = $"Serverfehler: {response.StatusCode}\n{errorContent}"
                            };
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Netzwerkfehler
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Verbindungsfehler: API nicht erreichbar.\n\nStellen Sie sicher, dass die MesseAPI läuft.\n\nDetails: {ex.Message}"
                };
            }
            catch (TaskCanceledException)
            {
                // Timeout
                return new ApiResponse
                {
                    Success = false,
                    Message = "Zeitüberschreitung: Die API antwortet nicht."
                };
            }
            catch (Exception ex)
            {
                // Sonstige Fehler
                return new ApiResponse
                {
                    Success = false,
                    Message = $"Fehler: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Alte Methode - kann gelöscht werden, aber für Kompatibilität beibehalten
        /// </summary>
        [Obsolete("Verwenden Sie RegisterUser() stattdessen")]
        public static async Task<InfoItem> CheckWebapi(string vorname, string nachname)
        {
            InfoItem result = null;
            InfoItem transfer = new InfoItem
            {
                Vorname = vorname,
                Nachname = nachname,
                Confirmed = false,
                Username = "-",
                RequestTime = DateTime.Now
            };

            string payload = JsonConvert.SerializeObject(transfer);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();

                var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("Messe", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    string antwort = await response.Content.ReadAsStringAsync();
                    InfoItem buffer = JsonConvert.DeserializeObject<InfoItem>(antwort);
                    if (buffer.Confirmed)
                    {
                        result = buffer;
                    }
                }
            }

            return result;
        }
    }
}