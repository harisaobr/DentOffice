using DentOffice.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DentOffice.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}