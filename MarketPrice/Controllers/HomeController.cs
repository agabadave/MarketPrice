using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPrice.Models;
using MarketPrice.Repositories;

namespace MarketPrice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController()
        {
            _repo = new Repository();
            
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var markets = _repo.GetAll<Market>();

            return View(markets);
        }

        public ActionResult Market(int id)
        {
            var market = _repo.Get<Market>(id);
            return View(market);
        }

        public ActionResult Vendor(int id)
        {
            var vendor = _repo.Get<Vendor>(id);
            return View(vendor);
        }

        public ActionResult EditVendor( int marketId, int id = 0)
        {
            var vendor = new Vendor();
            if (id > 0)
                vendor = _repo.Get<Vendor>(id);

            vendor.MarketId = marketId;

            return View(vendor);
        }

        [HttpPost]
        public ActionResult EditVendor(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                var isSaved = _repo.SaveOrUpdate<Vendor>(vendor, vendor.Id);
                if (isSaved)
                    return RedirectToAction("Market", new {Id = vendor.MarketId});
            }

            ModelState.AddModelError("", "Something went wrong while saving the changes.");
            return View(model: vendor);
        }

        public ActionResult EditCommodityVendor(int vendorId, int id = 0)
        {
            var model = new VendorCommodity();
            if (id > 0)
                model = _repo.Get<VendorCommodity>(id);

            ViewBag.Commodities =
                _repo.GetAll<Commodity>().Select(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()});

            model.VendorId = vendorId;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCommodityVendor(VendorCommodity model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id <= 0 || model.CreatedOn == DateTime.MinValue)
                    model.CreatedOn = DateTime.Now;
                model.LastModified = DateTime.Now;

                var isSaved = _repo.SaveOrUpdate<VendorCommodity>(model, model.Id);
                if (isSaved)
                    return RedirectToAction("Vendor", new {id = model.VendorId});

            }

            ViewBag.Commodities =
               _repo.GetAll<Commodity>().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            ModelState.AddModelError("", "Could not Save something went wrong");
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Commodities()
        {
            var model = _repo.GetAll<Commodity>();
            return View(model);
        }

        public ActionResult EditCommodity(int id = 0)
        {
            var model = new Commodity();
            if (id > 0)
                model = _repo.Get<Commodity>(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCommodity(Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                var isSaved = _repo.SaveOrUpdate(commodity, commodity.Id);
                if (isSaved)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(" ", "Could not Save Changes. Something went wrong");
            return View(commodity);
        }
    }
}
