using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Onama
    {
        [Key]
        public int IdOnama { get; set; }
        public string VremeRezervacije { get; set; }
        [StringLength(50)]
        public string BrojOsoba { get; set; }
    }
}
