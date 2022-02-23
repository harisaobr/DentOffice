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

namespace DentOffice.WinUI.Termini
{
    public partial class frmPregledTermina : Form
    {
        private readonly APIService _serviceTermin = new APIService("Termin");
        public frmPregledTermina()
        {
            InitializeComponent();
            dgvTermini.AutoGenerateColumns = false;
        }

        private async void frmPregledTermina_Load(object sender, EventArgs e)
        {
            await UcitajTermine();
        }

        private async Task UcitajTermine()
        {
            var search = new TerminSearchRequest()
            {
                Razlog = txtRazlog.Text
            };
            var result = await _serviceTermin.GetAll<List<Model.Termin>>(search);

            dgvTermini.DataSource = result;
            if (dgvTermini.RowCount > 0)
            {
                dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private async void txtRazlog_TextChanged(object sender, EventArgs e)
        {
            await UcitajTermine();
        }

        private async void btnOdobri_Click(object sender, EventArgs e)
        {
            var row = dgvTermini.SelectedRows[0].DataBoundItem as Model.Termin;
            row.Odobreno = true;

            await UpdateOdobreno(row);
        }

        private async void btnOdbij_Click(object sender, EventArgs e)
        {
            var row = dgvTermini.SelectedRows[0].DataBoundItem as Model.Termin;
            row.Odobreno = false;

            await UpdateOdobreno(row);
        }

        private async Task UpdateOdobreno(Model.Termin row)
        {
            var request = new Model.Requests.TerminInsertRequest()
            {
                DatumVrijeme = row.DatumVrijeme,
                Razlog = row.Razlog,
                Hitno = row.Hitno ?? false,
                PacijentId = row.PacijentId,
                UslugaId = row.UslugaId,
                Odobreno = row.Odobreno
            };

            Model.Termin entity = await _serviceTermin.Update<Model.Termin>(row.TerminID, request);

            if (entity != null)
            {
                dgvTermini.InvalidateRow(dgvTermini.SelectedRows[0].Index);
                dgvTermini.Focus();
            }
        }
    }
}
