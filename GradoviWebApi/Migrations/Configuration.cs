namespace GradoviWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GradoviWebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GradoviWebApi.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GradoviWebApi.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Drzave.AddOrUpdate(x => x.Id,

             new Drzava() { Id = 1, Ime = "Srbija", InternacionalniKod = "RS" },
             new Drzava() { Id = 2, Ime = "Francuska", InternacionalniKod = "FR" },
             new Drzava() { Id = 3, Ime = "Španija", InternacionalniKod = "ES" }
         );

            context.Gradovi.AddOrUpdate(x => x.Id,

                new Grad() { Ime = "Beograd", PostanskiBroj = 11000, BrojStanovnika = 1659440, DrzavaId = 1 },
                new Grad() { Ime = "Novi Sad", PostanskiBroj = 21000, BrojStanovnika = 277522, DrzavaId = 1 },
                new Grad() { Ime = "Nis", PostanskiBroj = 18000, BrojStanovnika = 187544, DrzavaId = 1 },
                new Grad() { Ime = "Pariz", PostanskiBroj = 75056, BrojStanovnika = 2229621, DrzavaId = 2 },
                new Grad() { Ime = "Marselj", PostanskiBroj = 13055, BrojStanovnika = 1831500, DrzavaId = 2 },
                new Grad() { Ime = "Nica", PostanskiBroj = 06088, BrojStanovnika = 1004826, DrzavaId = 2 },
                new Grad() { Ime = "Madrid", PostanskiBroj = 28001, BrojStanovnika = 3141991, DrzavaId = 3 },
                new Grad() { Ime = "Barselona", PostanskiBroj = 08002, BrojStanovnika = 1604555, DrzavaId = 3 },
                new Grad() { Ime = "Valensija", PostanskiBroj = 46182, BrojStanovnika = 786189, DrzavaId = 3 }
            );
        }
    }
}
