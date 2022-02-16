using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCShopERP.Models;
using PCShopERP.Services;
using System.Collections.Generic;
using System.Linq;

namespace PCShopERP.Controllers
{
    public class OrderController : Controller
    {

        public AllPartsService PartsService;
        public IEnumerable<Chassi> Chassis { get; set; }
        public IEnumerable<CPU> CPUs { get; set; }
        public IEnumerable<GPU> GPUs { get; set; }
        public IEnumerable<HDD> HDDs { get; set; }
        public IEnumerable<Motherboard> Motherboards { get; set; }
        public IEnumerable<PSU> PSUs { get; set; }
        public IEnumerable<RAM> RAMs { get; set; }

        public OrdersService OrdersService { get; set; }
        //public PCModel PC { get; set; }
        public InventoryService Inventory { get; set; }

        public OrderController(AllPartsService allPartsService, OrdersService ordersService, InventoryService inventory)
        {
            PartsService = allPartsService;
            OrdersService = ordersService;
            Inventory = inventory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPC()
        {
            Chassis = PartsService.GetChassis();
            CPUs = PartsService.GetCPUs();
            GPUs = PartsService.GetGPUs();
            HDDs = PartsService.GetHDDs();
            Motherboards = PartsService.GetMotherboards();
            PSUs = PartsService.GetPSUs().ToList();
            RAMs = PartsService.GetRAMs().ToList();

            AllComponentsViewModel allComponents = new AllComponentsViewModel();
            allComponents.Chassis = Chassis; 
            allComponents.CPUs = CPUs; 
            allComponents.GPUs = GPUs;
            allComponents.HDDs = HDDs;
            allComponents.Motherboards = Motherboards;
            allComponents.PSUs = PSUs;
            allComponents.RAMs = RAMs;
            
            return View(allComponents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPC(IFormCollection collection)
        {
            PCModel pc = new PCModel();  
            
            pc.Chassi = PartsService.GetChassis().FirstOrDefault(x => x.Id == collection["Id"]);
            pc.CPU = PartsService.GetCPUs().FirstOrDefault(x => x.Id == collection["Id2"]);
            pc.GPU = PartsService.GetGPUs().FirstOrDefault(x => x.Id == collection["Id3"]);
            pc.HDD = PartsService.GetHDDs().FirstOrDefault(x => x.Id == collection["Id4"]);
            pc.Motherboard = PartsService.GetMotherboards().FirstOrDefault(x => x.Id == collection["Id5"]);
            pc.PSU = PartsService.GetPSUs().FirstOrDefault(x => x.Id == collection["Id6"]);
            pc.RAM = PartsService.GetRAMs().FirstOrDefault(x => x.Id == collection["Id7"]);

            OrdersService.AddOrder(pc);

            var inventory = Inventory.GetInventory().ToList();

            if (inventory.Exists(c => c.Id == pc.Chassi.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.Chassi.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.CPU.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.CPU.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.GPU.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.GPU.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.HDD.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.HDD.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.Motherboard.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.Motherboard.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.PSU.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.PSU.Id).Reserved += 1;
            }

            if (inventory.Exists(c => c.Id == pc.RAM.Id))
            {
                inventory.FirstOrDefault(c => c.Id == pc.RAM.Id).Reserved += 1;
            }

            Inventory.UpdateInventory(inventory);

            return View("Index");
        }
    }
}
