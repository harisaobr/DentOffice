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

namespace DentOffice.WinUI.Pregled
{
    public partial class frmPregledi : Form
    {
        private readonly APIService _servicePregledi = new APIService("Pregled");
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private int pacijentID;

        public frmPregledi()
        {
            InitializeComponent();
            dgvPregledi.AutoGenerateColumns = false;
        }

        public frmPregledi(int pacijentID): this()
        {
            this.pacijentID = pacijentID;
        }

        private async void frmPregledTermina_Load(object sender, EventArgs e)
        {
            await UcitajPacijente();
            if(pacijentID != 0)
            {
                cmbPacijent.SelectedValue = pacijentID;
            }
        }

        private async Task UcitajPacijente()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DisplayMember = "ImePrezime";
            cmbPacijent.ValueMember = "PacijentID";
            cmbPacijent.DataSource = result;
        }

        private async Task UcitajPreglede()
        {
            var search = new PregledSearchRequest()
            {
                PacijentId = int.Parse(cmbPacijent.SelectedValue.ToString())
            };
            var result = await _servicePregledi.GetAll<List<Model.Pregled>>(search);

            dgvPregledi.DataSource = result;
            if (dgvPregledi.RowCount > 0)
            {
                dgvPregledi.Columns[1].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private async void cmbPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UcitajPreglede();
        }

        private async void dgvPregledi_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (dgvPregledi.SelectedRows[0].DataBoundItem as Model.Pregled).PregledID;

            Form frm = new frmDetaljiPregleda(id);
            frm.ShowDialog();

            await UcitajPreglede();
        }
    }
}
