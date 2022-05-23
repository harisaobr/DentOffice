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
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
            var reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!reg.IsMatch(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email nije u ispravnom formatu");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtEmail, null);
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJMBG.Text))
            {
                errorProvider.SetError(txtJMBG, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtJMBG.Text, @"[0-9]{13}"))
            {
                errorProvider.SetError(txtJMBG, "JMBG mora sadržavati tačno 13 cifara!");
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
                errorProvider.SetError(txtAdresa, "Adresa mora sadrzavati barem 3 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private void txtBrojTelefona_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojTelefona.Text))
            {
                errorProvider.SetError(txtBrojTelefona, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtBrojTelefona.Text, @"\+?[0-9]{9,15}"))
            {
                errorProvider.SetError(txtBrojTelefona, "Broj telefona nije u ispravnom formatu (broj unijeti bez razmaka i zagrada)");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBrojTelefona, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }
        private void cmbSpol_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.ValidirajKontrolu(sender, e, Properties.Resources.Validation_RequiredField);
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (_id.HasValue)
                {
                    errorProvider.SetError(txtPasswordConf, null);
                    return;
                }
                errorProvider.SetError(txtPassword, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtPassword.Text.Length < 4)
            {
                errorProvider.SetError(txtPassword, "Lozinka mora sadrzavati barem 4 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordConf_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConf.Text))
            {
                if (_id.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorProvider.SetError(txtPasswordConf, null);
                    return;
                }
                errorProvider.SetError(txtPasswordConf, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtPassword.Text != txtPasswordConf.Text)
            {
                errorProvider.SetError(txtPasswordConf, "Lozinke se ne podudaraju!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPasswordConf, null);
            }
        }
    }
}
