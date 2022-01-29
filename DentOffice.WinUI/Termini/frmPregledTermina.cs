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
        }

        private async void frmPregledTermina_Load(object sender, EventArgs e)
        {
            //var sviTermini = await _serviceTermin.GetAll<List<Model.Termin>>(null);

            //dgvTermini.AutoGenerateColumns = false;
            //dgvTermini.DataSource = sviTermini;
            //if (dgvTermini.RowCount > 0)
            //{
            //    dgvTermini.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            //}
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

        private async void btnUcitajTermine_Click(object sender, EventArgs e)
        {
            await UcitajTermine();
        }
    }
}
