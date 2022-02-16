using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class GPUController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<GPU> GPUs { get; set; }
        // GET: CPUController

        public GPUController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            GPUs = PartsService.GetGPUs();
            return View(GPUs);
        }

        // GET: GPUController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GPUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GPUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var gpu = new GPU();

            Random rnd = new Random();

            gpu.Id = rnd.Next(10000000, 99999999).ToString();
            gpu.Name = collection["Name"];
            gpu.Maker = collection["Maker"];
            gpu.Memory = Convert.ToInt32(collection["Memory"]);
            gpu.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            gpu.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveCPUs(cpu);
            PartsService.AddGPU(gpu);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GPUController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GPUController/Edit/5
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

        // GET: GPUController/Delete/5
        public ActionResult Delete(string id)
        {
            GPU gpu = PartsService.GetGPUs().FirstOrDefault(x => x.Id == id);
            return View(gpu);
        }

        // POST: GPUController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            PartsService.DeleteGPU(id);

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
