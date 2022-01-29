
namespace DentOffice.WinUI.Korisnik
{
    partial class frmKorisnici
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
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.KorisničkoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JMBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObavljenoPregleda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // Korisnici
            // 
            this.Korisnici.Controls.Add(this.dgvKorisnici);
            this.Korisnici.Location = new System.Drawing.Point(12, 127);
            this.Korisnici.Name = "Korisnici";
            this.Korisnici.Size = new System.Drawing.Size(1311, 311);
            this.Korisnici.TabIndex = 0;
            this.Korisnici.TabStop = false;
            this.Korisnici.Text = "Korisnici";
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.AllowUserToAddRows = false;
            this.dgvKorisnici.AllowUserToDeleteRows = false;
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisničkoIme,
            this.Ime,
            this.Prezime,
            this.Email,
            this.JMBG,
            this.Grad,
            this.Spol,
            this.ObavljenoPregleda});
            this.dgvKorisnici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKorisnici.Location = new System.Drawing.Point(3, 18);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.ReadOnly = true;
            this.dgvKorisnici.RowHeadersWidth = 51;
            this.dgvKorisnici.RowTemplate.Height = 24;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(1305, 290);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellContentClick);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(36, 46);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(436, 22);
            this.txtPretraga.TabIndex = 2;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // KorisničkoIme
            // 
            this.KorisničkoIme.DataPropertyName = "KorisnickoIme";
            this.KorisničkoIme.HeaderText = "Korisničko ime";
            this.KorisničkoIme.MinimumWidth = 6;
            this.KorisničkoIme.Name = "KorisničkoIme";
            this.KorisničkoIme.ReadOnly = true;
            this.KorisničkoIme.Width = 145;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            this.Ime.Width = 80;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.MinimumWidth = 6;
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            this.Prezime.Width = 80;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // JMBG
            // 
            this.JMBG.DataPropertyName = "JMBG";
            this.JMBG.HeaderText = "JMBG";
            this.JMBG.MinimumWidth = 6;
            this.JMBG.Name = "JMBG";
            this.JMBG.ReadOnly = true;
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.MinimumWidth = 6;
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            this.Grad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "Spol";
            this.Spol.HeaderText = "Spol";
            this.Spol.MinimumWidth = 6;
            this.Spol.Name = "Spol";
            this.Spol.ReadOnly = true;
            this.Spol.Width = 55;
            // 
            // ObavljenoPregleda
            // 
            this.ObavljenoPregleda.DataPropertyName = "ObavljenoPregleda";
            this.ObavljenoPregleda.HeaderText = "Obavljeno pregleda";
            this.ObavljenoPregleda.MinimumWidth = 6;
            this.ObavljenoPregleda.Name = "ObavljenoPregleda";
            this.ObavljenoPregleda.ReadOnly = true;
            this.ObavljenoPregleda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ObavljenoPregleda.Width = 125;
            // 
            // frmKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 450);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.Korisnici);
            this.Name = "frmKorisnici";
            this.Text = "Lista korisnika";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKorisnici_Load);
            this.Korisnici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Korisnici;
        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisničkoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn JMBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObavljenoPregleda;
    }
}