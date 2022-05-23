
namespace DentOffice.WinUI.Termini
{
    partial class frmPregledTermina
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTermini = new System.Windows.Forms.DataGridView();
            this.TerminId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pacijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UslugaNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Razlog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hitan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Odobren = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NaCekanju = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOdobri = new System.Windows.Forms.Button();
            this.btnOdbij = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTermini);
            this.groupBox1.Location = new System.Drawing.Point(23, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1164, 580);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Termini";
            // 
            // dgvTermini
            // 
            this.dgvTermini.AllowUserToAddRows = false;
            this.dgvTermini.AllowUserToDeleteRows = false;
            this.dgvTermini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTermini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminId,
            this.Pacijent,
            this.UslugaNaziv,
            this.Razlog,
            this.DatumVrijeme,
            this.Hitan,
            this.Odobren,
            this.NaCekanju});
            this.dgvTermini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTermini.Location = new System.Drawing.Point(4, 19);
            this.dgvTermini.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTermini.MultiSelect = false;
            this.dgvTermini.Name = "dgvTermini";
            this.dgvTermini.ReadOnly = true;
            this.dgvTermini.RowHeadersWidth = 51;
            this.dgvTermini.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTermini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTermini.Size = new System.Drawing.Size(1156, 557);
            this.dgvTermini.TabIndex = 0;
            this.dgvTermini.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTermini_CellContentDoubleClick);
            // 
            // TerminId
            // 
            this.TerminId.DataPropertyName = "TerminId";
            this.TerminId.HeaderText = "TerminId";
            this.TerminId.MinimumWidth = 6;
            this.TerminId.Name = "TerminId";
            this.TerminId.ReadOnly = true;
            this.TerminId.Visible = false;
            this.TerminId.Width = 125;
            // 
            // Pacijent
            // 
            this.Pacijent.DataPropertyName = "Pacijent";
            this.Pacijent.HeaderText = "Pacijent";
            this.Pacijent.MinimumWidth = 6;
            this.Pacijent.Name = "Pacijent";
            this.Pacijent.ReadOnly = true;
            this.Pacijent.Width = 150;
            // 
            // UslugaNaziv
            // 
            this.UslugaNaziv.DataPropertyName = "UslugaNaziv";
            this.UslugaNaziv.HeaderText = "Usluga";
            this.UslugaNaziv.MinimumWidth = 6;
            this.UslugaNaziv.Name = "UslugaNaziv";
            this.UslugaNaziv.ReadOnly = true;
            this.UslugaNaziv.Width = 150;
            // 
            // Razlog
            // 
            this.Razlog.DataPropertyName = "Razlog";
            this.Razlog.HeaderText = "Razlog";
            this.Razlog.MinimumWidth = 6;
            this.Razlog.Name = "Razlog";
            this.Razlog.ReadOnly = true;
            this.Razlog.Width = 150;
            // 
            // DatumVrijeme
            // 
            this.DatumVrijeme.DataPropertyName = "DatumVrijeme";
            this.DatumVrijeme.HeaderText = "DatumVrijeme";
            this.DatumVrijeme.MinimumWidth = 6;
            this.DatumVrijeme.Name = "DatumVrijeme";
            this.DatumVrijeme.ReadOnly = true;
            this.DatumVrijeme.Width = 120;
            // 
            // Hitan
            // 
            this.Hitan.DataPropertyName = "Hitno";
            this.Hitan.HeaderText = "Hitan";
            this.Hitan.MinimumWidth = 6;
            this.Hitan.Name = "Hitan";
            this.Hitan.ReadOnly = true;
            this.Hitan.Width = 70;
            // 
            // Odobren
            // 
            this.Odobren.DataPropertyName = "Odobreno";
            this.Odobren.HeaderText = "Odobren";
            this.Odobren.MinimumWidth = 6;
            this.Odobren.Name = "Odobren";
            this.Odobren.ReadOnly = true;
            this.Odobren.Width = 70;
            // 
            // NaCekanju
            // 
            this.NaCekanju.DataPropertyName = "NaCekanju";
            this.NaCekanju.HeaderText = "Na čekanju";
            this.NaCekanju.MinimumWidth = 6;
            this.NaCekanju.Name = "NaCekanju";
            this.NaCekanju.ReadOnly = true;
            this.NaCekanju.Width = 70;
            // 
            // txtRazlog
            // 
            this.txtRazlog.Location = new System.Drawing.Point(27, 32);
            this.txtRazlog.Name = "txtRazlog";
            this.txtRazlog.Size = new System.Drawing.Size(383, 22);
            this.txtRazlog.TabIndex = 27;
            this.txtRazlog.TextChanged += new System.EventHandler(this.txtRazlog_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Razlog:";
            // 
            // btnOdobri
            // 
            this.btnOdobri.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOdobri.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOdobri.Location = new System.Drawing.Point(893, 26);
            this.btnOdobri.Name = "btnOdobri";
            this.btnOdobri.Size = new System.Drawing.Size(116, 35);
            this.btnOdobri.TabIndex = 29;
            this.btnOdobri.Text = "Odobri";
            this.btnOdobri.UseVisualStyleBackColor = false;
            this.btnOdobri.Click += new System.EventHandler(this.btnOdobri_Click);
            // 
            // btnOdbij
            // 
            this.btnOdbij.BackColor = System.Drawing.Color.Red;
            this.btnOdbij.Location = new System.Drawing.Point(1043, 26);
            this.btnOdbij.Name = "btnOdbij";
            this.btnOdbij.Size = new System.Drawing.Size(116, 35);
            this.btnOdbij.TabIndex = 30;
            this.btnOdbij.Text = "Odbij";
            this.btnOdbij.UseVisualStyleBackColor = false;
            this.btnOdbij.Click += new System.EventHandler(this.btnOdbij_Click);
            // 
            // frmPregledTermina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 734);
            this.Controls.Add(this.btnOdbij);
            this.Controls.Add(this.btnOdobri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazlog);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPregledTermina";
            this.Text = "Lista termina";
            this.Load += new System.EventHandler(this.frmPregledTermina_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermini)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTermini;
        private System.Windows.Forms.TextBox txtRazlog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pacijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn UslugaNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razlog;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hitan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Odobren;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NaCekanju;
        private System.Windows.Forms.Button btnOdobri;
        private System.Windows.Forms.Button btnOdbij;
    }
}