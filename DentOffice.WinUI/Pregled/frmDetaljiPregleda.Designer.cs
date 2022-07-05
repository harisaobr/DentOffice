
namespace DentOffice.WinUI.Pregled
{
    partial class frmDetaljiPregleda
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
            this.components = new System.ComponentModel.Container();
            this.btnSnimiPregled = new System.Windows.Forms.Button();
            this.txtNapomenaPregleda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTrajanje = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDijagnoza = new System.Windows.Forms.ComboBox();
            this.cmbLijek = new System.Windows.Forms.ComboBox();
            this.cmbUsluga = new System.Windows.Forms.ComboBox();
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.cmbTermin = new System.Windows.Forms.ComboBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnimiPregled
            // 
            this.btnSnimiPregled.Location = new System.Drawing.Point(185, 348);
            this.btnSnimiPregled.Name = "btnSnimiPregled";
            this.btnSnimiPregled.Size = new System.Drawing.Size(267, 55);
            this.btnSnimiPregled.TabIndex = 8;
            this.btnSnimiPregled.Text = "Snimi pregled";
            this.btnSnimiPregled.UseVisualStyleBackColor = true;
            this.btnSnimiPregled.Click += new System.EventHandler(this.btnSnimiPregled_Click);
            // 
            // txtNapomenaPregleda
            // 
            this.txtNapomenaPregleda.Location = new System.Drawing.Point(316, 232);
            this.txtNapomenaPregleda.Name = "txtNapomenaPregleda";
            this.txtNapomenaPregleda.Size = new System.Drawing.Size(241, 22);
            this.txtNapomenaPregleda.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 17);
            this.label9.TabIndex = 62;
            this.label9.Text = "Napomena pregleda";
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(62, 232);
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(233, 22);
            this.txtTrajanje.TabIndex = 6;
            this.txtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrajanje_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 17);
            this.label8.TabIndex = 60;
            this.label8.Text = "Trajanje pregleda (minute)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "Pacijent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Termin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Lijek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Dijagnoza";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Usluga";
            // 
            // cmbDijagnoza
            // 
            this.cmbDijagnoza.FormattingEnabled = true;
            this.cmbDijagnoza.Location = new System.Drawing.Point(61, 168);
            this.cmbDijagnoza.Name = "cmbDijagnoza";
            this.cmbDijagnoza.Size = new System.Drawing.Size(233, 24);
            this.cmbDijagnoza.TabIndex = 4;
            this.cmbDijagnoza.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDijagnoza_Validating);
            // 
            // cmbLijek
            // 
            this.cmbLijek.FormattingEnabled = true;
            this.cmbLijek.Location = new System.Drawing.Point(317, 168);
            this.cmbLijek.Name = "cmbLijek";
            this.cmbLijek.Size = new System.Drawing.Size(240, 24);
            this.cmbLijek.TabIndex = 5;
            this.cmbLijek.Validating += new System.ComponentModel.CancelEventHandler(this.cmbLijek_Validating);
            // 
            // cmbUsluga
            // 
            this.cmbUsluga.FormattingEnabled = true;
            this.cmbUsluga.Location = new System.Drawing.Point(60, 107);
            this.cmbUsluga.Name = "cmbUsluga";
            this.cmbUsluga.Size = new System.Drawing.Size(233, 24);
            this.cmbUsluga.TabIndex = 2;
            this.cmbUsluga.SelectedIndexChanged += new System.EventHandler(this.cmbUsluga_SelectedIndexChanged);
            this.cmbUsluga.Validating += new System.ComponentModel.CancelEventHandler(this.cmbUsluga_Validating);
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(59, 50);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(498, 24);
            this.cmbPacijent.TabIndex = 1;
            this.cmbPacijent.SelectedIndexChanged += new System.EventHandler(this.cmbPacijent_SelectedIndexChanged);
            this.cmbPacijent.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPacijent_Validating);
            // 
            // cmbTermin
            // 
            this.cmbTermin.FormattingEnabled = true;
            this.cmbTermin.Location = new System.Drawing.Point(317, 107);
            this.cmbTermin.Name = "cmbTermin";
            this.cmbTermin.Size = new System.Drawing.Size(240, 24);
            this.cmbTermin.TabIndex = 3;
            this.cmbTermin.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTermin_Validating);
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmDetaljiPregleda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.cmbTermin);
            this.Controls.Add(this.cmbPacijent);
            this.Controls.Add(this.cmbUsluga);
            this.Controls.Add(this.cmbLijek);
            this.Controls.Add(this.cmbDijagnoza);
            this.Controls.Add(this.btnSnimiPregled);
            this.Controls.Add(this.txtNapomenaPregleda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTrajanje);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDetaljiPregleda";
            this.Text = "frmDetaljiPregleda";
            this.Load += new System.EventHandler(this.frmDetaljiPregleda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSnimiPregled;
        private System.Windows.Forms.TextBox txtNapomenaPregleda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTrajanje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDijagnoza;
        private System.Windows.Forms.ComboBox cmbLijek;
        private System.Windows.Forms.ComboBox cmbUsluga;
        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.ComboBox cmbTermin;
        private System.Windows.Forms.ErrorProvider err;
    }
}