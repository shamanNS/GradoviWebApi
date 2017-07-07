using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradoviWebApi.Models
{
    public class GradDTO
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public int PostanskiBroj { get; set; }

        [Required]
        public int BrojStanovnika { get; set; }

        public int DrzavaId { get; set; }
        public string DrzavaName { get; set; }
    }
}