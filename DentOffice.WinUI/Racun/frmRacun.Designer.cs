
namespace DentOffice.WinUI.Racun
{
    partial class frmRacun
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.cmbMetodaPlacanja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatumUplate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Iznos = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDatumIzdavanjaRacuna = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(28, 56);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(498, 24);
            this.cmbPacijent.TabIndex = 77;
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Location = new System.Drawing.Point(27, 29);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(58, 17);
            this.lblKorisnik.TabIndex = 76;
            this.lblKorisnik.Text = "Korisnik";
            // 
            // cmbMetodaPlacanja
            // 
            this.cmbMetodaPlacanja.FormattingEnabled = true;
            this.cmbMetodaPlacanja.Location = new System.Drawing.Point(28, 121);
            this.cmbMetodaPlacanja.Name = "cmbMetodaPlacanja";
            this.cmbMetodaPlacanja.Size = new System.Drawing.Size(498, 24);
            this.cmbMetodaPlacanja.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 78;
            this.label1.Text = "Metoda plaćanja";
            // 
            // dtpDatumUplate
            // 
            this.dtpDatumUplate.Location = new System.Drawing.Point(28, 184);
            this.dtpDatumUplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDatumUplate.Name = "dtpDatumUplate";
            this.dtpDatumUplate.Size = new System.Drawing.Size(498, 22);
            this.dtpDatumUplate.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "Datum uplate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 84;
            this.label3.Text = "KM";
            // 
            // Iznos
            // 
            this.Iznos.AutoSize = true;
            this.Iznos.Location = new System.Drawing.Point(31, 226);
            this.Iznos.Name = "Iznos";
            this.Iznos.Size = new System.Drawing.Size(41, 17);
            this.Iznos.TabIndex = 83;
            this.Iznos.Text = "Iznos";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(30, 247);
            this.txtIme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(75, 22);
            this.txtIme.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "Datum izdavanja računa";
            // 
            // lblDatumIzdavanjaRacuna
            // 
            this.lblDatumIzdavanjaRacuna.AutoSize = true;
            this.lblDatumIzdavanjaRacuna.Location = new System.Drawing.Point(47, 322);
            this.lblDatumIzdavanjaRacuna.Name = "lblDatumIzdavanjaRacuna";
            this.lblDatumIzdavanjaRacuna.Size = new System.Drawing.Size(46, 17);
            this.lblDatumIzdavanjaRacuna.TabIndex = 86;
            this.lblDatumIzdavanjaRacuna.Text = "label4";
            // 
            // frmRacun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDatumIzdavanjaRacuna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.dtpDatumUplate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbMetodaPlacanja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPacijent);
            this.Controls.Add(this.lblKorisnik);
            this.Name = "frmRacun";
            this.Text = "frmRacun";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.ComboBox cmbMetodaPlacanja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDatumUplate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Iznos;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDatumIzdavanjaRacuna;
    }
}