using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corso.Models
{
    public partial class Rezervacija
    {
        [Key]
        [Column("IdRezervacije")]
        public int IdRezervacije { get; set; }
        [StringLength(50)]
        public string Ime { get; set; }
        [StringLength(50)]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Morate uneti e mail adresu!")]
        public string Email { get; set; }
        public string DetaljiRezervacije { get; set; }
        [StringLength(50)]
        public string Telefon { get; set; }
        [StringLength(50)]
        public string BrojOsoba { get; set; }

        public string To="duskomladenovic58@gmail.com";
    }
}
