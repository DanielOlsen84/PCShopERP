using System.Collections.Generic;

namespace PCShopERP.Models
{
    public class AllComponentsViewModel
    {
       
        public IEnumerable<Chassi> Chassis { get; set; }
        public IEnumerable<CPU> CPUs { get; set; }
        public IEnumerable<GPU> GPUs { get; set; }
        public IEnumerable<HDD> HDDs { get; set; }
        public IEnumerable<Motherboard> Motherboards { get; set; }
        public IEnumerable<PSU> PSUs { get; set; }
        public IEnumerable<RAM> RAMs { get; set; }
       
    }
}
