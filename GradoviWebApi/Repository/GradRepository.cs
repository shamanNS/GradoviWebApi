using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GradoviWebApi.Repository.Interfaces;
using GradoviWebApi.Models;
using System.Data.Entity;

namespace GradoviWebApi.Repository
{
    public class GradRepository : IGradRepository, IDisposable
    {

        private AppContext db = new AppContext();

        public void Add(Grad grad)
        {
            db.Gradovi.Add(grad);
            db.SaveChanges();
        }

        public void Delete(Grad grad)
        {
            db.Gradovi.Remove(grad);
            db.SaveChanges();
        }

        public IEnumerable<Grad> GetAll()
        {
            return db.Gradovi.Include(g => g.Drzava);
        }
        public IEnumerable<Grad> GetAllFiltered(int populacijaOd, int populacijaDo)
        {
            return db.Gradovi
                .Where(g => g.BrojStanovnika >= populacijaOd && g.BrojStanovnika <= populacijaDo)
                .Include(g => g.Drzava);
        }


        public Grad GetById(int id)
        {
            return db.Gradovi.Include(g => g.Drzava).FirstOrDefault(g => g.Id == id);
        }

        public void Update(Grad grad)
        {
            db.Entry(grad).State = EntityState.Modified;
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}