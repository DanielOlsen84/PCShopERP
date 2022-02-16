using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class PSUController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<PSU> PSUs { get; set; }
        // GET: PSUController

        public PSUController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            PSUs = PartsService.GetPSUs();
            return View(PSUs);
        }

        // GET: PSUController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PSUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PSUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var psu = new PSU();

            Random rnd = new Random();

            psu.Id = rnd.Next(10000000, 99999999).ToString();
            psu.Name = collection["Name"];
            psu.Maker = collection["Maker"];
            psu.Watt = Convert.ToInt32(collection["Watt"]);
            psu.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            psu.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SavePSUs(PSU);
            PartsService.AddPSU(psu);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PSUController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PSUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PSUController/Delete/5
        public ActionResult Delete(string id)
        {
            PSU psu = PartsService.GetPSUs().FirstOrDefault(x => x.Id == id);
            return View(psu);
        }

        // POST: PSUController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeletePSU(id);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
