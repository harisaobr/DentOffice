using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentOffice.WinUI.Racun
{
    public partial class frmRacun : Form
    {
        private readonly APIService _serviceKorisnici = new APIService("Korisnik");

        public frmRacun()
        {
            InitializeComponent();
        }
        private async Task LoadPacijent()
        {
            var result = await _serviceKorisnici.GetAll<List<Model.KorisnikPacijent>>(null, "KorisnikPacijenti");
            cmbPacijent.DisplayMember = "Ime";
            cmbPacijent.ValueMember = "PacijentID";
            cmbPacijent.DataSource = result;
        }
    
    }
}
