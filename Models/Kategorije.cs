using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Kategorije
    {
        public Kategorije()
        {
            Detalji = new HashSet<Detalji>();
        }

        [Key]
        public int IdKategorije { get; set; }
        [StringLength(50)]

        public string Naziv { get; set; }
        [Column("putanja")]
        public string Putanja { get; set; }

        [InverseProperty("IdkategorijeNavigation")]
        public virtual ICollection<Detalji> Detalji { get; set; }
    }
}
