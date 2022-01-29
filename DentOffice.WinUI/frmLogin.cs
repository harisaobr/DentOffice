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
    public partial class frmLogin : Form
    {
        private readonly APIService _serviceKorisnik = new APIService("Korisnik");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;

            APIService.LogiraniKorisnik = await _serviceKorisnik.GetAll<Model.Korisnik>(null, "Profil");

            this.UseWaitCursor = false;

            if (APIService.LogiraniKorisnik != null)
                DialogResult = DialogResult.OK;
        }
    }
}
