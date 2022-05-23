using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class KorisnikSearchRequest
    {
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string JMBG { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public DateTime OD { get; set; }
        public DateTime DO { get; set; }
        public bool ShowStomatologe { get; set; }
    }
}
