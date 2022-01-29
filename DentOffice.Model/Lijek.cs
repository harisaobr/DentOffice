using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Lijek
    {
        public int LijekID { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
