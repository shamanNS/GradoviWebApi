using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GradoviWebApi.Repository.Interfaces;
using GradoviWebApi.Models;
using System.Data.Entity;
using AutoMapper;

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
            return db.Drzave.Include(d => d.Gradovi);
        }

        public Drzava GetById(int id)
        {
            //Drzava drzava = db.Drzave.Find(id);
            Drzava drzava = db.Drzave.Include( d=> d.Gradovi).Where(d => d.Id == id).SingleOrDefault();
            return drzava;
        }

        public IEnumerable<DrzavaDTO> GetPopulation()
        {
            var drzave = db.Drzave.Include( d => d.Gradovi) ;
            List<DrzavaDTO> listaDrzavaDTO = new List<DrzavaDTO>();
            foreach (var d in drzave)
            {
                var populacija = db.Gradovi.Where(g => g.DrzavaId == d.Id).Sum(g => g.BrojStanovnika);
                //DrzavaDTO drzavaDTO = new DrzavaDTO { Ime = d.Ime, Id = d.Id, Populacija = populacija };
                DrzavaDTO drzavaDTO = Mapper.Map<DrzavaDTO>(d);
                drzavaDTO.Populacija = populacija;
                listaDrzavaDTO.Add(drzavaDTO);
            }

            listaDrzavaDTO = listaDrzavaDTO.OrderByDescending(d => d.Populacija).ToList();
            return listaDrzavaDTO;

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