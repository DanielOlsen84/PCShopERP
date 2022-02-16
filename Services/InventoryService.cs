using Microsoft.AspNetCore.Hosting;

using PCShopERP.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PCShopERP.Services
{
    public class InventoryService
    {
        
        public InventoryService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<InventoryObject> GetInventory()
        {
            var inventory = JsonSerializer.Deserialize<List<InventoryObject>>(File.ReadAllText("wwwroot/data/Inventory.json"));
            return inventory;
        }

        public void AddInventoryObject(InventoryObject inventoryObject)
        {
            List<InventoryObject> inventory = GetInventory().ToList();

            if (inventory.Find(x => x.Id == inventoryObject.Id) != null)
            {
                inventory.FirstOrDefault(x => x.Id == inventoryObject.Id).InStore += 1;
            }
            else
            {
                InventoryObject newObject = new InventoryObject() { Id = inventoryObject.Id, Name = inventoryObject.Name, Maker = inventoryObject.Maker, Type = inventoryObject.Type, InStore = 1, Reserved = 0};
                inventory.Add(newObject);
            }

            string jsonString = JsonSerializer.Serialize(inventory, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Inventory.json", jsonString);
        }

        
        public void UpdateInventory(List<InventoryObject> newInventory)
        {
            //List<InventoryObject> inventory = GetInventory().ToList();

            //if (inventory.Find(x => x.Id == inventoryObject.Id) != null)
            //{
            //    inventory.FirstOrDefault(x => x.Id == inventoryObject.Id).InStore += 1;
            //}
            //else
            //{
            //    InventoryObject newObject = new InventoryObject() { Id = inventoryObject.Id, Name = inventoryObject.Name, Maker = inventoryObject.Maker, Type = inventoryObject.Type, InStore = 1, Reserved = 0 };
            //    inventory.Add(newObject);
            //}

            string jsonString = JsonSerializer.Serialize(newInventory, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Inventory.json", jsonString);
        }
        
        public void UpdateInventoryAgainstOrders()
        {
            
            var orders = JsonSerializer.Deserialize<List<PCModel>>(File.ReadAllText("wwwroot/data/Orders.json"));

            var inventory = GetInventory().ToList();

            foreach (var c in inventory)
            {
                c.Reserved = 0;
            }

            foreach (var pc in orders)
            {
                if (inventory.Exists(io => io.Id == pc.Chassi.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.Chassi.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.CPU.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.CPU.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.GPU.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.GPU.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.HDD.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.HDD.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.Motherboard.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.Motherboard.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.PSU.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.PSU.Id).Reserved += 1;
                }

                if (inventory.Exists(io => io.Id == pc.RAM.Id))
                {
                    inventory.FirstOrDefault(io => io.Id == pc.RAM.Id).Reserved += 1;
                }
            }

            string jsonString = JsonSerializer.Serialize(inventory, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Inventory.json", jsonString);

        }
    }
}
