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


        public string Ime { get; set; }

        public int Populacija { get; set; }

        public string InternacionalniKod { get; set; }

        public List<GradDTO> Gradovi { get; set; }
    }
}