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

namespace DentOffice.WinUI.Korisnik
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _service = new APIService("Korisnik");
        private readonly APIService _serviceGradovi = new APIService("Grad");
        private readonly APIService _serviceUloga = new APIService("Uloga");

        private int? _id = null;
        private byte[] Slika;

        public frmKorisniciDetalji(int? korisnikId = null)
        {
            InitializeComponent();
            _id = korisnikId;
            if (_id.HasValue)
                Text = "Uređivanje stomatologa";
            else
                Text = "Dodavanje stomatologa";
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
                    PasswordConfirmation = txtPasswordConf.Text,
                    Spol = (Spol)cmbSpol.SelectedItem,
                    UlogaID = int.Parse(cmbUloga.SelectedValue.ToString())
                };
                if (cmbGrad.SelectedValue != null)
                    request.GradID = int.Parse(cmbGrad.SelectedValue.ToString());

                if (Slika != null)
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

                if (entity != null)
                {
                    if (_id.HasValue)
                        MessageBox.Show("Profil uspješno azuriran.", "Azuriraj profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Profil uspješno kreiran.", "Kreiraj profil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }

            }
        }


        private async Task LoadUloge()
        {
            var result = await _serviceUloga.GetAll<List<Model.Uloga>>(null);
            result = result.Where(x => x.Naziv != "Pacijent").ToList();

            cmbUloga.DisplayMember = "Naziv";
            cmbUloga.ValueMember = "UlogaID";
            cmbUloga.DataSource = result;
        }

        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            UcitajSpolove();
            await LoadGradove();
            await LoadUloge();
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
                cmbUloga.SelectedValue = korisnik.UlogaID;


                if (korisnik.Slika != null && korisnik.Slika.Length > 0)
                {
                    pic_Slika.Image = ImageHelper.ByteArrayToImage(korisnik.Slika);
                }

                foreach (Spol item in cmbSpol.Items)
                {
                    if (item == korisnik.Spol)
                    {
                        cmbSpol.SelectedItem = item;
                        break;
                    }
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

        private void pic_Slika_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Slika = File.ReadAllBytes(openFileDialog.FileName);

                pic_Slika.Image = ImageHelper.ByteArrayToImage(Slika);
            }
        }

        private void UcitajSpolove()
        {
            cmbSpol.DataSource = Enum.GetValues(typeof(Spol)).Cast<Spol>().ToList();
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
