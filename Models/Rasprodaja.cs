using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Rasprodaja
    {
        [Key]
        public int IdRasprodaje { get; set; }
        public int? IdDetalja { get; set; }
        [Column("popust")]
        public int? Popust { get; set; }

        [ForeignKey(nameof(IdDetalja))]
        [InverseProperty(nameof(Detalji.Rasprodaja))]
        public virtual Detalji IdDetaljaNavigation { get; set; }
    }
}
