using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Pitanja
    {
        [Key]
        [Column("IdPitanja")]
        public int IdPitanja { get; set; }
        [StringLength(50)]
        [Required]
        public string Ime { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Morate uneti e mail adresu!")]
        public string Email { get; set; }
        [Required]
        public string Pitanje { get; set; }

        public string To = "duskomladenovic58@gmail.com";
    }
}
