namespace MesseClient
{
    partial class Gutschein
    {
        // VOM DESIGNER ERFORDERLICHE VARIABLE
        private System.ComponentModel.IContainer components = null;

        // Deklaration der Label-Variablen — DIES BEHEBT DIE CS0103 FEHLER!
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblUsername;

        /// <summary> 
        /// Gibt alle verwendeten Ressourcen frei.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// </summary>
        private void InitializeComponent()
        {
            // Initialisierung der Label-Objekte und Platzierung
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitel.Location = new System.Drawing.Point(20, 30);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(200, 21);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Platzhalter für Gutschein-Text";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.Location = new System.Drawing.Point(50, 75);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(150, 32);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "CODE_XXXX";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gutschein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitel);
            this.Name = "Gutschein"; // WICHTIG: Name des Formulars
            this.Text = "Gutschein";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}