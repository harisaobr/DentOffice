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
    public partial class frmDetaljiPregleda : Form
    {
        private readonly APIService _serviceLijek = new APIService("Lijek");
        private readonly APIService _serviceDijagnoza = new APIService("Dijagnoza");
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");
        private readonly APIService _servicePregled = new APIService("Pregled");
        private readonly APIService _serviceUsluga = new APIService("Usluga");


        private int? _id = null;
        public frmDetaljiPregleda(int? pregledId = null)
        {
            InitializeComponent();
            _id = pregledId;
        }

        private async void frmDetaljiPregleda_Load(object sender, EventArgs e)
        {

            await LoadDijagnoze();
            await LoadLijekovi();
            await LoadPacijent();
            await LoadUsluge();

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

            cmbDijagnoza.DisplayMember = "Naziv";
            cmbDijagnoza.ValueMember = "DijagnozaId";
            cmbDijagnoza.DataSource = result;
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
            cmbUsluga.DataSource = result;
            cmbUsluga.DisplayMember = "Naziv";
            cmbUsluga.ValueMember = "UslugaId";
        }


        private PregledUpsertRequest Request = new PregledUpsertRequest();

        private async void btnSnimiPregled_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                int.TryParse(cmbDijagnoza.SelectedValue.ToString(), out int convertDijagnoza);
                int.TryParse(cmbLijek.SelectedValue.ToString(), out int convertLijek);
                int.TryParse(txtTrajanje.Text, out int convertTrajanje);

                Request.KorisnikId = APIService.KorisnikId;
                Request.DijagnozaId = convertDijagnoza;
                Request.LijekId = convertLijek;
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

    }

}
