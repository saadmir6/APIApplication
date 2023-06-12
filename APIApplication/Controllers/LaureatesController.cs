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
using APIApplication.Models;
using APIApplication.Models.Dtos;
using APIApplication.MyDatabase;
using APIApplication.Persistence;

namespace APIApplication.Controllers
{
    public class LaureatesController : ApiController
    {


        private UnitOfWork unit;

        public LaureatesController()
        {
            unit = new UnitOfWork(new ApplicationDBContext());
        }

        // GET: api/Laureates
        public IEnumerable<object> GetLaureates()
        {
            var laureateDtos = unit.Laureates.GetAll().Select(laureate => new LaureateDto(laureate));

            return laureateDtos;
        }

        // GET: api/Laureates/5
        [ResponseType(typeof(Laureates))]
        public IHttpActionResult GetLaureates(int id)
        {
            Laureates laureates = unit.Laureates.GetById(id);
            if (laureates == null)
            {
                return NotFound();
            }

            var laureateDto = new LaureateDto(laureates);
            return Ok(laureateDto);
        }

        // PUT: api/Laureates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaureates(int id, Laureates laureates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laureates.Id)
            {
                return BadRequest();
            }

            unit.Laureates.Update(laureates);

            try
            {
                unit.Laureates.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaureatesExists(id))
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

        // POST: api/Laureates
        [ResponseType(typeof(Laureates))]
        public IHttpActionResult PostLaureates(Laureates laureates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Laureates.Insert(laureates);
            unit.Laureates.Save();

            return CreatedAtRoute("DefaultApi", new { id = laureates.Id }, laureates);
        }

        // DELETE: api/Laureates/5
        [ResponseType(typeof(Laureates))]
        public IHttpActionResult DeleteLaureates(int id)
        {
            Laureates laureates = unit.Laureates.GetById(id);
            if (laureates == null)
            {
                return NotFound();
            }

            unit.Laureates.Delete(laureates);
            unit.Laureates.Save();

            return Ok(laureates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaureatesExists(int id)
        {
            return unit.Laureates.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}