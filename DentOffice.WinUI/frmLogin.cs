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
            {

                var listUloge = new List<string>
                {
                    "Medicinsko Osoblje",
                    "Administrator",
                    "Stomatolog"
                };
      
                if (!listUloge.Contains(APIService.LogiraniKorisnik.Uloga.Naziv))
                {
                    APIService.Username = null;
                    APIService.Password = null;
                    APIService.LogiraniKorisnik = null;
                    MessageBox.Show("Prijava je omogućena samo osoblju", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
