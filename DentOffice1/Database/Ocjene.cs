using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Database
{
    public class Ocjene
    {
        [Key]
        public int OcjenaId { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int KorisnikId { get; set; }
        public Korisnik Stomatolog { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Kreirano { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Ocjena { get; set; }

        [Required]
        [StringLength(300)]
        public string Komentar { get; set; }
    }
}
