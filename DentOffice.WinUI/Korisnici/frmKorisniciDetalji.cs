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

namespace DentOffice.WinUI.Korisnik
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnik");
        private readonly APIService _serviceGradovi = new APIService("Grad");

        private int? _id = null;
        private byte[] Slika;

        public frmKorisniciDetalji(int? korinikId = null)
        {
            InitializeComponent();
            _id = korinikId;
            if (_id.HasValue)
                Text = "Uređivanje korisnika";
            else
                Text = "Dodavanje korisnika";
        }

        private async Task LoadGradove()
        {
            var result = await _serviceGradovi.GetAll<List<Model.Grad>>(null);

            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DataSource = result;

        }

        private async void btnSnimi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                var request = new KorisnikInsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    JMBG = txtJMBG.Text,
                    Email = txtEmail.Text,
                    BrojTelefona = txtBrojTelefona.Text,
                    DatumRodjenja = Convert.ToString(dtpDatum.Text),
                    Adresa = txtAdresa.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConf.Text
                };
                if (cmbGrad.SelectedValue != null)
                    request.GradID = int.Parse(cmbGrad.SelectedValue.ToString());

                if(Slika != null)
                {
                    request.Slika = Slika;
                }

                Model.Korisnik entity = null;

                if (!_id.HasValue)
                {
                    entity = await _service.Insert<Model.Korisnik>(request);
                }
                else
                {
                    entity = await _service.Update<Model.Korisnik>(_id.Value, request);
                }

                if(entity != null)
                    MessageBox.Show("Uspješno izvršeno");

            }
        }




        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradove();
            if (_id.HasValue)
            {
                var korisnik = await _service.GetById<Model.Korisnik>(_id);
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtKorisnickoIme.Text = korisnik.KorisnickoIme;
                txtJMBG.Text = korisnik.JMBG;
                txtEmail.Text = korisnik.Email;
                txtBrojTelefona.Text = korisnik.BrojTelefona;
                if (korisnik?.DatumRodjenja.Value != DateTime.MinValue)
                    dtpDatum.Value = Convert.ToDateTime(korisnik.DatumRodjenja);
                txtAdresa.Text = korisnik.Adresa;
                cmbGrad.SelectedValue = korisnik.GradID;

                if(korisnik.Slika != null && korisnik.Slika.Length > 0)
                {
                    pic_Slika.Image = ImageHelper.ByteArrayToImage(korisnik.Slika);
                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);

            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);

            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtKorisnickoIme, null);

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);

            }
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider.SetError(txtJMBG, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtJMBG.Text.Length != 13)
            {
                errorProvider.SetError(txtJMBG, "JMBG mora da sadrzi 13 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtJMBG, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtAdresa.Text.Length < 3)
            {
                errorProvider.SetError(txtAdresa, "Adresa mora sadrzavat bar 3 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private void pic_Slika_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Slika = File.ReadAllBytes(openFileDialog.FileName);

                pic_Slika.Image = ImageHelper.ByteArrayToImage(Slika);
            }
        }
    }
}
