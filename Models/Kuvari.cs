using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Kuvari
    {
        [Key]
        public int IdKuvara { get; set; }
        [StringLength(50)]
        public string Naziv { get; set; }
        public string Putanja { get; set; }
    }
}
