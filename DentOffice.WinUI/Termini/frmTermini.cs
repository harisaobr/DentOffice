using DentOffice.Model.Requests;
using DentOffice.WinUI.Helper;
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

        public frmTermini(int? TerminId = null)
        {
            InitializeComponent();
            _id = TerminId;

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
            cmbPacijent.DisplayMember = "Ime";
            cmbPacijent.ValueMember = "PacijentID";

            result.Insert(0, new Model.KorisnikPacijent { Ime = "Odaberite pacijenta" });
            cmbPacijent.DataSource = result;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var request = new Model.Requests.TerminInsertRequest()
            {
                DatumVrijeme = dtpDatum.Value,
                Razlog = txtRazlog.Text,
                Hitno = cbHitno.Checked
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

            if (_id.HasValue)
            {
                var termin = await _serviceTermin.GetById<Model.Termin>(_id.Value);

                cmbPacijent.SelectedValue = termin.PacijentId;
                cmbUsluga.SelectedValue = termin.UslugaId;
                txtRazlog.Text = termin.Razlog;
                cbHitno.Checked = termin.Hitno ?? false;
                dtpDatum.Value = termin.DatumVrijeme;
            }
        }

        private void cmbPacijent_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbUsluga_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void txtRazlog_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }
    }
}
