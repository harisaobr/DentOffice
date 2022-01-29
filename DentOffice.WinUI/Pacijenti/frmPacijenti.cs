using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI.Pacijenti
{
    public partial class frmPacijenti : Form
    {
        APIService _korisniciService = new APIService("Korisnik");
        public frmPacijenti()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await UcitajPacijente();
        }

        private async Task UcitajPacijente()
        {
            var search = new KorisnikSearchRequest()
            {
                Ime = txtPretragaIme.Text,
                Prezime = txtPretragaPrezime.Text

            };
            var result = await _korisniciService.GetAll<List<Model.KorisnikPacijent>>(search, "KorisnikPacijenti");
            dgvPacijenti.AutoGenerateColumns = false;

            dgvPacijenti.DataSource = result;
            if (dgvPacijenti.RowCount > 0)
            {
                dgvPacijenti.Columns[6].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private void btnDodajNovog_Click(object sender, EventArgs e)
        {
            frmPAcijentiDetalji frm = new frmPAcijentiDetalji();
            frm.Show();
        }

        private async void frmPacijenti_Load(object sender, EventArgs e)
        {
            await UcitajPacijente();
        }

        private async void dgvPacijenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPacijenti.SelectedRows[0].DataBoundItem as Model.KorisnikPacijent;
            if(row != null)
            {
                var frm = new frmPAcijentiDetalji(row.KorisnikID);
                frm.ShowDialog();

                await UcitajPacijente();
            }
        }
    }
}
