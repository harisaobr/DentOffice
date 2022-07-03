using Flurl.Http;
using Flurl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentOffice.Model.Requests;

namespace DentOffice.WinUI.Korisnik
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _apiService = new APIService("korisnik");
        public frmKorisnici()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
            if(APIService.LogiraniKorisnik.Uloga.Naziv != "Administrator")
            {
                btnDodajNovog.Enabled = false;
            }
        }

        private async Task UcitajKorisnike()
        {
            var search = new KorisnikSearchRequest()
            {
                ImePrezime = txtPretraga.Text,
                ShowUposlenike = true
            };
            var result = await _apiService.GetAll<List<Model.Korisnik>>(search);

            dgvKorisnici.DataSource = result;
        }

        private async void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (dgvKorisnici.SelectedRows[0].DataBoundItem as Model.Korisnik).KorisnikID;

            frmKorisniciDetalji frm = new frmKorisniciDetalji(id);
            frm.ShowDialog();

            await UcitajKorisnike();
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            await UcitajKorisnike();
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            await UcitajKorisnike();
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            Form frm = new frmKorisniciDetalji();
            frm.Show();
        }
    }
}
