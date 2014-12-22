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
    public class VendorCommoditiesController : ApiController
    {
        private readonly IRepository _repo;

        public VendorCommoditiesController()
        {
            _repo = new Repository();
        }

        // GET: api/VendorCommodities
        public IEnumerable<VendorCommodity> GetVendorCommodities()
        {
            return _repo.GetAll<VendorCommodity>();
        }

        // GET: api/VendorCommodities/5
        [ResponseType(typeof(VendorCommodity))]
        public IHttpActionResult GetVendorCommodity(int id)
        {
            VendorCommodity vendorCommodity = _repo.Get<VendorCommodity>(id);
            if (vendorCommodity == null)
            {
                return NotFound();
            }

            return Ok(vendorCommodity);
        }

        // PUT: api/VendorCommodities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendorCommodity(int id, VendorCommodity vendorCommodity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (vendorCommodity.Id <= 0)
                vendorCommodity.CreatedOn = DateTime.Now;
            vendorCommodity.LastModified = DateTime.Now;

            _repo.SaveOrUpdate(vendorCommodity, vendorCommodity.Id);

            return CreatedAtRoute("DefaultApi", new { id = vendorCommodity.Id }, vendorCommodity);
        }

        // POST: api/VendorCommodities
        [ResponseType(typeof(VendorCommodity))]
        public IHttpActionResult PostVendorCommodity(VendorCommodity vendorCommodity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (vendorCommodity.Id <= 0)
                vendorCommodity.CreatedOn = DateTime.Now;
            vendorCommodity.LastModified = DateTime.Now;

            _repo.SaveOrUpdate(vendorCommodity, vendorCommodity.Id);

            return CreatedAtRoute("DefaultApi", new { id = vendorCommodity.Id }, vendorCommodity);
        }

//        // DELETE: api/VendorCommodities/5
//        [ResponseType(typeof(VendorCommodity))]
//        public IHttpActionResult DeleteVendorCommodity(int id)
//        {
//            VendorCommodity vendorCommodity = db.VendorCommodities.Find(id);
//            if (vendorCommodity == null)
//            {
//                return NotFound();
//            }
//
//            db.VendorCommodities.Remove(vendorCommodity);
//            db.SaveChanges();
//
//            return Ok(vendorCommodity);
//        }
//
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

        private bool VendorCommodityExists(int id)
        {
            return  _repo.Count<VendorCommodity>(id)> 0;
        }
    }
}