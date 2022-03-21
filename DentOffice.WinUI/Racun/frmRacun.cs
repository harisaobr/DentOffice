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
    public partial class frmRacun : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceRacun = new APIService("Racun");
        private int? _id;

        public frmRacun()
        {
            InitializeComponent();
        }
        public frmRacun(int RacunId): this()
        {
            _id = RacunId;
        }
        private async Task LoadPacijent()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DisplayMember = "ImePrezime";
            cmbPacijent.ValueMember = "KorisnikID";
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
            await LoadPacijent();
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
    }
}
