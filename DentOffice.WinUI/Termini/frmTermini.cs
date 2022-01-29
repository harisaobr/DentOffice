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
    public partial class frmTermini : Form
    {
        private readonly APIService _serviceTermin = new APIService("Termin");
        private readonly APIService _serviceUsluga = new APIService("Usluga");
        private readonly APIService _korisniciService = new APIService("Korisnik");
        private int? _id = null;

        public frmTermini()
        {
            InitializeComponent();
            if (_id.HasValue)
                Text = "Uređivanje termina";
            else
                Text = "Dodavanje termina";
        }

        private async Task LoadUsluge()
        {
            var result = await _serviceUsluga.GetAll<List<Model.Usluga>>(null);
            cmbUsluga.DataSource = result;
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "UslugaId";
        }
        private async Task LoadPacijente()
        {
            var result = await _korisniciService.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DataSource = result;
            cmbPacijent.DisplayMember = "Ime";
            cmbPacijent.ValueMember = "PacijentID";
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var request = new Model.Requests.TerminInsertRequest()
            {
                DatumVrijeme = dtpDatum.Value,
                Razlog = txtRazlog.Text,
                Hitan = cbHitno.Checked
            };

            if (cmbPacijent.SelectedValue != null)
                request.PacijentId = int.Parse(cmbPacijent.SelectedValue.ToString());
            if (cmbUsluga.SelectedValue != null)
                request.UslugaId = int.Parse(cmbUsluga.SelectedValue.ToString());

            Model.Termin entity = null;

            if (!_id.HasValue)
            {
                entity = await _serviceTermin.Insert<Model.Termin>(request);
            }
            else
            {
                entity = await _serviceTermin.Update<Model.Termin>(_id.Value, request);
            }

            if (entity != null)
            {
                MessageBox.Show("Uspješno izvršeno");
                Close();
            }

        }

        private async void frmTermini_Load(object sender, EventArgs e)
        {
            await LoadPacijente();
            await LoadUsluge();
        }
    }
}
