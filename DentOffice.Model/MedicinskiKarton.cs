using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class MedicinskiKarton
    {
        public int MedicinskiKartonID { get; set; }
        public DateTime Datum { get; set; }
        public string Napomena { get; set; }
    }
}
