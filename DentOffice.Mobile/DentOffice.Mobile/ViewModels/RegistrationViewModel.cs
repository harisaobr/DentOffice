using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using DentOffice.Mobile.Views;
using DentOffice.Mobile.Helpers;
using System.Text.RegularExpressions;
using System.Linq;

namespace DentOffice.Mobile.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly APIService _serviceKorisnik = new APIService("Korisnik");
        private readonly APIService _serviceGradovi = new APIService("Grad");

        public ObservableCollection<Model.Grad> Gradovi { get; set; } = new ObservableCollection<Model.Grad>();
        public ObservableCollection<Model.Spol> SpolList { get; set; } = new ObservableCollection<Model.Spol>();

        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(async () => await Register());
            Title = "Registration";
            _korisnik = new Model.Requests.KorisniciPacijentInsertRequest() { DatumRodjenja = DateTime.Today.AddYears(-20)};
        }

        public async Task LoadGradove()
        {
            var list = await _serviceGradovi.Get<List<Model.Grad>>(null);
            Gradovi.Clear();
            foreach (var item in list)
            {
                Gradovi.Add(item);
            }
        }
        public void LoadSpolove()
        {
            var list = Enum.GetValues(typeof(Model.Spol)).Cast<Model.Spol>().ToList();
            SpolList.Clear();
            foreach (var item in list)
            {
                SpolList.Add(item);
            }
        }
        private Model.Grad _city;
        public Model.Grad City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private Model.Spol _spol;
        public Model.Spol Spol
        {
            get { return _spol; }
            set { SetProperty(ref _spol, value); }
        }

        private Model.Requests.KorisniciPacijentInsertRequest _korisnik;
        public Model.Requests.KorisniciPacijentInsertRequest Korisnik
        {
            get { return _korisnik; }
            set { SetProperty(ref _korisnik, value); }
        }

        public ICommand RegistrationCommand { get; set; }

        async Task Register()
        {
            string error = GetValidationError();
            
            if (error != null)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", error, "OK");
                return;
            }
            
            IsBusy = true;

            try
            {
                Korisnik.GradId = City.GradID;

                var entity = await _serviceKorisnik.Insert<Model.Pacijent>(Korisnik, "KorisnikPacijenti");
                if (entity == null)
                    throw new Exception();

                APIService.Username = Korisnik.KorisnickoIme;
                APIService.Password = Korisnik.Password;
                APIService.PrijavljeniKorisnik = await _serviceKorisnik.Get<Model.Korisnik>(null, "Profil");

                await SecureStorage.SetAsync("username", APIService.Username);
                await SecureStorage.SetAsync("password", APIService.Password);

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        private string GetValidationError()
        {
            if (string.IsNullOrEmpty(Korisnik.Ime))
                return string.Format(ValidateItems.Required, "Ime");
            if (string.IsNullOrEmpty(Korisnik.Prezime))
                return string.Format(ValidateItems.Required, "Prezime");
            if (string.IsNullOrEmpty(Korisnik.KorisnickoIme))
                return string.Format(ValidateItems.Required, "Korisnicko ime");

            if (string.IsNullOrWhiteSpace(Korisnik.BrojTelefona))
            {
                return string.Format(ValidateItems.Required, "Broj telefona");
            }
            else if (!Regex.IsMatch(Korisnik.BrojTelefona, @"\+?[0-9]{9,15}"))
            {
               return "Broj telefona nije u ispravnom formatu (broj unijeti bez razmaka i zagrada)";
            }

            if (string.IsNullOrWhiteSpace(Korisnik.Email))
            {
                return string.Format(ValidateItems.Required, "Email");
            }
            else if(!Regex.IsMatch(Korisnik.Email, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase))
            {
                return "Email nije u ispravnom formatu";
            }
            
            if (string.IsNullOrWhiteSpace(Korisnik.JMBG))
            {
                return string.Format(ValidateItems.Required, "JMBG");
            }
            else if(!Regex.IsMatch(Korisnik.JMBG, @"[0-9]{13}"))
            {
                return "JMBG mora sadržavati tačno 13 cifara!";
            }

            if (string.IsNullOrWhiteSpace(Korisnik.Adresa))
            {
                return string.Format(ValidateItems.Required, "Adresa");
            }
            else if (Korisnik.Adresa.Length < 3)
            {
                return "Adresa mora sadrzavati barem 3 karaktera!";
            }

            if (City == null)
                return string.Format(ValidateItems.Required, "Grad");

            if (string.IsNullOrWhiteSpace(Korisnik.Password))
            {
                return string.Format(ValidateItems.Required, "Lozinka");

            }
            else if (Korisnik.Password.Length < 4)
            {
                return "Lozinka mora sadrzavati barem 4 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(Korisnik.PasswordConfirm))
            {
                return string.Format(ValidateItems.Required, "Potvrda lozinke");

            }
            else if (Korisnik.PasswordConfirm != Korisnik.Password)
            {
                return "Lozinke se ne podudaraju!";
            }

            return null;
        }

        
    }
 }
