using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class DrzavaUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
    }
}
