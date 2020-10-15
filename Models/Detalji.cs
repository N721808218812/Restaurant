using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Detalji
    {
        public Detalji()
        {
            Rasprodaja = new HashSet<Rasprodaja>();
        }

        [Key]
        [Column("IDDetalja")]
        public int Iddetalja { get; set; }
        [StringLength(50)]
        public string Naziv { get; set; }
        [Column("putanja")]
        public string Putanja { get; set; }
        [Column("opis")]
        public string Opis { get; set; }
        [Column("sastojci")]
        public string Sastojci { get; set; }
        [Column("IDKategorije")]
        public int? Idkategorije { get; set; }
        public bool? Popularno { get; set; }
        [Column("cena")]
        public double? Cena { get; set; }

        [ForeignKey(nameof(Idkategorije))]
        [InverseProperty(nameof(Kategorije.Detalji))]
        public virtual Kategorije IdkategorijeNavigation { get; set; }
        [InverseProperty("IdDetaljaNavigation")]
        public virtual ICollection<Rasprodaja> Rasprodaja { get; set; }
    }
}
