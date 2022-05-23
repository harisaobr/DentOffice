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

namespace DentOffice.WinUI.Racun
{
    public partial class frmRacuni : Form
    {
        private readonly APIService _apiService = new APIService("Racun");
        public frmRacuni()
        {
            InitializeComponent();
            dgvRacuni.AutoGenerateColumns = false;
            dtpOd.Value = DateTime.Now.AddDays(-10);
        }

        private async Task UcitajRacune()
        {
            var search = new RacunSearchRequest()
            {
                ImePrezime = txtPretraga.Text,
                DatumOd = dtpOd.Value,
                DatumDo = dtpDo.Value
            };
            var result = await _apiService.GetAll<List<Model.Racun>>(search);

            dgvRacuni.DataSource = result;
        }

        private async void dgvRacuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (dgvRacuni.SelectedRows[0].DataBoundItem as Model.Racun).RacunId;

            frmRacunDetalji frm = new frmRacunDetalji(id);
            frm.ShowDialog();

            await UcitajRacune();
        }

        private async void frmRacuni_Load(object sender, EventArgs e)
        {
            await UcitajRacune();
        }

        private async void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            await UcitajRacune();
        }

        private async void dtpOd_ValueChanged(object sender, EventArgs e)
        {
            await UcitajRacune();
        }

        private async void dtpDo_ValueChanged(object sender, EventArgs e)
        {
            await UcitajRacune();
        }
    }
}
