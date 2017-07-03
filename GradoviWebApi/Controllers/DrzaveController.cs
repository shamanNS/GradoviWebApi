using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GradoviWebApi.Models;

namespace GradoviWebApi.Controllers
{
    public class DrzaveController : ApiController
    {
        private AppContext db = new AppContext();

        // GET: api/Drzave
        public IQueryable<Drzava> GetDrzave()
        {
            return db.Drzave;
        }

        // GET: api/Drzave/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult GetDrzava(int id)
        {
            Drzava drzava = db.Drzave.Find(id);
            if (drzava == null)
            {
                return NotFound();
            }

            return Ok(drzava);
        }

        // PUT: api/Drzave/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrzava(int id, Drzava drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drzava.Id)
            {
                return BadRequest();
            }

            db.Entry(drzava).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzavaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Drzave
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult PostDrzava(Drzava drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drzave.Add(drzava);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drzava.Id }, drzava);
        }

        // DELETE: api/Drzave/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult DeleteDrzava(int id)
        {
            Drzava drzava = db.Drzave.Find(id);
            if (drzava == null)
            {
                return NotFound();
            }

            db.Drzave.Remove(drzava);
            db.SaveChanges();

            return Ok(drzava);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrzavaExists(int id)
        {
            return db.Drzave.Count(e => e.Id == id) > 0;
        }
    }
}