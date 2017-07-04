using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradoviWebApi.Models
{
    public class DrzavaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        public int Populacija { get; set; }
    }
}