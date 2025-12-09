namespace MesseClient
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
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
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxPersonal = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVorname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNachname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.groupBoxAdresse = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStrasse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPLZ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStadt = new System.Windows.Forms.TextBox();
            this.groupBoxFirma = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFirma = new System.Windows.Forms.TextBox();
            this.groupBoxInteressen = new System.Windows.Forms.GroupBox();
            this.cbSoftware = new System.Windows.Forms.CheckBox();
            this.cbHardware = new System.Windows.Forms.CheckBox();
            this.cbCloud = new System.Windows.Forms.CheckBox();
            this.cbBeratung = new System.Windows.Forms.CheckBox();
            this.cbSicherheit = new System.Windows.Forms.CheckBox();
            this.btnRegistrieren = new System.Windows.Forms.Button();
            this.tbErgebnis = new System.Windows.Forms.TextBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.groupBoxPersonal.SuspendLayout();
            this.groupBoxAdresse.SuspendLayout();
            this.groupBoxFirma.SuspendLayout();
            this.groupBoxInteressen.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPersonal
            // 
            this.groupBoxPersonal.Controls.Add(this.label1);
            this.groupBoxPersonal.Controls.Add(this.tbVorname);
            this.groupBoxPersonal.Controls.Add(this.label2);
            this.groupBoxPersonal.Controls.Add(this.tbNachname);
            this.groupBoxPersonal.Controls.Add(this.label3);
            this.groupBoxPersonal.Controls.Add(this.tbEmail);
            this.groupBoxPersonal.Controls.Add(this.label4);
            this.groupBoxPersonal.Controls.Add(this.tbTelefon);
            this.groupBoxPersonal.Location = new System.Drawing.Point(20, 60);
            this.groupBoxPersonal.Name = "groupBoxPersonal";
            this.groupBoxPersonal.Size = new System.Drawing.Size(380, 180);
            this.groupBoxPersonal.TabIndex = 0;
            this.groupBoxPersonal.TabStop = false;
            this.groupBoxPersonal.Text = "Persönliche Daten";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vorname *";
            // 
            // tbVorname
            // 
            this.tbVorname.Location = new System.Drawing.Point(140, 27);
            this.tbVorname.Name = "tbVorname";
            this.tbVorname.Size = new System.Drawing.Size(220, 26);
            this.tbVorname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nachname *";
            // 
            // tbNachname
            // 
            this.tbNachname.Location = new System.Drawing.Point(140, 62);
            this.tbNachname.Name = "tbNachname";
            this.tbNachname.Size = new System.Drawing.Size(220, 26);
            this.tbNachname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "E-Mail *";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(140, 97);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(220, 26);
            this.tbEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefon";
            // 
            // tbTelefon
            // 
            this.tbTelefon.Location = new System.Drawing.Point(140, 132);
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(220, 26);
            this.tbTelefon.TabIndex = 7;
            // 
            // groupBoxAdresse
            // 
            this.groupBoxAdresse.Controls.Add(this.label5);
            this.groupBoxAdresse.Controls.Add(this.tbStrasse);
            this.groupBoxAdresse.Controls.Add(this.label6);
            this.groupBoxAdresse.Controls.Add(this.tbPLZ);
            this.groupBoxAdresse.Controls.Add(this.label7);
            this.groupBoxAdresse.Controls.Add(this.tbStadt);
            this.groupBoxAdresse.Location = new System.Drawing.Point(420, 60);
            this.groupBoxAdresse.Name = "groupBoxAdresse";
            this.groupBoxAdresse.Size = new System.Drawing.Size(380, 145);
            this.groupBoxAdresse.TabIndex = 1;
            this.groupBoxAdresse.TabStop = false;
            this.groupBoxAdresse.Text = "Adresse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Straße *";
            // 
            // tbStrasse
            // 
            this.tbStrasse.Location = new System.Drawing.Point(100, 27);
            this.tbStrasse.Name = "tbStrasse";
            this.tbStrasse.Size = new System.Drawing.Size(260, 26);
            this.tbStrasse.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "PLZ *";
            // 
            // tbPLZ
            // 
            this.tbPLZ.Location = new System.Drawing.Point(100, 62);
            this.tbPLZ.Name = "tbPLZ";
            this.tbPLZ.Size = new System.Drawing.Size(100, 26);
            this.tbPLZ.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Stadt *";
            // 
            // tbStadt
            // 
            this.tbStadt.Location = new System.Drawing.Point(100, 97);
            this.tbStadt.Name = "tbStadt";
            this.tbStadt.Size = new System.Drawing.Size(260, 26);
            this.tbStadt.TabIndex = 5;
            // 
            // groupBoxFirma
            // 
            this.groupBoxFirma.Controls.Add(this.label8);
            this.groupBoxFirma.Controls.Add(this.tbFirma);
            this.groupBoxFirma.Location = new System.Drawing.Point(420, 220);
            this.groupBoxFirma.Name = "groupBoxFirma";
            this.groupBoxFirma.Size = new System.Drawing.Size(380, 80);
            this.groupBoxFirma.TabIndex = 2;
            this.groupBoxFirma.TabStop = false;
            this.groupBoxFirma.Text = "Firma (optional)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Firmenname";
            // 
            // tbFirma
            // 
            this.tbFirma.Location = new System.Drawing.Point(130, 32);
            this.tbFirma.Name = "tbFirma";
            this.tbFirma.Size = new System.Drawing.Size(230, 26);
            this.tbFirma.TabIndex = 1;
            // 
            // groupBoxInteressen
            // 
            this.groupBoxInteressen.Controls.Add(this.cbSoftware);
            this.groupBoxInteressen.Controls.Add(this.cbHardware);
            this.groupBoxInteressen.Controls.Add(this.cbCloud);
            this.groupBoxInteressen.Controls.Add(this.cbBeratung);
            this.groupBoxInteressen.Controls.Add(this.cbSicherheit);
            this.groupBoxInteressen.Location = new System.Drawing.Point(20, 250);
            this.groupBoxInteressen.Name = "groupBoxInteressen";
            this.groupBoxInteressen.Size = new System.Drawing.Size(380, 190);
            this.groupBoxInteressen.TabIndex = 3;
            this.groupBoxInteressen.TabStop = false;
            this.groupBoxInteressen.Text = "Produktinteressen";
            // 
            // cbSoftware
            // 
            this.cbSoftware.AutoSize = true;
            this.cbSoftware.Location = new System.Drawing.Point(25, 35);
            this.cbSoftware.Name = "cbSoftware";
            this.cbSoftware.Size = new System.Drawing.Size(88, 24);
            this.cbSoftware.TabIndex = 0;
            this.cbSoftware.Text = "Software";
            this.cbSoftware.UseVisualStyleBackColor = true;
            // 
            // cbHardware
            // 
            this.cbHardware.AutoSize = true;
            this.cbHardware.Location = new System.Drawing.Point(25, 65);
            this.cbHardware.Name = "cbHardware";
            this.cbHardware.Size = new System.Drawing.Size(92, 24);
            this.cbHardware.TabIndex = 1;
            this.cbHardware.Text = "Hardware";
            this.cbHardware.UseVisualStyleBackColor = true;
            // 
            // cbCloud
            // 
            this.cbCloud.AutoSize = true;
            this.cbCloud.Location = new System.Drawing.Point(25, 95);
            this.cbCloud.Name = "cbCloud";
            this.cbCloud.Size = new System.Drawing.Size(131, 24);
            this.cbCloud.TabIndex = 2;
            this.cbCloud.Text = "Cloud-Lösungen";
            this.cbCloud.UseVisualStyleBackColor = true;
            // 
            // cbBeratung
            // 
            this.cbBeratung.AutoSize = true;
            this.cbBeratung.Location = new System.Drawing.Point(25, 125);
            this.cbBeratung.Name = "cbBeratung";
            this.cbBeratung.Size = new System.Drawing.Size(107, 24);
            this.cbBeratung.TabIndex = 3;
            this.cbBeratung.Text = "IT-Beratung";
            this.cbBeratung.UseVisualStyleBackColor = true;
            // 
            // cbSicherheit
            // 
            this.cbSicherheit.AutoSize = true;
            this.cbSicherheit.Location = new System.Drawing.Point(25, 155);
            this.cbSicherheit.Name = "cbSicherheit";
            this.cbSicherheit.Size = new System.Drawing.Size(96, 24);
            this.cbSicherheit.TabIndex = 4;
            this.cbSicherheit.Text = "Sicherheit";
            this.cbSicherheit.UseVisualStyleBackColor = true;
            // 
            // btnRegistrieren
            // 
            this.btnRegistrieren.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRegistrieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrieren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrieren.ForeColor = System.Drawing.Color.White;
            this.btnRegistrieren.Location = new System.Drawing.Point(420, 320);
            this.btnRegistrieren.Name = "btnRegistrieren";
            this.btnRegistrieren.Size = new System.Drawing.Size(380, 50);
            this.btnRegistrieren.TabIndex = 4;
            this.btnRegistrieren.Text = "Jetzt registrieren";
            this.btnRegistrieren.UseVisualStyleBackColor = false;
            this.btnRegistrieren.Click += new System.EventHandler(this.btnRegistrieren_Click);
            // 
            // tbErgebnis
            // 
            this.tbErgebnis.BackColor = System.Drawing.Color.White;
            this.tbErgebnis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbErgebnis.Location = new System.Drawing.Point(420, 390);
            this.tbErgebnis.Multiline = true;
            this.tbErgebnis.Name = "tbErgebnis";
            this.tbErgebnis.ReadOnly = true;
            this.tbErgebnis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbErgebnis.Size = new System.Drawing.Size(380, 50);
            this.tbErgebnis.TabIndex = 5;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(240, 15);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(350, 31);
            this.lblTitel.TabIndex = 6;
            this.lblTitel.Text = "Messe-Registrierung 2025";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 460);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.tbErgebnis);
            this.Controls.Add(this.btnRegistrieren);
            this.Controls.Add(this.groupBoxInteressen);
            this.Controls.Add(this.groupBoxFirma);
            this.Controls.Add(this.groupBoxAdresse);
            this.Controls.Add(this.groupBoxPersonal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messe Registrierung - Kunde";
            this.groupBoxPersonal.ResumeLayout(false);
            this.groupBoxPersonal.PerformLayout();
            this.groupBoxAdresse.ResumeLayout(false);
            this.groupBoxAdresse.PerformLayout();
            this.groupBoxFirma.ResumeLayout(false);
            this.groupBoxFirma.PerformLayout();
            this.groupBoxInteressen.ResumeLayout(false);
            this.groupBoxInteressen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVorname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNachname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.GroupBox groupBoxAdresse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStrasse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPLZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStadt;
        private System.Windows.Forms.GroupBox groupBoxFirma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFirma;
        private System.Windows.Forms.GroupBox groupBoxInteressen;
        private System.Windows.Forms.CheckBox cbSoftware;
        private System.Windows.Forms.CheckBox cbHardware;
        private System.Windows.Forms.CheckBox cbCloud;
        private System.Windows.Forms.CheckBox cbBeratung;
        private System.Windows.Forms.CheckBox cbSicherheit;
        private System.Windows.Forms.Button btnRegistrieren;
        private System.Windows.Forms.TextBox tbErgebnis;
        private System.Windows.Forms.Label lblTitel;
    }
}