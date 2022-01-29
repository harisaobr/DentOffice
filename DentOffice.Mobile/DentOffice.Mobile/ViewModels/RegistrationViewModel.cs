using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using DentOffice.Mobile.Views;

namespace DentOffice.Mobile.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly APIService _serviceKorisnik = new APIService("Korisnik");
        private readonly APIService _serviceGradovi = new APIService("Grad");

        public ObservableCollection<Model.Grad> Gradovi { get; set; } = new ObservableCollection<Model.Grad>();



        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(async () => await Register());
            Title = "Registration";
            _korisnik = new Model.Requests.KorisnikInsertRequest();
        }

        private bool _isButtonEnabled = true;

        //public async Task LoadGradove()
        //{

        //    var request = new Model.Requests.GradSearchRequest();

        //    var list = await _serviceGradovi.Get<List<Model.Grad>>(request);
        //    Gradovi.Clear();
        //    foreach (var item in list)
        //    {
        //        Gradovi.Add(item);
        //    }
        //}


        //private Model.Grad _city;
        //public Model.Grad City
        //{
        //    get { return _city; }
        //    set { SetProperty(ref _city, value); }
        //}



        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        private Model.Requests.KorisnikInsertRequest _korisnik;
        public Model.Requests.KorisnikInsertRequest Korisnik
        {
            get { return _korisnik; }
            set { SetProperty(ref _korisnik, value); }
        }


        public ICommand RegistrationCommand { get; set; }

        async Task Register()
        {
            IsButtonEnabled = false;

            try
            {
               

                var entity = await _serviceKorisnik.Insert<Model.Korisnik>(Korisnik);
                if (entity == null)
                    throw new Exception();

                APIService.Username = Korisnik.KorisnickoIme;
                APIService.Password = Korisnik.Password;
                //APIService.CurrentUser = await _serviceClients.Get<Model.Client>(null, "MyProfile");

                await SecureStorage.SetAsync("username", APIService.Username);
                await SecureStorage.SetAsync("password", APIService.Password);

#pragma warning disable CS0612 // Type or member is obsolete
                Application.Current.MainPage = new MainPage();
#pragma warning restore CS0612 // Type or member is obsolete
            }
            catch (Exception)
            {

            }
            finally
            {
                IsButtonEnabled = true;
            }
        }
    }
 }
