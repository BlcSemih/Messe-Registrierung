using System;
using System.Windows.Forms;

namespace MesseClient
{
    // Die Klasse muss 'partial' sein und von Form erben
    public partial class Gutschein : Form
    {
        // Standardkonstruktor für den Designer
        public Gutschein()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Konstruktor, der den Benutzernamen empfängt.
        /// </summary>
        public Gutschein(string username)
        {
            InitializeComponent();
            
            this.Text = "Ihr Gutschein-Code";
            
            // Logik: Labels mit Daten befüllen
            lblTitel.Text = "Vielen Dank! Zeigen Sie diesen Code am Stand vor:";
            lblUsername.Text = username;
        }
    }
}