
namespace DentOffice.WinUI
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaPacijenataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviPacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviPregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledTerminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajTerminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.racuniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.pacijentiToolStripMenuItem,
            this.pregledToolStripMenuItem,
            this.terminiToolStripMenuItem,
            this.racunToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(843, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // pacijentiToolStripMenuItem
            // 
            this.pacijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaPacijenataToolStripMenuItem,
            this.noviPacijentToolStripMenuItem});
            this.pacijentiToolStripMenuItem.Name = "pacijentiToolStripMenuItem";
            this.pacijentiToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.pacijentiToolStripMenuItem.Text = "Pacijenti";
            // 
            // pretragaPacijenataToolStripMenuItem
            // 
            this.pretragaPacijenataToolStripMenuItem.Name = "pretragaPacijenataToolStripMenuItem";
            this.pretragaPacijenataToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.pretragaPacijenataToolStripMenuItem.Text = "Pretraga pacijenata";
            this.pretragaPacijenataToolStripMenuItem.Click += new System.EventHandler(this.pretragaPacijenataToolStripMenuItem_Click);
            // 
            // noviPacijentToolStripMenuItem
            // 
            this.noviPacijentToolStripMenuItem.Name = "noviPacijentToolStripMenuItem";
            this.noviPacijentToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.noviPacijentToolStripMenuItem.Text = "Novi pacijent";
            this.noviPacijentToolStripMenuItem.Click += new System.EventHandler(this.noviPacijentToolStripMenuItem_Click);
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviPregledToolStripMenuItem});
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.pregledToolStripMenuItem.Text = "Pregled";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaPregledaToolStripMenuItem_Click);
            // 
            // noviPregledToolStripMenuItem
            // 
            this.noviPregledToolStripMenuItem.Name = "noviPregledToolStripMenuItem";
            this.noviPregledToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.noviPregledToolStripMenuItem.Text = "Novi pregled";
            this.noviPregledToolStripMenuItem.Click += new System.EventHandler(this.noviPregledToolStripMenuItem_Click);
            // 
            // terminiToolStripMenuItem
            // 
            this.terminiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledTerminaToolStripMenuItem,
            this.dodajTerminToolStripMenuItem});
            this.terminiToolStripMenuItem.Name = "terminiToolStripMenuItem";
            this.terminiToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.terminiToolStripMenuItem.Text = "Termini";
            // 
            // pregledTerminaToolStripMenuItem
            // 
            this.pregledTerminaToolStripMenuItem.Name = "pregledTerminaToolStripMenuItem";
            this.pregledTerminaToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.pregledTerminaToolStripMenuItem.Text = "Pregled termina";
            this.pregledTerminaToolStripMenuItem.Click += new System.EventHandler(this.pregledTerminaToolStripMenuItem_Click);
            // 
            // dodajTerminToolStripMenuItem
            // 
            this.dodajTerminToolStripMenuItem.Name = "dodajTerminToolStripMenuItem";
            this.dodajTerminToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.dodajTerminToolStripMenuItem.Text = "Dodaj termin";
            this.dodajTerminToolStripMenuItem.Click += new System.EventHandler(this.dodajTerminToolStripMenuItem_Click);
            // 
            // racunToolStripMenuItem
            // 
            this.racunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.racuniToolStripMenuItem});
            this.racunToolStripMenuItem.Name = "racunToolStripMenuItem";
            this.racunToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.racunToolStripMenuItem.Text = "Racun";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // racuniToolStripMenuItem
            // 
            this.racuniToolStripMenuItem.Name = "racuniToolStripMenuItem";
            this.racuniToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.racuniToolStripMenuItem.Text = "Racuni";
            this.racuniToolStripMenuItem.Click += new System.EventHandler(this.racuniToolStripMenuItem_Click);
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaPacijenataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviPacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledTerminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dodajTerminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviPregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racuniToolStripMenuItem;
    }
}



