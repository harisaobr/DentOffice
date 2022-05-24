using DentOffice.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DentOffice.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _serviceKorisnik = new APIService("Korisnik");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            Title = "Login";
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                APIService.PrijavljeniKorisnik = await _serviceKorisnik.Get<Model.Korisnik>(null, "Profil");

                if (APIService.PrijavljeniKorisnik == null)
                {
                    IsBusy = false;
                    return;
                }
                if (APIService.PrijavljeniKorisnik.Pacijents.Count == 0)
                    throw new Exception("Ne možete se prijaviti.");
               
                await SecureStorage.SetAsync("username", Username);
                await SecureStorage.SetAsync("password", Password);

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
