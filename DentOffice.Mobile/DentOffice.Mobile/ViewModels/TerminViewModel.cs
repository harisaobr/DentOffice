using DentOffice.Model;
using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentOffice.Mobile.ViewModels
{
    public class TerminViewModel : BaseViewModel
    {
        private readonly APIService _terminService = new APIService("Termin");
        private readonly APIService _uslugeService = new APIService("Usluga");

        public TerminViewModel()
        {
            Title = "Termini";
        }

        public ObservableCollection<Usluga> UslugaList { get; set; } = new ObservableCollection<Usluga>();

        private Usluga _selectedUsluga = null;
        public Usluga SelectedUsluga
        {
            get { return _selectedUsluga; }
            set { SetProperty(ref _selectedUsluga, value); }
        }

        private DateTime _odabraniDatum = DateTime.Now;
        public DateTime DatumRezervacije
        {
            get { return _odabraniDatum; }
            set { SetProperty(ref _odabraniDatum, value); }
        }
        private string _razlogTermina = string.Empty;
        public string RazlogTermina
        {
            get { return _razlogTermina; }
            set { SetProperty(ref _razlogTermina, value); }
        }
        private TimeSpan _odabranoVrijeme = new TimeSpan(8, 0, 0);
        public TimeSpan VrijemeRezervacije
        {
            get { return _odabranoVrijeme; }
            set { SetProperty(ref _odabranoVrijeme, value); }
        }

        private bool _hitanTermina = false;
        public bool HitanTermin
        {
            get { return _hitanTermina; }
            set { SetProperty(ref _hitanTermina, value); }
        }

        public async Task Init()
        {
            if (UslugaList.Count == 0)
            {
                var uslugeLista = await _uslugeService.GetAll<IList<Model.Usluga>>(null);
                UslugaList.Clear();

                foreach (var usluga in uslugeLista)
                {
                    UslugaList.Add(usluga);
                }
            }
        }
        public async Task Rezervisi()
        {

            DateTime datumIVrijemetemp = new DateTime(DatumRezervacije.Year, DatumRezervacije.Month,
                DatumRezervacije.Day, VrijemeRezervacije.Hours, VrijemeRezervacije.Minutes,
                VrijemeRezervacije.Seconds);

            var temp = await _terminService.Insert<Model.Termin>(new TerminInsertRequest
            {
                UslugaId = SelectedUsluga.UslugaID,
                DatumVrijeme = datumIVrijemetemp,
                Hitan = HitanTermin,
                Razlog = RazlogTermina
            });

            if (temp != null)
            {
                await Application.Current.MainPage.DisplayAlert("Dodavanje uspjesno", "Uspjesno ste rezervisali termin!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Rezervacija nije uspjela!", "OK");
            }



        }
    }
}
