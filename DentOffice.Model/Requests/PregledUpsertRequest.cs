﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class PregledUpsertRequest
    {

        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int LijekId { get; set; }
        [Required]
        public int DijagnozaId { get; set; }
        [Required]
        public int UslugaId { get; set; }
        [Required]
        [Range(1, 480, ErrorMessage = "Trajanje pregleda ne moze biti manje od 1 minute i vece od 480 minuta")]
        public int TrajanjePregleda { get; set; }
    
        [Required]
        [StringLength(200)]
        public string Napomena { get; set; }
       
    }
}
