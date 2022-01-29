using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI.Pacijenti
{
    public partial class frmPacijentiDetalji : Form
    {
        private readonly APIService _serviceKorisnik = new APIService("Korisnik");
        private readonly APIService _serviceGradovi = new APIService("Grad");
        private int? _id = null;
        public frmPacijentiDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
            if (_id.HasValue)
                Text = "Uređivanje pacijenta";
            else
                Text = "Dodavanje pacijenta";
        }

        private async Task LoadGradove()
        {
            var result = await _serviceGradovi.GetAll<List<Model.Grad>>(null);
            cmbGrad.DataSource = result;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
        }

        private async void frmPAcijentiDetalji_Load(object sender, EventArgs e)
        {
            UcitajSpolove();
            await LoadGradove();

            if (_id.HasValue)
            {
                var pacijent = await _serviceKorisnik.GetById<Model.KorisnikPacijent>(_id, "KorisnikPacijenti");
                txtIme.Text = pacijent.Ime;
                txtPrezime.Text = pacijent.Prezime;
                txtAdresa.Text = pacijent.Adresa;
                txtEmail.Text = pacijent.Email;
                txtJMBG.Text = pacijent.Jmbg;
                txtKorisnickoIme.Text = pacijent.KorisnickoIme;
                txtBrojTelefona.Text = pacijent.BrojTelefona;
                if (pacijent.DatumRodjenja != DateTime.MinValue)
                    dtpDatum.Value = pacijent.DatumRodjenja;

                if (pacijent.GradId != null)
                    cmbGrad.SelectedValue = pacijent.GradId;
                cbAparatic.Checked = pacijent.Aparatic;
                cbProteza.Checked = pacijent.Proteza;
                cbTerapija.Checked = pacijent.Terapija;

                if (pacijent.Slika != null && pacijent.Slika.Length > 0)
                {
                    pic_SlikaPacijent.Image = ImageHelper.ByteArrayToImage(pacijent.Slika);
                }

                foreach (Spol item in cmbSpol.Items)
                {
                    if (item == pacijent.Spol)
                    {
                        cmbSpol.SelectedItem = item;
                        break;
                    }
                }

            }

        }

        public byte[] Slika { get; private set; }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            var request = new Model.Requests.KorisniciPacijentInsertRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtKorisnickoIme.Text,
                Email = txtEmail.Text,
                JMBG = txtJMBG.Text,
                DatumRodjenja = dtpDatum.Value,
                BrojTelefona = txtBrojTelefona.Text,
                Adresa = txtAdresa.Text,
                Aparatic = cbAparatic.Checked,
                Proteza = cbProteza.Checked,
                Terapija = cbTerapija.Checked,
                Spol = (Spol)cmbSpol.SelectedItem
            };
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                request.Password = txtPassword.Text;
                request.PasswordConfirm = txtPasswordConf.Text;
            }

            if (cmbGrad.SelectedValue != null)
                request.GradId = int.Parse(cmbGrad.SelectedValue.ToString());

            if (Slika != null)
            {
                request.Slika = Slika;
            }

            Model.Pacijent korisnik;
            if (_id.HasValue)
                korisnik = await _serviceKorisnik.Update<Model.Pacijent>(_id, request, "KorisnikPacijenti");
            else
                korisnik = await _serviceKorisnik.Insert<Model.Pacijent>(request, "KorisnikPacijenti");

            if (korisnik != null)
            {
                if (_id.HasValue)
                    MessageBox.Show("Profil uspješno azuriran.", "Azuriraj profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Profil uspješno kreiran.", "Kreiraj profil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
        }

        private void pic_SlikaPacijent_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Slika = File.ReadAllBytes(openFileDialog.FileName);

                pic_SlikaPacijent.Image = ImageHelper.ByteArrayToImage(Slika);
            }
        }

        private void UcitajSpolove()
        {
            cmbSpol.DataSource = Enum.GetValues(typeof(Spol)).Cast<Spol>().ToList();
        }
    }
}
