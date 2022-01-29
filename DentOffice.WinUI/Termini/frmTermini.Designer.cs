
namespace DentOffice.WinUI.Termini
{
    partial class frmTermini
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
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsluga = new System.Windows.Forms.ComboBox();
            this.cbHitno = new System.Windows.Forms.CheckBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtRazlog
            // 
            this.txtRazlog.Location = new System.Drawing.Point(27, 201);
            this.txtRazlog.Name = "txtRazlog";
            this.txtRazlog.Size = new System.Drawing.Size(547, 22);
            this.txtRazlog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pacijent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Odaberite uslugu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Razlog temina";
            // 
            // cmbUsluga
            // 
            this.cmbUsluga.FormattingEnabled = true;
            this.cmbUsluga.Location = new System.Drawing.Point(27, 125);
            this.cmbUsluga.Name = "cmbUsluga";
            this.cmbUsluga.Size = new System.Drawing.Size(547, 24);
            this.cmbUsluga.TabIndex = 8;
            // 
            // cbHitno
            // 
            this.cbHitno.AutoSize = true;
            this.cbHitno.Location = new System.Drawing.Point(105, 315);
            this.cbHitno.Name = "cbHitno";
            this.cbHitno.Size = new System.Drawing.Size(71, 21);
            this.cbHitno.TabIndex = 9;
            this.cbHitno.Text = "Hitno?";
            this.cbHitno.UseVisualStyleBackColor = true;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(27, 252);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(547, 22);
            this.dtpDatum.TabIndex = 10;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(499, 313);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 11;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(27, 53);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(546, 24);
            this.cmbPacijent.TabIndex = 12;
            // 
            // frmTermini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.cmbPacijent);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cbHitno);
            this.Controls.Add(this.cmbUsluga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazlog);
            this.Name = "frmTermini";
            this.Load += new System.EventHandler(this.frmTermini_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRazlog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsluga;
        private System.Windows.Forms.CheckBox cbHitno;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.ComboBox cmbPacijent;
    }
}