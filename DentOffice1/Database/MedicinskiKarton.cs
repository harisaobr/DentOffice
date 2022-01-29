using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class MedicinskiKarton
    {
        public int MedicinskiKartonId { get; set; }
        public int? PacijentId { get; set; }
        public int? PregledId { get; set; }
        public DateTime? Datum { get; set; }
        public string Napomena { get; set; }

        public virtual Pacijent Pacijent { get; set; }
        public virtual Pregled Pregled { get; set; }
    }
}
