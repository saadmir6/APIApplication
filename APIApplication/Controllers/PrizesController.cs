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
    public class PrizesController : ApiController
    {
       
        private UnitOfWork unit;

        public PrizesController()
        { 
            unit = new UnitOfWork(new ApplicationDBContext());
        }

        // GET: api/Prizes
        public IEnumerable<object> GetPrizes()
        {
            var prizeDtos = unit.Prizes.GetAll().Select(prize => new PrizeDto(prize));
                
            return prizeDtos;
        }

        // GET: api/Prizes/5
        [ResponseType(typeof(Prize))]
        public IHttpActionResult GetPrize(int id)
        {
            Prize prize = unit.Prizes.GetById(id);
            if (prize == null)
            {
                return NotFound();
            }

            var prizeDto = new PrizeDto(prize);

            return Ok(prizeDto);
        }

        // PUT: api/Prizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrize(int id, Prize prize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prize.Id)
            {
                return BadRequest();
            }

            unit.Prizes.Update(prize);

            try
            {
                unit.Prizes.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrizeExists(id))
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

        // POST: api/Prizes
        [ResponseType(typeof(Prize))]
        public IHttpActionResult PostPrize(Prize prize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Prizes.Insert(prize);
            unit.Prizes.Save();


            return CreatedAtRoute("DefaultApi", new { id = prize.Id }, prize);
        }

        // DELETE: api/Prizes/5
        [ResponseType(typeof(Prize))]
        public IHttpActionResult DeletePrize(int id)
        {
            Prize prize = unit.Prizes.GetById(id);
            if (prize == null)
            {
                return NotFound();
            }

            unit.Prizes.Delete(id);
            unit.Prizes.Save();

            return Ok(prize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrizeExists(int id)
        {
            return unit.Prizes.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}