
namespace DentOffice.WinUI.Termini
{
    partial class frmPregledi
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPregledi = new System.Windows.Forms.DataGridView();
            this.Stomatolog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumTermina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrajanjePregleda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lijek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dijagnoza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Napomena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPregledi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Pacijent:";
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(25, 32);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(261, 24);
            this.cmbPacijent.TabIndex = 27;
            this.cmbPacijent.SelectedIndexChanged += new System.EventHandler(this.cmbPacijent_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPregledi);
            this.groupBox1.Location = new System.Drawing.Point(22, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1095, 580);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pregledi";
            // 
            // dgvPregledi
            // 
            this.dgvPregledi.AllowUserToAddRows = false;
            this.dgvPregledi.AllowUserToDeleteRows = false;
            this.dgvPregledi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPregledi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stomatolog,
            this.DatumTermina,
            this.TrajanjePregleda,
            this.Lijek,
            this.Dijagnoza,
            this.Napomena});
            this.dgvPregledi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPregledi.Location = new System.Drawing.Point(4, 19);
            this.dgvPregledi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPregledi.Name = "dgvPregledi";
            this.dgvPregledi.ReadOnly = true;
            this.dgvPregledi.RowHeadersWidth = 51;
            this.dgvPregledi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPregledi.Size = new System.Drawing.Size(1087, 557);
            this.dgvPregledi.TabIndex = 0;
            // 
            // Stomatolog
            // 
            this.Stomatolog.DataPropertyName = "Korisnik";
            this.Stomatolog.HeaderText = "Stomatolog";
            this.Stomatolog.MinimumWidth = 6;
            this.Stomatolog.Name = "Stomatolog";
            this.Stomatolog.ReadOnly = true;
            this.Stomatolog.Width = 125;
            // 
            // DatumTermina
            // 
            this.DatumTermina.DataPropertyName = "DatumTermina";
            this.DatumTermina.HeaderText = "Datum termina";
            this.DatumTermina.MinimumWidth = 6;
            this.DatumTermina.Name = "DatumTermina";
            this.DatumTermina.ReadOnly = true;
            this.DatumTermina.Width = 125;
            // 
            // TrajanjePregleda
            // 
            this.TrajanjePregleda.DataPropertyName = "TrajanjePregleda";
            this.TrajanjePregleda.HeaderText = "Trajanje pregleda";
            this.TrajanjePregleda.MinimumWidth = 6;
            this.TrajanjePregleda.Name = "TrajanjePregleda";
            this.TrajanjePregleda.ReadOnly = true;
            this.TrajanjePregleda.Width = 125;
            // 
            // Lijek
            // 
            this.Lijek.DataPropertyName = "Lijek";
            this.Lijek.HeaderText = "Lijek";
            this.Lijek.MinimumWidth = 6;
            this.Lijek.Name = "Lijek";
            this.Lijek.ReadOnly = true;
            this.Lijek.Width = 125;
            // 
            // Dijagnoza
            // 
            this.Dijagnoza.DataPropertyName = "Dijagnoza";
            this.Dijagnoza.HeaderText = "Dijagnoza";
            this.Dijagnoza.MinimumWidth = 6;
            this.Dijagnoza.Name = "Dijagnoza";
            this.Dijagnoza.ReadOnly = true;
            this.Dijagnoza.Width = 125;
            // 
            // Napomena
            // 
            this.Napomena.DataPropertyName = "Napomena";
            this.Napomena.HeaderText = "Napomena";
            this.Napomena.MinimumWidth = 6;
            this.Napomena.Name = "Napomena";
            this.Napomena.ReadOnly = true;
            this.Napomena.Width = 125;
            // 
            // frmPregledi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 734);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPacijent);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPregledi";
            this.Text = "Lista pregleda";
            this.Load += new System.EventHandler(this.frmPregledTermina_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPregledi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPregledi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stomatolog;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumTermina;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrajanjePregleda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lijek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dijagnoza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Napomena;
    }
}