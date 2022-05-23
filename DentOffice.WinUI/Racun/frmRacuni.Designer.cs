
namespace DentOffice.WinUI.Racun
{
    partial class frmRacuni
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
            this.Korisnici = new System.Windows.Forms.GroupBox();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pregled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UkupnaCijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIzdavanjaRacuna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPlaceno = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Korisnici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // Korisnici
            // 
            this.Korisnici.Controls.Add(this.dgvRacuni);
            this.Korisnici.Location = new System.Drawing.Point(12, 127);
            this.Korisnici.Name = "Korisnici";
            this.Korisnici.Size = new System.Drawing.Size(1311, 311);
            this.Korisnici.TabIndex = 0;
            this.Korisnici.TabStop = false;
            this.Korisnici.Text = "Korisnici";
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.AllowUserToAddRows = false;
            this.dgvRacuni.AllowUserToDeleteRows = false;
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Korisnik,
            this.Pregled,
            this.UkupnaCijena,
            this.DatumIzdavanjaRacuna,
            this.IsPlaceno});
            this.dgvRacuni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRacuni.Location = new System.Drawing.Point(3, 18);
            this.dgvRacuni.MultiSelect = false;
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.ReadOnly = true;
            this.dgvRacuni.RowHeadersWidth = 51;
            this.dgvRacuni.RowTemplate.Height = 24;
            this.dgvRacuni.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRacuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRacuni.Size = new System.Drawing.Size(1305, 290);
            this.dgvRacuni.TabIndex = 0;
            this.dgvRacuni.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellContentClick);
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.MinimumWidth = 6;
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            this.Korisnik.Width = 145;
            // 
            // Pregled
            // 
            this.Pregled.DataPropertyName = "Pregled";
            this.Pregled.HeaderText = "Pregled";
            this.Pregled.MinimumWidth = 6;
            this.Pregled.Name = "Pregled";
            this.Pregled.ReadOnly = true;
            this.Pregled.Width = 200;
            // 
            // UkupnaCijena
            // 
            this.UkupnaCijena.DataPropertyName = "UkupnaCijenaFormatted";
            this.UkupnaCijena.HeaderText = "Ukupna cijena";
            this.UkupnaCijena.MinimumWidth = 6;
            this.UkupnaCijena.Name = "UkupnaCijena";
            this.UkupnaCijena.ReadOnly = true;
            this.UkupnaCijena.Width = 150;
            // 
            // DatumIzdavanjaRacuna
            // 
            this.DatumIzdavanjaRacuna.DataPropertyName = "DatumIzdavanjaRacuna";
            this.DatumIzdavanjaRacuna.HeaderText = "Datum izdavanja racuna";
            this.DatumIzdavanjaRacuna.MinimumWidth = 6;
            this.DatumIzdavanjaRacuna.Name = "DatumIzdavanjaRacuna";
            this.DatumIzdavanjaRacuna.ReadOnly = true;
            this.DatumIzdavanjaRacuna.Width = 160;
            // 
            // IsPlaceno
            // 
            this.IsPlaceno.DataPropertyName = "IsPlaceno";
            this.IsPlaceno.HeaderText = "Plaćeno";
            this.IsPlaceno.MinimumWidth = 6;
            this.IsPlaceno.Name = "IsPlaceno";
            this.IsPlaceno.ReadOnly = true;
            this.IsPlaceno.Width = 125;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(36, 46);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(436, 22);
            this.txtPretraga.TabIndex = 2;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ime ili prezime pacijenta:";
            // 
            // dtpOd
            // 
            this.dtpOd.Location = new System.Drawing.Point(513, 45);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(245, 22);
            this.dtpOd.TabIndex = 4;
            this.dtpOd.ValueChanged += new System.EventHandler(this.dtpOd_ValueChanged);
            // 
            // dtpDo
            // 
            this.dtpDo.Location = new System.Drawing.Point(802, 46);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(245, 22);
            this.dtpDo.TabIndex = 5;
            this.dtpDo.ValueChanged += new System.EventHandler(this.dtpDo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pretraga od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(799, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pretraga do:";
            // 
            // frmRacuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.Korisnici);
            this.Name = "frmRacuni";
            this.Text = "Lista računa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRacuni_Load);
            this.Korisnici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Korisnici;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pregled;
        private System.Windows.Forms.DataGridViewTextBoxColumn UkupnaCijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIzdavanjaRacuna;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPlaceno;
    }
}