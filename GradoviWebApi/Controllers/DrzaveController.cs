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
using GradoviWebApi.Repository.Interfaces;

namespace GradoviWebApi.Controllers
{
    public class DrzaveController : ApiController
    {
        IDrzavaRepository _drzavaRepo;

        public DrzaveController(IDrzavaRepository repository)
        {
            _drzavaRepo = repository;
        }

        // GET: api/Drzave
        public IQueryable<Drzava> GetDrzave()
        {
            return _drzavaRepo.GetAll().AsQueryable();
        }

        // GET: api/Drzave/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult GetDrzava(int id)
        {
            Drzava drzava = _drzavaRepo.GetById(id);

            if (drzava == null)
            {
                return NotFound();
            }
            return Ok(drzava);
        }


        [Route("api/statistics")]
        public IQueryable<DrzavaDTO> GetStatistic()
        {
            return _drzavaRepo.GetPopulation().AsQueryable();

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

            try
            {
                _drzavaRepo.Update(drzava);
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
            return Ok(drzava);
        }

        // POST: api/Drzave
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult PostDrzava(Drzava drzava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _drzavaRepo.Add(drzava);

            return CreatedAtRoute("DefaultApi", new { id = drzava.Id }, drzava);
        }

        // DELETE: api/Drzave/5
        [ResponseType(typeof(Drzava))]
        public IHttpActionResult DeleteDrzava(int id)
        {
            Drzava drzava = _drzavaRepo.GetById(id);

            if (drzava == null)
            {
                return NotFound();
            }

            _drzavaRepo.Delete(drzava);
            return StatusCode(HttpStatusCode.NoContent);
        }



        private bool DrzavaExists(int id)
        {
            return _drzavaRepo.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}