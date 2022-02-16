using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System.Collections.Generic;
using System.Linq;
using static PCShopERP.Models.InventoryObject;

namespace PCShopERP.Controllers
{
    public class InventoryController : Controller
    {
        public InventoryService Inventory;
        public IEnumerable<InventoryObject> AllInventoryObjects { get; set; }
        
        public AllPartsService PartsService;

        public IEnumerable<Chassi> Chassis { get; set; }
        public IEnumerable<CPU> CPUs { get; set; }
        public IEnumerable<GPU> GPUs { get; set; }
        public IEnumerable<HDD> HDDs { get; set; }
        public IEnumerable<Motherboard> Motherboards { get; set; }
        public IEnumerable<PSU> PSUs { get; set; }
        public IEnumerable<RAM> RAMs { get; set; }
        // GET: CPUController

        public InventoryController(InventoryService inventory, AllPartsService allPartsService)
        {
            Inventory = inventory;
            PartsService = allPartsService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        // GET: InventoryController
        public ActionResult ViewInventory()
        {
            Inventory.UpdateInventoryAgainstOrders();
            var inventory = Inventory.GetInventory();
            return View(inventory);
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create(string id)
        {
            Chassis = PartsService.GetChassis();
            CPUs = PartsService.GetCPUs();
            GPUs = PartsService.GetGPUs();
            HDDs = PartsService.GetHDDs();
            Motherboards = PartsService.GetMotherboards();
            PSUs = PartsService.GetPSUs();
            RAMs = PartsService.GetRAMs();

            InventoryObject newObject = new InventoryObject() { Id = id };
            bool cFound = false;

            foreach (var c in Chassis)
            {
                if (c.Id == newObject.Id)
                {
                    newObject.Name = c.Name;
                    newObject.Maker = c.Maker;
                    newObject.Type = ComponentType.Chassi;
                    cFound = true;
                }
            }

            if (!cFound)
            {
                foreach (var c in CPUs)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.CPU;
                        cFound = true;
                    }
                }
            }

            if (!cFound)
            {
                foreach (var c in GPUs)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.GPU;
                        cFound = true;
                    }
                }
            }

            if (!cFound)
            {
                foreach (var c in HDDs)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.HDD;
                        cFound = true;
                    }
                }
            }

            if (!cFound)
            {
                foreach (var c in Motherboards)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.Motherboard;
                        cFound = true;
                    }
                }
            }

            if (!cFound)
            {
                foreach (var c in PSUs)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.PSU;
                        cFound = true;
                    }
                }
            }

            if (!cFound)
            {
                foreach (var c in RAMs)
                {
                    if (c.Id == newObject.Id)
                    {
                        newObject.Name = c.Name;
                        newObject.Maker = c.Maker;
                        newObject.Type = ComponentType.RAM;
                        cFound = true;
                    }
                }
            }

            Inventory.AddInventoryObject(newObject);
            return RedirectToAction("Index");
        }

        // POST: InventoryController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(string id)
        //{
        //    Chassis = PartsService.GetChassis();
        //    CPUs = PartsService.GetCPUs();
        //    GPUs = PartsService.GetGPUs();
        //    HDDs = PartsService.GetHDDs();
        //    Motherboards = PartsService.GetMotherboards();
        //    PSUs = PartsService.GetPSUs();
        //    RAMs = PartsService.GetRAMs();

        //    InventoryObject newObject = new InventoryObject() { Id = id };
        //    bool cFound = false;

        //    foreach (var c in Chassis)
        //    {
        //        if (c.Id == newObject.Id)
        //        {
        //            newObject.Name = c.Name;
        //            newObject.Maker = c.Maker;
        //            newObject.Type = ComponentType.Chassi;
        //            cFound = true;
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in CPUs)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.CPU;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in GPUs)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.GPU;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in HDDs)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.HDD;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in Motherboards)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.Motherboard;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in PSUs)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.PSU;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    if (!cFound)
        //    {
        //        foreach (var c in RAMs)
        //        {
        //            if (c.Id == newObject.Id)
        //            {
        //                newObject.Name = c.Name;
        //                newObject.Maker = c.Maker;
        //                newObject.Type = ComponentType.RAM;
        //                cFound = true;
        //            }
        //        }
        //    }

        //    Inventory.AddInventoryObject(newObject);

        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
