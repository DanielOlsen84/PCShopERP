using PCShopERP.Models;
using PCShopERP.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PCShopERP
{
    public class DataManagement
    {
        public static List<CPU> LoadCPUs()
        {
            return JsonSerializer.Deserialize<List<CPU>>(File.ReadAllText(@"C:\Daniel\VisualStudioProjects\Azure\PCShopERP\wwwroot\data\CPU.json"));
        }
        public static void SaveCPUs(CPU cpu)
        {
            
            var cpus = LoadCPUs();

            cpus.Add(cpu);
            //cpus.Add(new CPU() { Id = "i12", Maker = "Intel", Cores = 6, GHz = 2.8, PurchasePrice = 1300, RetailPrice = 1600 });

            string jsonString = JsonSerializer.Serialize(cpus);
            File.WriteAllText(@"C:\Daniel\VisualStudioProjects\Azure\PCShopERP\wwwroot\data\CPU.json", jsonString);
        }
    }
}
