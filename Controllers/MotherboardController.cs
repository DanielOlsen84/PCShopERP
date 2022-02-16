using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class MotherboardController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<Motherboard> Motherboards { get; set; }
        // GET: MotherboardController

        public MotherboardController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            Motherboards = PartsService.GetMotherboards();
            return View(Motherboards);
        }

        // GET: MotherboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MotherboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotherboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var motherboard = new Motherboard();

            Random rnd = new Random();

            motherboard.Id = rnd.Next(10000000, 99999999).ToString();
            motherboard.Name = collection["Name"];
            motherboard.Maker = collection["Maker"];
            motherboard.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            motherboard.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveMotherboards(Motherboard);
            PartsService.AddMotherboard(motherboard);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MotherboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotherboardController/Edit/5
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

        // GET: MotherboardController/Delete/5
        public ActionResult Delete(string id)
        {
            Motherboard motherboard = PartsService.GetMotherboards().FirstOrDefault(x => x.Id == id);
            return View(motherboard);
        }

        // POST: MotherboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeleteMotherboard(id);

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
