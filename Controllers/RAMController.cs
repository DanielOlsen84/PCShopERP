using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class RAMController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<RAM> RAMs { get; set; }
        // GET: RAMController

        public RAMController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            RAMs = PartsService.GetRAMs();
            return View(RAMs);
        }

        // GET: RAMController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RAMController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAMController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var ram = new RAM();

            Random rnd = new Random();

            ram.Id = rnd.Next(10000000, 99999999).ToString();
            ram.Name = collection["Name"];
            ram.Maker = collection["Maker"];
            ram.DDR = Convert.ToInt32(collection["DDR"]);
            ram.Memory = Convert.ToInt32(collection["Memory"]);
            ram.MHz = Convert.ToInt32(collection["MHz"]);
            ram.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            ram.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveRAMs(RAM);
            PartsService.AddRAM(ram);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RAMController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RAMController/Edit/5
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

        // GET: RAMController/Delete/5
        public ActionResult Delete(string id)
        {
            RAM ram = PartsService.GetRAMs().FirstOrDefault(x => x.Id == id);
            return View(ram);
        }

        // POST: RAMController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeleteRAM(id);

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
