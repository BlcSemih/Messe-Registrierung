using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MesseClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnRegistrieren_Click(object sender, EventArgs e)
        {
            // Eingabe-Validierung
            if (string.IsNullOrWhiteSpace(tbVorname.Text))
            {
                MessageBox.Show("Bitte geben Sie einen Vornamen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbVorname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNachname.Text))
            {
                MessageBox.Show("Bitte geben Sie einen Nachnamen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNachname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Bitte geben Sie eine E-Mail-Adresse ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbStrasse.Text))
            {
                MessageBox.Show("Bitte geben Sie eine Straße ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStrasse.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPLZ.Text))
            {
                MessageBox.Show("Bitte geben Sie eine PLZ ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPLZ.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbStadt.Text))
            {
                MessageBox.Show("Bitte geben Sie eine Stadt ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStadt.Focus();
                return;
            }

            // Button deaktivieren während der Anfrage
            btnRegistrieren.Enabled = false;
            tbErgebnis.Text = "Registrierung wird verarbeitet...";
            tbErgebnis.BackColor = System.Drawing.Color.LightYellow;

            try
            {
                // Produktinteressen sammeln
                List<int> categoryIds = new List<int>();
                if (cbSoftware.Checked) categoryIds.Add(1);
                if (cbHardware.Checked) categoryIds.Add(2);
                if (cbCloud.Checked) categoryIds.Add(3);
                if (cbBeratung.Checked) categoryIds.Add(4);
                if (cbSicherheit.Checked) categoryIds.Add(5);

                // Registrierung erstellen
                var registration = new Registration
                {
                    Vorname = tbVorname.Text.Trim(),
                    Nachname = tbNachname.Text.Trim(),
                    Email = tbEmail.Text.Trim(),
                    Telefon = tbTelefon.Text.Trim(),
                    Strasse = tbStrasse.Text.Trim(),
                    PLZ = tbPLZ.Text.Trim(),
                    Stadt = tbStadt.Text.Trim(),
                    Firma = tbFirma.Text.Trim(),
                    CategoryIds = categoryIds
                };

                // API-Aufruf
                var result = await NetworkHelper.RegisterUser(registration);

                if (result != null && result.Success)
                {
                    // Erfolgsfall: GUTSCHEIN-ANFORDERUNG ERFÜLLEN
                    
                    // 1. Gutschein-Formular (Gutschein.cs) öffnen und Benutzernamen übergeben
                    Gutschein gutschein = new Gutschein(result.Username); 
                    gutschein.Show(); 
                    
                    // 2. Das Registrierungsformular ausblenden
                    this.Hide(); 

                    // Die Status-Updates und das Zurücksetzen des Formulars sind nicht mehr notwendig, 
                    // da die Ansicht gewechselt wird.

                }
                else
                {
                    // Fehler
                    tbErgebnis.BackColor = System.Drawing.Color.LightCoral;
                    tbErgebnis.Text = $"✗ Registrierung fehlgeschlagen.\n\n{result?.Message ?? "Unbekannter Fehler"}";
                }
            }
            catch (Exception ex)
            {
                // Netzwerkfehler oder API nicht erreichbar
                tbErgebnis.BackColor = System.Drawing.Color.LightCoral;
                tbErgebnis.Text = $"✗ Fehler bei der Registrierung.\n\nBitte prüfen Sie Ihre Internetverbindung.\n\nDetails: {ex.Message}";
            }
            finally
            {
                // Button wieder aktivieren (im Fehlerfall)
                btnRegistrieren.Enabled = true;
            }
        }

        /// <summary>
        /// Setzt das Formular zurück
        /// </summary>
        private void ClearForm()
        {
            tbVorname.Clear();
            tbNachname.Clear();
            tbEmail.Clear();
            tbTelefon.Clear();
            tbStrasse.Clear();
            tbPLZ.Clear();
            tbStadt.Clear();
            tbFirma.Clear();

            cbSoftware.Checked = false;
            cbHardware.Checked = false;
            cbCloud.Checked = false;
            cbBeratung.Checked = false;
            cbSicherheit.Checked = false;

            tbVorname.Focus();
        }
    }

    /// <summary>
    /// Hilfsklasse für API-Antworten (muss den Username enthalten)
    /// </summary>
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
    }
}