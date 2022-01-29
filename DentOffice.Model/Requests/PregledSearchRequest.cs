using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class PregledSearchRequest
    {
        public int KorisnikId { get; set; }

        public int TerminId { get; set; }

        public string Napomena { get; set; }
        public string IsUplacenPregledRequest { get; set; }
    }
}
