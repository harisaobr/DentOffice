using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class UslugaUpsertRequest
    {
        public int UslugaID { get; set; }
        [Required]
        public string Naziv { get; set; }
        
        [Required]
        public decimal Cijena { get; set; }

    }
}
