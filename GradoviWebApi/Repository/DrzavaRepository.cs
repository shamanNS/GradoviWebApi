using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GradoviWebApi.Repository.Interfaces;
using GradoviWebApi.Models;
using System.Data.Entity;


namespace GradoviWebApi.Repository
{
    public class DrzavaRepository : IDrzavaRepository, IDisposable
    {
        private AppContext db = new AppContext();

        public void Add(Drzava drzava)
        {
            db.Drzave.Add(drzava);
            db.SaveChanges();
        }

        public void Delete(Drzava drzava)
        {
            db.Drzave.Remove(drzava);
            db.SaveChanges();
        }

        public IEnumerable<Drzava> GetAll()
        {
            return db.Drzave;
        }

        public Drzava GetById(int id)
        {
            Drzava drzava = db.Drzave.Find(id);
            return drzava;
        }

        public void Update(Drzava drzava)
        {
            db.Entry(drzava).State = EntityState.Modified;
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