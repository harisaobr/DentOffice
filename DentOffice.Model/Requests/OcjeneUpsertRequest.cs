using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class OcjeneUpsertRequest
    {
        [Required]
        public int PacijentId { get; set; }
        [Required]
        public int KorisnikId { get; set; }

        [Required]
        public decimal Ocjena { get; set; }

        [Required]
        [StringLength(300)]
        public string Komentar { get; set; }
    }
}
