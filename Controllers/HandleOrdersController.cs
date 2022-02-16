using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static PCShopERP.Models.InventoryObject;

namespace PCShopERP.Controllers
{
    public class HandleOrdersController : Controller
    {
        public OrdersService AllOrders { get; set; }
        public InventoryService AllInventory { get; set; }

        public HandleOrdersController(OrdersService orders, InventoryService inventory)
        {
            AllOrders = orders;
            AllInventory = inventory;
        }

        // GET: HandleOrdersController
        public ActionResult Index()
        {
            var orders = AllOrders.GetOrders();
            return View(orders);
        }

        public ActionResult ViewOrderedComponents()
        {
            var orders = AllOrders.GetOrders();

            List<InventoryObject> components = new List<InventoryObject>();
            foreach (var pc in orders)
            {
                if (components.Exists(c => c.Id == pc.Chassi.Id))
                {
                    components.Find(c => c.Id == pc.Chassi.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.Chassi.Id, Maker = pc.Chassi.Maker, Name = pc.Chassi.Name, Type = ComponentType.Chassi, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.CPU.Id))
                {
                    components.Find(c => c.Id == pc.CPU.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.CPU.Id, Maker = pc.CPU.Maker, Name = pc.CPU.Name, Type = ComponentType.CPU, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.GPU.Id))
                {
                    components.Find(c => c.Id == pc.GPU.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.GPU.Id, Maker = pc.GPU.Maker, Name = pc.GPU.Name, Type = ComponentType.GPU, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.HDD.Id))
                {
                    components.Find(c => c.Id == pc.HDD.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.HDD.Id, Maker = pc.HDD.Maker, Name = pc.HDD.Name, Type = ComponentType.HDD, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.Motherboard.Id))
                {
                    components.Find(c => c.Id == pc.Motherboard.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.Motherboard.Id, Maker = pc.Motherboard.Maker, Name = pc.Motherboard.Name, Type = ComponentType.Motherboard, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.PSU.Id))
                {
                    components.Find(c => c.Id == pc.PSU.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.PSU.Id, Maker = pc.PSU.Maker, Name = pc.PSU.Name, Type = ComponentType.PSU, Reserved = 1 });
                }

                if (components.Exists(c => c.Id == pc.RAM.Id))
                {
                    components.Find(c => c.Id == pc.RAM.Id).Reserved += 1;
                }
                else
                {
                    components.Add(new InventoryObject() { Id = pc.RAM.Id, Maker = pc.RAM.Maker, Name = pc.RAM.Name, Type = ComponentType.RAM, Reserved = 1 });
                }
                
            }

            var inventory = AllInventory.GetInventory();
            foreach(var c in components)
            {
                if (inventory.Any(x => x.Id == c.Id))
                {
                    c.InStore = inventory.FirstOrDefault(x => x.Id == c.Id).InStore;
                }
            }

            return View(components);
        }

        // GET: HandleOrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HandleOrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HandleOrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: HandleOrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HandleOrdersController/Edit/5
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

        // GET: HandleOrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HandleOrdersController/Delete/5
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
