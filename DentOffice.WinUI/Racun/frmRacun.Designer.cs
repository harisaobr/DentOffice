
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
            this.dtpDatumUplate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Iznos = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlaceno = new System.Windows.Forms.CheckBox();
            this.cmbPregled = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(28, 56);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(397, 24);
            this.cmbPacijent.TabIndex = 77;
            this.cmbPacijent.SelectedIndexChanged += new System.EventHandler(this.cmbPacijent_SelectedIndexChanged);
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
            // dtpDatumUplate
            // 
            this.dtpDatumUplate.Location = new System.Drawing.Point(24, 196);
            this.dtpDatumUplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDatumUplate.Name = "dtpDatumUplate";
            this.dtpDatumUplate.Size = new System.Drawing.Size(397, 22);
            this.dtpDatumUplate.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 80;
            this.label7.Text = "Datum uplate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 84;
            this.label3.Text = "KM";
            // 
            // Iznos
            // 
            this.Iznos.AutoSize = true;
            this.Iznos.Location = new System.Drawing.Point(27, 238);
            this.Iznos.Name = "Iznos";
            this.Iznos.Size = new System.Drawing.Size(41, 17);
            this.Iznos.TabIndex = 83;
            this.Iznos.Text = "Iznos";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(26, 259);
            this.txtIznos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(75, 22);
            this.txtIznos.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 85;
            this.label2.Text = "Status";
            // 
            // cbPlaceno
            // 
            this.cbPlaceno.AutoSize = true;
            this.cbPlaceno.Location = new System.Drawing.Point(32, 337);
            this.cbPlaceno.Name = "cbPlaceno";
            this.cbPlaceno.Size = new System.Drawing.Size(81, 21);
            this.cbPlaceno.TabIndex = 86;
            this.cbPlaceno.Text = "Placeno";
            this.cbPlaceno.UseVisualStyleBackColor = true;
            // 
            // cmbPregled
            // 
            this.cmbPregled.FormattingEnabled = true;
            this.cmbPregled.Location = new System.Drawing.Point(26, 126);
            this.cmbPregled.Name = "cmbPregled";
            this.cmbPregled.Size = new System.Drawing.Size(397, 24);
            this.cmbPregled.TabIndex = 88;
            this.cmbPregled.SelectedIndexChanged += new System.EventHandler(this.cmbPregled_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 87;
            this.label4.Text = "Pregled";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(287, 325);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(124, 33);
            this.btnPotvrdi.TabIndex = 89;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // frmRacun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 390);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.cmbPregled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPlaceno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.dtpDatumUplate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPacijent);
            this.Controls.Add(this.lblKorisnik);
            this.Name = "frmRacun";
            this.Text = "frmRacun";
            this.Load += new System.EventHandler(this.frmRacun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.Label lblKorisnik;
        private System.Windows.Forms.DateTimePicker dtpDatumUplate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Iznos;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbPlaceno;
        private System.Windows.Forms.ComboBox cmbPregled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPotvrdi;
    }
}