using DentOffice.WinUI.Korisnik;
using DentOffice.WinUI.Pacijenti;
using DentOffice.WinUI.Pregled;
using DentOffice.WinUI.Racun;
using DentOffice.WinUI.Termini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmKorisniciDetalji();
            frm.ShowDialog();
        }


        private void noviPacijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPacijentiDetalji();
            frm.ShowDialog();
        }

        private void pretragaPacijenataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPacijenti();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

     
        private void pretragaPregledaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPregledi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pregledTerminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPregledTermina();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void dodajTerminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTermini();

            frm.ShowDialog();
        }

        private void noviPregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetaljiPregleda();
            frm.ShowDialog();
        }

        private void racuniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRacunDetalji();
            frm.ShowDialog();
        }

        private void pregledRačunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRacuni();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
