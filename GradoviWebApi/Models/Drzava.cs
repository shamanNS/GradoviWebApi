using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GradoviWebApi.Models
{
    [Table("Drzave")]
    public class Drzava
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string InternacionalniKod { get; set; }
    }
}