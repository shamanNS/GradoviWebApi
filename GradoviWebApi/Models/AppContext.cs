using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GradoviWebApi.Models
{
    public class AppContext : DbContext
    {
        public virtual DbSet<Drzava> Drzave { get; set; }
        public virtual DbSet<Grad> Gradovi { get; set; }

        public AppContext() : base("name=AppDBContext")
        {
        }
    }
}