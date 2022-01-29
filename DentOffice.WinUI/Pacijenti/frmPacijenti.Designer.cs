
namespace DentOffice.WinUI.Pacijenti
{
    partial class frmPacijenti
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
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtPretragaIme = new System.Windows.Forms.TextBox();
            this.Ime = new System.Windows.Forms.Label();
            this.Prezime = new System.Windows.Forms.Label();
            this.txtPretragaPrezime = new System.Windows.Forms.TextBox();
            this.btnDodajNovog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPacijenti = new System.Windows.Forms.DataGridView();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobitel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JMBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRodjenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Proteza = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Aparatic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Terapija = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(1013, 46);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(197, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtPretragaIme
            // 
            this.txtPretragaIme.Location = new System.Drawing.Point(27, 51);
            this.txtPretragaIme.Name = "txtPretragaIme";
            this.txtPretragaIme.Size = new System.Drawing.Size(389, 22);
            this.txtPretragaIme.TabIndex = 2;
            // 
            // Ime
            // 
            this.Ime.AutoSize = true;
            this.Ime.Location = new System.Drawing.Point(24, 31);
            this.Ime.Name = "Ime";
            this.Ime.Size = new System.Drawing.Size(30, 17);
            this.Ime.TabIndex = 3;
            this.Ime.Text = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.AutoSize = true;
            this.Prezime.Location = new System.Drawing.Point(24, 93);
            this.Prezime.Name = "Prezime";
            this.Prezime.Size = new System.Drawing.Size(59, 17);
            this.Prezime.TabIndex = 5;
            this.Prezime.Text = "Prezime";
            // 
            // txtPretragaPrezime
            // 
            this.txtPretragaPrezime.Location = new System.Drawing.Point(27, 113);
            this.txtPretragaPrezime.Name = "txtPretragaPrezime";
            this.txtPretragaPrezime.Size = new System.Drawing.Size(389, 22);
            this.txtPretragaPrezime.TabIndex = 4;
            // 
            // btnDodajNovog
            // 
            this.btnDodajNovog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajNovog.Location = new System.Drawing.Point(1013, 102);
            this.btnDodajNovog.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajNovog.Name = "btnDodajNovog";
            this.btnDodajNovog.Size = new System.Drawing.Size(197, 28);
            this.btnDodajNovog.TabIndex = 33;
            this.btnDodajNovog.Text = "Dodaj novog pacijenta";
            this.btnDodajNovog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPacijenti);
            this.groupBox1.Location = new System.Drawing.Point(23, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1189, 466);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pacijenti";
            // 
            // dgvPacijenti
            // 
            this.dgvPacijenti.AllowUserToAddRows = false;
            this.dgvPacijenti.AllowUserToDeleteRows = false;
            this.dgvPacijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Email,
            this.Mobitel,
            this.JMBG,
            this.DatumRodjenja,
            this.Adresa,
            this.Spol,
            this.Status,
            this.Proteza,
            this.Aparatic,
            this.Terapija});
            this.dgvPacijenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacijenti.Location = new System.Drawing.Point(4, 19);
            this.dgvPacijenti.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPacijenti.Name = "dgvPacijenti";
            this.dgvPacijenti.ReadOnly = true;
            this.dgvPacijenti.RowHeadersWidth = 51;
            this.dgvPacijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacijenti.Size = new System.Drawing.Size(1181, 443);
            this.dgvPacijenti.TabIndex = 0;
            this.dgvPacijenti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacijenti_CellDoubleClick);
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KorisnikId";
            this.KorisnikId.HeaderText = "KorisnikId";
            this.KorisnikId.MinimumWidth = 6;
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            this.KorisnikId.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ime";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ime";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Prezime";
            this.dataGridViewTextBoxColumn2.HeaderText = "Prezime";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
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
            // Mobitel
            // 
            this.Mobitel.DataPropertyName = "BrojTelefona";
            this.Mobitel.HeaderText = "Mobitel";
            this.Mobitel.MinimumWidth = 6;
            this.Mobitel.Name = "Mobitel";
            this.Mobitel.ReadOnly = true;
            this.Mobitel.Width = 125;
            // 
            // JMBG
            // 
            this.JMBG.DataPropertyName = "JMBG";
            this.JMBG.HeaderText = "JMBG";
            this.JMBG.MinimumWidth = 6;
            this.JMBG.Name = "JMBG";
            this.JMBG.ReadOnly = true;
            this.JMBG.Width = 125;
            // 
            // DatumRodjenja
            // 
            this.DatumRodjenja.DataPropertyName = "DatumRodjenja";
            this.DatumRodjenja.HeaderText = "DatumRodjenja";
            this.DatumRodjenja.MinimumWidth = 6;
            this.DatumRodjenja.Name = "DatumRodjenja";
            this.DatumRodjenja.ReadOnly = true;
            this.DatumRodjenja.Width = 125;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.MinimumWidth = 6;
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            this.Adresa.Width = 125;
            // 
            // Spol
            // 
            this.Spol.DataPropertyName = "Spol";
            this.Spol.HeaderText = "Spol";
            this.Spol.MinimumWidth = 6;
            this.Spol.Name = "Spol";
            this.Spol.ReadOnly = true;
            this.Spol.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 80;
            // 
            // Proteza
            // 
            this.Proteza.DataPropertyName = "Proteza";
            this.Proteza.HeaderText = "Proteza";
            this.Proteza.MinimumWidth = 6;
            this.Proteza.Name = "Proteza";
            this.Proteza.ReadOnly = true;
            this.Proteza.Width = 125;
            // 
            // Aparatic
            // 
            this.Aparatic.DataPropertyName = "Aparatic";
            this.Aparatic.HeaderText = "Aparatic";
            this.Aparatic.MinimumWidth = 6;
            this.Aparatic.Name = "Aparatic";
            this.Aparatic.ReadOnly = true;
            this.Aparatic.Width = 125;
            // 
            // Terapija
            // 
            this.Terapija.DataPropertyName = "Terapija";
            this.Terapija.HeaderText = "Terapija";
            this.Terapija.MinimumWidth = 6;
            this.Terapija.Name = "Terapija";
            this.Terapija.ReadOnly = true;
            this.Terapija.Width = 125;
            // 
            // frmPacijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 743);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDodajNovog);
            this.Controls.Add(this.Prezime);
            this.Controls.Add(this.txtPretragaPrezime);
            this.Controls.Add(this.Ime);
            this.Controls.Add(this.txtPretragaIme);
            this.Controls.Add(this.btnPrikazi);
            this.Name = "frmPacijenti";
            this.Text = "frmPacijenti";
            this.Load += new System.EventHandler(this.frmPacijenti_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.TextBox txtPretragaIme;
        private System.Windows.Forms.Label Ime;
        private System.Windows.Forms.Label Prezime;
        private System.Windows.Forms.TextBox txtPretragaPrezime;
        private System.Windows.Forms.Button btnDodajNovog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPacijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobitel;
        private System.Windows.Forms.DataGridViewTextBoxColumn JMBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRodjenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Proteza;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aparatic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Terapija;
    }
}