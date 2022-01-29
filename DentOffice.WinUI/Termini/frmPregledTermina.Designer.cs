
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
            this.IsOdobren = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNaCekanju = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.IsOdobren,
            this.IsNaCekanju});
            this.dgvTermini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTermini.Location = new System.Drawing.Point(4, 19);
            this.dgvTermini.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTermini.Name = "dgvTermini";
            this.dgvTermini.ReadOnly = true;
            this.dgvTermini.RowHeadersWidth = 51;
            this.dgvTermini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTermini.Size = new System.Drawing.Size(1156, 557);
            this.dgvTermini.TabIndex = 0;
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
            this.Hitan.DataPropertyName = "Hitan";
            this.Hitan.HeaderText = "Hitan";
            this.Hitan.MinimumWidth = 6;
            this.Hitan.Name = "Hitan";
            this.Hitan.ReadOnly = true;
            this.Hitan.Width = 70;
            // 
            // IsOdobren
            // 
            this.IsOdobren.DataPropertyName = "IsOdobren";
            this.IsOdobren.HeaderText = "Odobren";
            this.IsOdobren.MinimumWidth = 6;
            this.IsOdobren.Name = "IsOdobren";
            this.IsOdobren.ReadOnly = true;
            this.IsOdobren.Width = 70;
            // 
            // IsNaCekanju
            // 
            this.IsNaCekanju.DataPropertyName = "IsNaCekanju";
            this.IsNaCekanju.HeaderText = "Na čekanju";
            this.IsNaCekanju.MinimumWidth = 6;
            this.IsNaCekanju.Name = "IsNaCekanju";
            this.IsNaCekanju.ReadOnly = true;
            this.IsNaCekanju.Width = 70;
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
            // frmPregledTermina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 734);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pacijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn UslugaNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razlog;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hitan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOdobren;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNaCekanju;
        private System.Windows.Forms.Label label1;
    }
}