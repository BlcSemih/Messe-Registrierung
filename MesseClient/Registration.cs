using System;
using System.Collections.Generic;

namespace MesseClient
{
    /// <summary>
    /// Model für eine Messe-Registrierung (Client-Seite)
    /// </summary>
    public class Registration
    {
        public int Id { get; set; }
        
        // Persönliche Daten
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        
        // Adresse
        public string Strasse { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        
        // Optional: Firma
        public string Firma { get; set; }
        
        // System-Felder
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSynced { get; set; }
        
        // Produktinteressen
        public List<int> CategoryIds { get; set; }
        public string InterestsText { get; set; }
    }
}