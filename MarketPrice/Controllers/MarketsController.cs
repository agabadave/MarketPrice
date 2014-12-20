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
using MarketPrice.Models;
using MarketPrice.Repositories;

namespace MarketPrice.Controllers
{
    public class MarketsController : ApiController
    {
        private readonly IRepository _repo;

        public MarketsController()
        {
            _repo = new Repository();
        }

        // GET: api/Markets
        public IEnumerable<Market> GetMarkets()
        {
            return _repo.GetAll<Market>();
        }


        // GET: api/Markets/5
        public IHttpActionResult GetMarket(int id)
        {
            Market market =_repo.Get<Market>(id);
            if (market == null)
            {
                return NotFound();
            }

            return Ok(market);
        }

        // PUT: api/Markets/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutMarket(int id, Market market)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//
//            if (id != market.Id)
//            {
//                return BadRequest();
//            }
//
//            db.Entry(market).State = EntityState.Modified;
//
//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!MarketExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//
//            return StatusCode(HttpStatusCode.NoContent);
//        }

        // POST: api/Markets
//        [ResponseType(typeof(Market))]
//        public IHttpActionResult PostMarket(Market market)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//
//            db.Markets.Add(market);
//            db.SaveChanges();
//
//            return CreatedAtRoute("DefaultApi", new { id = market.Id }, market);
//        }
//
//        // DELETE: api/Markets/5
//        [ResponseType(typeof(Market))]
//        public IHttpActionResult DeleteMarket(int id)
//        {
//            Market market = db.Markets.Find(id);
//            if (market == null)
//            {
//                return NotFound();
//            }
//
//            db.Markets.Remove(market);
//            db.SaveChanges();
//
//            return Ok(market);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

        private bool MarketExists(int id)
        {
            return _repo.Get<Market>(id) != null;
        }
    }
}