using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class CPUController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<CPU> CPUs { get; set; }
        // GET: CPUController
        
        public CPUController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            CPUs = PartsService.GetCPUs();
            return View(CPUs);
        }

        // GET: CPUController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CPUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var cpu = new CPU();

            Random rnd = new Random();

            cpu.Id = rnd.Next(10000000, 99999999).ToString();
            cpu.Name = collection["Name"];
            cpu.Maker = collection["Maker"];
            cpu.GHz = collection["GHz"];
            cpu.Cores = Convert.ToInt32(collection["Cores"]);
            cpu.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            cpu.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveCPUs(cpu);
            PartsService.AddCPU(cpu);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CPUController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CPUController/Edit/5
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

        // GET: CPUController/Delete/5
        public ActionResult Delete(string id)
        {
            CPU cpu = PartsService.GetCPUs().FirstOrDefault(x => x.Id == id);
            return View(cpu);
        }

        // POST: CPUController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeleteCPU(id);

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
