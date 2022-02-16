using Microsoft.AspNetCore.Hosting;
using PCShopERP.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PCShopERP.Services
{
    public class OrdersService
    {
        public OrdersService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<PCModel> GetOrders()
        {
            using (var jsonFileReader = File.OpenText(Path.Combine(WebHostEnvironment.WebRootPath, "data", "Orders.json")))
            {
                return JsonSerializer.Deserialize<PCModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddOrder(PCModel pc)
        {
            List<PCModel> PCs = GetOrders().ToList();

            PCModel newPC = new PCModel() { Chassi = pc.Chassi, CPU = pc.CPU, GPU = pc.GPU, HDD = pc.HDD, Motherboard = pc.Motherboard, PSU = pc.PSU, RAM = pc.RAM };

            PCs.Add(newPC);

            using (var outputStream = File.OpenWrite(Path.Combine(WebHostEnvironment.WebRootPath, "data", "Orders.json")))
            {
                JsonSerializer.Serialize<List<PCModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    PCs
                );
            }
        }
    }
}
