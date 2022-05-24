using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Pacijent_Data
    {
        public int PacijentID { get; set; }
        public bool Proteza { get; set; }
        public bool Aparatic { get; set; }
        public bool Terapija { get; set; }
        public int KorisnikID { get; set; }

    }
}
