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
    public class CommoditiesController : ApiController
    {
        private readonly IRepository _repo;

        public CommoditiesController()
        {
            _repo = new Repository();
        }

        // GET: api/Commodities
        public IEnumerable<Commodity> GetCommodities()
        {
            return _repo.GetAll<Commodity>();
        }

        // GET: api/Commodities/5
        [ResponseType(typeof(Commodity))]
        public IHttpActionResult GetCommodity(int id)
        {
            Commodity commodity = _repo.Get<Commodity>(id);
            if (commodity == null)
            {
                return NotFound();
            }

            return Ok(commodity);
        }

        // PUT: api/Commodities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommodity(int id, Commodity commodity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commodity.Id)
            {
                return BadRequest();
            }


            try
            {
                _repo.SaveOrUpdate(commodity, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommodityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = commodity.Id }, commodity);
        }

        // POST: api/Commodities
        [ResponseType(typeof(Commodity))]
        public IHttpActionResult PostCommodity(Commodity commodity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.SaveOrUpdate(commodity, 0);

            return CreatedAtRoute("DefaultApi", new { id = commodity.Id }, commodity);
        }

//        public Commodity PostCommodity(Commodity commodity)
//        {
//            if (!ModelState.IsValid)
//            {
//                var isSaved = _repo.SaveOrUpdate(commodity, commodity.Id);
//                if (isSaved)
//                    return commodity;
//            }
//        } 

        // DELETE: api/Commodities/5
//        [ResponseType(typeof(Commodity))]
//        public IHttpActionResult DeleteCommodity(int id)
//        {
//            Commodity commodity = db.Commodities.Find(id);
//            if (commodity == null)
//            {
//                return NotFound();
//            }
//
//            db.Commodities.Remove(commodity);
//            db.SaveChanges();
//
//            return Ok(commodity);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

        private bool CommodityExists(int id)
        {
            return _repo.Count<Commodity>(id) > 0;
        }
    }
}