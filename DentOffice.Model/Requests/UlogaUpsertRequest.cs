using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class UlogaUpsertRequest
    {
        [Required]
        public int UlogaID { get; set; }
        public string Naziv { get; set; }
    }
}
