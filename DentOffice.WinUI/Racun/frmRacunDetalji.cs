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

namespace DentOffice.WinUI.Racun
{
    public partial class frmRacunDetalji : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceRacun = new APIService("Racun");
        private int? _id;

        public frmRacunDetalji()
        {
            InitializeComponent();
        }
        public frmRacunDetalji(int RacunId): this()
        {
            _id = RacunId;
        }
        private async Task LoadPacijent()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DisplayMember = "ImePrezime";
            cmbPacijent.ValueMember = "KorisnikID";

            result.Insert(0, new Model.KorisnikPacijent { Ime = "Odaberite", Prezime = "pacijenta" });
            cmbPacijent.DataSource = result;
        }

        private async Task LoadPregled()
        {
            if (cmbPacijent.SelectedItem is Model.KorisnikPacijent pacijent)
            {
                var request = new Model.Requests.PregledSearchRequest
                {
                    PacijentId = pacijent.PacijentID
                };
                var result = await _servicePregled.GetAll<List<Model.Pregled>>(request);
                cmbPregled.DisplayMember = "UslugaDatum";
                cmbPregled.ValueMember = "PregledID";
                cmbPregled.DataSource = result;
                if (result.Count == 0)
                {
                    cmbPregled.Text = "";
                    txtIznos.Text = "";
                }
            }
        }

        private async void cmbPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadPregled();
        }

        private async void frmRacun_Load(object sender, EventArgs e)
        {

            if (_id.HasValue)
            {
                cmbPacijent.SelectedIndexChanged -= cmbPacijent_SelectedIndexChanged;
                cmbPregled.SelectedIndexChanged -= cmbPregled_SelectedIndexChanged;

                await LoadPacijent();

                var racun = await _serviceRacun.GetById<Model.Racun>(_id.Value);
                if(racun.DatumIzdavanjaRacuna != null)
                    dtpDatumUplate.Value = racun.DatumIzdavanjaRacuna.Value;
                cbPlaceno.Checked = racun.IsPlaceno ?? false;

                cmbPacijent.SelectedValue = racun.KorisnikId;
                await LoadPregled();

                cmbPregled.SelectedValue = racun.PregledId;
                txtIznos.Text = racun.UkupnaCijenaFormatted;

                cmbPregled.SelectedIndexChanged += cmbPregled_SelectedIndexChanged;
                cmbPacijent.SelectedIndexChanged += cmbPacijent_SelectedIndexChanged;
            }
            else
            {
                await LoadPacijent();
            }


        }

        private void cmbPregled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPregled.SelectedItem is Model.Pregled pregled)
            {
                txtIznos.Text = pregled.Termin.Usluga.Cijena.ToString("0.00");
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var Request = new Model.Requests.RacunInsertRequest
                {
                    KorisnikId = int.Parse(cmbPacijent.SelectedValue.ToString()),
                    PregledId = int.Parse(cmbPregled.SelectedValue.ToString()),
                    IsPlaceno = cbPlaceno.Checked,
                    DatumIzdavanjaRacuna = dtpDatumUplate.Value,
                    UkupnaCijena = double.Parse(txtIznos.Text),
                };

                try
                {
                    Model.Racun entity = null;
                    if (_id.HasValue)
                        entity = await _serviceRacun.Update<Model.Racun>(_id, Request);
                    else
                        entity = await _serviceRacun.Insert<Model.Racun>(Request);

                    if (entity != null)
                    {
                        MessageBox.Show("Uspješno ste " + (_id.HasValue ? "uredili" : "dodali") + " račun!");
                        Close();
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Operacija neuspjela! " + exception.Message);
                }

            }

        }

        private void cmbPacijent_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void cmbPregled_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            err.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }

    }
}
