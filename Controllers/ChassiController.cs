using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers

{
    public class ChassiController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<Chassi> Chassis { get; set; }
        // GET: ChassiController

        public ChassiController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            Chassis = PartsService.GetChassis();
            return View(Chassis);
        }

        // GET: ChassiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChassiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChassiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var chassi = new Chassi();

            Random rnd = new Random();

            chassi.Id = rnd.Next(10000000, 99999999).ToString();
            chassi.Name = collection["Name"];
            chassi.Maker = collection["Maker"];
            chassi.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            chassi.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveChassis(Chassi);
            PartsService.AddChassi(chassi);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChassiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChassiController/Edit/5
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

        // GET: ChassiController/Delete/5
        public ActionResult Delete(string id)
        {
            Chassi chassi = PartsService.GetChassis().FirstOrDefault(x => x.Id == id);
            return View(chassi);
        }

        // POST: ChassiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeleteChassi(id);

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
