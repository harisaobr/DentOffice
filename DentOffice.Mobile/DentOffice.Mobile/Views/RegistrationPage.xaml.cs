using DentOffice.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DentOffice.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private RegistrationViewModel VM;

        public RegistrationPage()
        {
            InitializeComponent();

            BindingContext = VM = new RegistrationViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.LoadGradove();
            VM.LoadSpolove();
        }

        private void LoginLabel_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

      
    }
}