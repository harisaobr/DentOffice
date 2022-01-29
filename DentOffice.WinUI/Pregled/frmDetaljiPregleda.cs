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

namespace DentOffice.WinUI.Pregled
{
    public partial class frmDetaljiPregleda : Form
    {
        private readonly APIService _serviceLijek = new APIService("Lijek");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceUsluga = new APIService("Usluga");
        private readonly APIService _serviceTermin = new APIService("Termin");


        private int? _id = null;
        public frmDetaljiPregleda(int? pregledId = null)
        {
            InitializeComponent();
            _id = pregledId;
            if (_id.HasValue)
                Text = "Uređivanje pregleda";
            else
                Text = "Dodavanje pregleda";
        }

        private async void frmDetaljiPregleda_Load(object sender, EventArgs e)
        {
            await LoadPacijent();
            await LoadUsluge();
            await LoadDijagnoze();
            await LoadLijekovi();

        }
        private async Task LoadLijekovi()
        {
            var result = await _serviceLijek.GetAll<List<Model.Lijek>>(null);

            cmbLijek.DisplayMember = "Naziv";
            cmbLijek.ValueMember = "LijekId";
            cmbLijek.DataSource = result;
        }

        private async Task LoadDijagnoze()
        {
            var result = await _serviceDijagnoza.GetAll<List<Model.Dijagnoza>>(null);

            cmbDijagnoza.DataSource = result;
            cmbDijagnoza.DisplayMember = "Naziv";
            cmbDijagnoza.ValueMember = "DijagnozaId";
        }

        private async Task LoadPacijent()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DisplayMember = "Ime";
            cmbPacijent.ValueMember = "PacijentID";
            cmbPacijent.DataSource = result;
        }

        private async Task LoadUsluge()
        {
            var result = await _serviceUsluga.GetAll<List<Model.Usluga>>(null);
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "UslugaID";
            cmbUsluga.DataSource = result;
        }

        private async Task LoadTermine()
        {
            cmbTermin.Text = "";

            if (cmbPacijent.SelectedValue == null || cmbUsluga.SelectedValue == null)
                return;

            var request = new TerminSearchRequest
            {
                PacijentId = int.Parse(cmbPacijent.SelectedValue.ToString()),
                UslugaId = int.Parse(cmbUsluga.SelectedValue.ToString())
            };

            var result = await _serviceTermin.GetAll<List<Model.Termin>>(request);
            result = result.OrderByDescending(x => x.DatumVrijeme).ToList();

            cmbTermin.DataSource = result;
            cmbTermin.DisplayMember = "Opis";
            cmbTermin.ValueMember = "TerminID";
        }

        private PregledUpsertRequest Request = new PregledUpsertRequest();

        private async void btnSnimiPregled_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                int.TryParse(cmbDijagnoza.SelectedValue.ToString(), out int convertDijagnoza);
                int.TryParse(cmbLijek.SelectedValue.ToString(), out int convertLijek);
                int.TryParse(cmbTermin.SelectedValue.ToString(), out int convertTermin);
                int.TryParse(txtTrajanje.Text, out int convertTrajanje);

                Request.DijagnozaId = convertDijagnoza;
                Request.LijekId = convertLijek;
                Request.TerminId = convertTermin;
                Request.TrajanjePregleda = convertTrajanje;
                Request.Napomena = txtNapomenaPregleda.Text;

                try
                {
                    Model.Pregled entity = null;
                    if (_id.HasValue)
                        entity = await _servicePregled.Update<Model.Pregled>(_id, Request);
                    else
                        entity = await _servicePregled.Insert<Model.Pregled>(Request);

                    if (entity != null)
                        MessageBox.Show("Uspješno ste " + (_id.HasValue ? "uredili" : "dodali") + " pregled!");

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Operacija neuspjela! " + exception.Message);
                }

            }
        }

        private async void cmbPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadTermine();
        }

        private async void cmbUsluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadTermine();
        }

        private void cmbPacijent_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbUsluga_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbTermin_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbDijagnoza_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbLijek_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }
    }

}
