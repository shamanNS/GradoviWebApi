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
    public class GradoviController : ApiController
    {
        IGradRepository _gradRepo;
        public GradoviController(IGradRepository repository)
        {
            _gradRepo = repository;
        }

        // GET: api/Gradovi
        //public IQueryable<Grad> GetGradovi()
        //{
        //    return _gradRepo.GetAll().AsQueryable();
        //}


        public IHttpActionResult GetGradovi(int? populacijaOd = null, int? populacijaDo = null)
        {
            if (populacijaOd == null && populacijaDo == null)
            {
                return Ok(_gradRepo.GetAll());
            }
            else
            {
                if (populacijaOd == null || populacijaDo == null)
                {
                    return BadRequest("Obavezno je navesti oba parametra.");
                }

                if (populacijaDo < populacijaOd)
                {
                    return BadRequest("Gornja granica ne može biti manja od donje!");
                }

                return Ok(_gradRepo.GetAllFiltered((int)populacijaOd, (int)populacijaDo));
            }

           
        }


        // GET: api/Gradovi/5
        [ResponseType(typeof(Grad))]
        public IHttpActionResult GetGrad(int id)
        {
            Grad grad = _gradRepo.GetById(id);

            if (grad == null)
            {
                return NotFound();
            }

            return Ok(grad);
        }

        // PUT: api/Gradovi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrad(int id, Grad grad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (grad.Id != id)
            {
                return BadRequest();
            }

            try
            {
                _gradRepo.Update(grad);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(grad);
        }

        // POST: api/Gradovi
        [ResponseType(typeof(Grad))]
        public IHttpActionResult PostGrad(Grad grad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gradRepo.Add(grad);
            return CreatedAtRoute("DefaultApi", new { id = grad.Id }, grad);
        }

        // DELETE: api/Gradovi/5
        [ResponseType(typeof(Grad))]
        public IHttpActionResult DeleteGrad(int id)
        {
            Grad grad = _gradRepo.GetById(id);

            if (grad == null)
            {
                return NotFound();
            }

            _gradRepo.Delete(grad);

            return StatusCode(HttpStatusCode.NoContent);
        }

   

        private bool GradExists(int id)
        {
            return _gradRepo.GetAll().Count(g => g.Id == id) > 0;
        }
    }
}