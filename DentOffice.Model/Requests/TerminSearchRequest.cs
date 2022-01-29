using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class TerminSearchRequest
    {
        public int PacijentId { get; set; }
        public int UslugaId { get; set; }
        public string Razlog { get; set; }
        //public bool IsNaCekanju { get; set; }
        //public string IsOdobren { get; set; }
        //public string IsOdbijen { get; set; }


    }
}
