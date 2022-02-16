using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class HDDController : Controller
    {
        public AllPartsService PartsService;
        public IEnumerable<HDD> HDDs { get; set; }
        // GET: HDDController

        public HDDController(AllPartsService allPartsService)
        {
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            HDDs = PartsService.GetHDDs();
            return View(HDDs);
        }

        // GET: HDDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HDDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HDDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //return Ok(collection["Id"]);

            var hdd = new HDD();

            Random rnd = new Random();

            hdd.Id = rnd.Next(10000000, 99999999).ToString();
            hdd.Name = collection["Name"];
            hdd.Maker = collection["Maker"];
            hdd.Size = Convert.ToInt32(collection["Size"]);
            hdd.RPM = Convert.ToInt32(collection["RPM"]);
            hdd.PurchasePrice = Convert.ToInt32(collection["PurchasePrice"]);
            hdd.RetailPrice = Convert.ToInt32(collection["RetailPrice"]);

            //DataManagement.SaveHDDs(HDD);
            PartsService.AddHDD(hdd);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HDDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HDDController/Edit/5
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

        // GET: HDDController/Delete/5
        public ActionResult Delete(string id)
        {
            HDD hdd = PartsService.GetHDDs().FirstOrDefault(x => x.Id == id);
            return View(hdd);
        }

        // POST: HDDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection ifc)
        {
            //HDD hdd = PartsService.GetHDDs().FirstOrDefault(x => x.Id == id);
            PartsService.DeleteHDD(id);

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
