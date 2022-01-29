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
    public partial class TerminPage : ContentPage
    {
        private TerminViewModel model = null;
        public TerminPage()
        {
            InitializeComponent();
            BindingContext = model = new TerminViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        async void RezervisiButtonClicked(object sender, EventArgs e)
        {
            await model.Rezervisi();
            //await Navigation.PopAsync();
        }
    }
}