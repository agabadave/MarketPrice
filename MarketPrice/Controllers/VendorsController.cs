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
    public class VendorsController : ApiController
    {
        private readonly IRepository _repo;

        public VendorsController()
        {
            _repo = new Repository();
        }

        // GET: api/Vendors
        public IEnumerable<Vendor> GetVendors()
        {
            return _repo.GetAll<Vendor>();
        }

        // GET: api/Vendors/5
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult GetVendor(int id)
        {
            Vendor vendor = _repo.Get<Vendor>(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        public IHttpActionResult GetVendor(string username, string password)
        {
            var vendor = _repo.GetVendor(username, password);
            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }

        // PUT: api/Vendors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendor(int id, Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.SaveOrUpdate(vendor, vendor.Id);

            return CreatedAtRoute("DefaultApi", new { id = vendor.Id }, vendor);
        }

        // POST: api/Vendors
        [ResponseType(typeof(Vendor))]
        public IHttpActionResult PostVendor(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.SaveOrUpdate(vendor, vendor.Id);

            return CreatedAtRoute("DefaultApi", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
//        [ResponseType(typeof(Vendor))]
//        public IHttpActionResult DeleteVendor(int id)
//        {
//            Vendor vendor = db.Vendors.Find(id);
//            if (vendor == null)
//            {
//                return NotFound();
//            }
//
//            db.Vendors.Remove(vendor);
//            db.SaveChanges();
//
//            return Ok(vendor);
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

        private bool VendorExists(int id)
        {
            return _repo.Count<Vendor>(id) > 0;
        }
    }
}