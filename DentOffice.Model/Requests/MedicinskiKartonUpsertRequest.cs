using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class MedicinskiKartonUpsertRequest
    {
        public int MedicinskiKartonID { get; set; }
        public int PregledId { get; set; }

        public int PacijentId { get; set; }

        public DateTime Datum { get; set; }
    }
}
