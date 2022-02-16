using Microsoft.AspNetCore.Hosting;
using PCShopERP.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PCShopERP.Services
{
    public class AllPartsService
    {
        
        public AllPartsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<CPU> GetCPUs()
        {
            var CPUs = JsonSerializer.Deserialize<List<CPU>>(File.ReadAllText("wwwroot/data/CPU.json"));
            return CPUs;
        }

        public void AddCPU(CPU cpu)
        {
            List<CPU> cpus = GetCPUs().ToList();

            CPU newCPU = new CPU() { Id = cpu.Id, Name = cpu.Name, Maker = cpu.Maker, GHz = cpu.GHz, Cores = cpu.Cores, PurchasePrice = cpu.PurchasePrice, RetailPrice = cpu.RetailPrice };
            
            cpus.Add(newCPU);

            string jsonString = JsonSerializer.Serialize(cpus, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/CPU.json", jsonString);
        }

        public void DeleteCPU(string Id)
        {

            List<CPU> CPUs = GetCPUs().ToList();
            CPU cpu = CPUs.FirstOrDefault(x => x.Id == Id);
            CPUs.Remove(cpu);

            string jsonString = JsonSerializer.Serialize(CPUs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/CPU.json", jsonString);
        }

        public IEnumerable<GPU> GetGPUs()
        {
            var GPUs = JsonSerializer.Deserialize<List<GPU>>(File.ReadAllText("wwwroot/data/GPU.json"));
            return GPUs;
        }

        public void AddGPU(GPU gpu)
        {
            List<GPU> gpus = GetGPUs().ToList();

            GPU newGPU = new GPU() { Id = gpu.Id, Name = gpu.Name, Maker = gpu.Maker, Memory = gpu.Memory, PurchasePrice = gpu.PurchasePrice, RetailPrice = gpu.RetailPrice };

            gpus.Add(newGPU);

            string jsonString = JsonSerializer.Serialize(gpus, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/GPU.json", jsonString);
        }

        public void DeleteGPU(string Id)
        {

            List<GPU> GPUs = GetGPUs().ToList();
            GPU gpu = GPUs.FirstOrDefault(x => x.Id == Id);
            GPUs.Remove(gpu);

            string jsonString = JsonSerializer.Serialize(GPUs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/GPU.json", jsonString);
        }

        public IEnumerable<Chassi> GetChassis()
        {
            var Chassis = JsonSerializer.Deserialize<List<Chassi>>(File.ReadAllText("wwwroot/data/Chassi.json"));
            return Chassis;
        }
        public void AddChassi(Chassi chassi)
        {
            List<Chassi> chassis = GetChassis().ToList();

            Chassi newChassi = new Chassi() { Id = chassi.Id, Name = chassi.Name, Maker = chassi.Maker, PurchasePrice = chassi.PurchasePrice, RetailPrice = chassi.RetailPrice };

            chassis.Add(newChassi);

            string jsonString = JsonSerializer.Serialize(chassis, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Chassi.json", jsonString);
        }
        public void DeleteChassi(string Id)
        {

            List<Chassi> Chassis = GetChassis().ToList();
            Chassi chassi = Chassis.FirstOrDefault(x => x.Id == Id);
            Chassis.Remove(chassi);

            string jsonString = JsonSerializer.Serialize(Chassis, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Chassi.json", jsonString);
        }
        public IEnumerable<HDD> GetHDDs()
        {

            var HDDs = JsonSerializer.Deserialize<List<HDD>>(File.ReadAllText("wwwroot/data/HDD.json"));
            return HDDs;
            
        }

        public void AddHDD(HDD hdd)
        {
            List<HDD> HDDs = GetHDDs().ToList();

            HDD newHDD = new HDD() { Id = hdd.Id, Name = hdd.Name, Maker = hdd.Maker, Size = hdd.Size, RPM = hdd.RPM, PurchasePrice = hdd.PurchasePrice, RetailPrice = hdd.RetailPrice };

            HDDs.Add(newHDD);

            string jsonString = JsonSerializer.Serialize(HDDs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/HDD.json", jsonString);
            
        }

        public void DeleteHDD(string Id)
        {

            List<HDD> HDDs = GetHDDs().ToList();
            HDD hdd = HDDs.FirstOrDefault(x => x.Id == Id);
            HDDs.Remove(hdd);

            string jsonString = JsonSerializer.Serialize(HDDs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/HDD.json", jsonString);
        }


        public IEnumerable<Motherboard> GetMotherboards()
        {
            var Motherboards = JsonSerializer.Deserialize<List<Motherboard>>(File.ReadAllText("wwwroot/data/Motherboard.json"));
            return Motherboards;
        }

        public void AddMotherboard(Motherboard motherboard)
        {
            List<Motherboard> Motherboards = GetMotherboards().ToList();

            Motherboard newMotherboard = new Motherboard() { Id = motherboard.Id, Name = motherboard.Name, Maker = motherboard.Maker, PurchasePrice = motherboard.PurchasePrice, RetailPrice = motherboard.RetailPrice };

            Motherboards.Add(newMotherboard);

            string jsonString = JsonSerializer.Serialize(Motherboards, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Motherboard.json", jsonString);
        }
        public void DeleteMotherboard(string Id)
        {

            List<Motherboard> motherboards = GetMotherboards().ToList();
            Motherboard motherboard = motherboards.FirstOrDefault(x => x.Id == Id);
            motherboards.Remove(motherboard);

            string jsonString = JsonSerializer.Serialize(motherboards, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/Motherboard.json", jsonString);
        }
        public IEnumerable<PSU> GetPSUs()
        {
            var PSUs = JsonSerializer.Deserialize<List<PSU>>(File.ReadAllText("wwwroot/data/PSU.json"));
            return PSUs;
        }

        public void AddPSU(PSU psu)
        {
            List<PSU> PSUs = GetPSUs().ToList();

            PSU newPSU = new PSU() { Id = psu.Id, Name = psu.Name, Maker = psu.Maker, Watt = psu.Watt, PurchasePrice = psu.PurchasePrice, RetailPrice = psu.RetailPrice };

            PSUs.Add(newPSU);

            string jsonString = JsonSerializer.Serialize(PSUs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/PSU.json", jsonString);
        }
        public void DeletePSU(string Id)
        {

            List<PSU> PSUs = GetPSUs().ToList();
            PSU psu = PSUs.FirstOrDefault(x => x.Id == Id);
            PSUs.Remove(psu);

            string jsonString = JsonSerializer.Serialize(PSUs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/PSU.json", jsonString);
        }
        public IEnumerable<RAM> GetRAMs()
        {
            var RAMs = JsonSerializer.Deserialize<List<RAM>>(File.ReadAllText("wwwroot/data/RAM.json"));
            return RAMs;
        }

        public void AddRAM(RAM ram)
        {
            List<RAM> rams = GetRAMs().ToList();

            RAM newRAM = new RAM() { Id = ram.Id, Name = ram.Name, Maker = ram.Maker, Memory = ram.Memory, DDR = ram.DDR, MHz = ram.MHz, PurchasePrice = ram.PurchasePrice, RetailPrice = ram.RetailPrice };

            rams.Add(newRAM);

            string jsonString = JsonSerializer.Serialize(rams, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/RAM.json", jsonString);
        }
        public void DeleteRAM(string Id)
        {

            List<RAM> RAMs = GetRAMs().ToList();
            RAM ram = RAMs.FirstOrDefault(x => x.Id == Id);
            RAMs.Remove(ram);

            string jsonString = JsonSerializer.Serialize(RAMs, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("wwwroot/data/RAM.json", jsonString);
        }

    }
}
