using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI.Izvjestaj
{
    public partial class frmIzvjestaj : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private readonly APIService _serviceIzvjestaj = new APIService("Izvjestaj");

        public frmIzvjestaj()
        {
            InitializeComponent();
        }

        private async void frmIzvjestaj_Load(object sender, EventArgs e)
        {
            await LoadStomatologe();
            await UcitajReport();
        }

        private async Task UcitajReport()
        {
            if (cmbStomatolog.SelectedItem is null)
                return;

            var stomatologId = (cmbStomatolog.SelectedItem as Model.Korisnik).KorisnikID;

            var brojPacijenata = await _serviceIzvjestaj.GetById<int>(stomatologId, "GetBrojPacijenata");
            var usluge = await _serviceIzvjestaj.GetById<List<Model.IzvjestajUsluge>>(stomatologId, "GetUsluge");

            var datatable = new dsIzvjestaj.dtIzvjestajDataTable();
            foreach (var item in usluge)
            {
                var row = datatable.NewdtIzvjestajRow();
                row.NazivUsluge = item.NazivUsluge;
                row.BrojIzvršenihUsluga = item.BrojIzvrsenihUsluga;
                datatable.AdddtIzvjestajRow(row);
            }

            var rds = new ReportDataSource
            {
                Name = "Usluge",
                Value = datatable
            };
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("BrojPacijenata", brojPacijenata.ToString()));

            this.reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }

        private async void cmbStomatolog_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UcitajReport();
        }
        private async Task LoadStomatologe()
        {
            var request = new Model.Requests.KorisnikSearchRequest
            {
                ShowStomatologe = true
            };
            var result = await _serviceKorisnici.GetAll<List<Model.Korisnik>>(request);
            cmbStomatolog.DataSource = result;
        }
    }
}
