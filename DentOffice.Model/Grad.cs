using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
