using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradoviWebApi.Models
{
    [Table("Gradovi")]
    public class Grad
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public int PostanskiBroj { get; set; }

        [Required]
        public int BrojStanovnika { get; set; }

        public Drzava Drzava { get; set; }

        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }
    }
}