namespace PCShopERP.Models
{
    //CENTRAL PROCESSING UNIT
    public class CPU
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public string GHz { get; set; }
        public int Cores { get; set; }
        public int PurchasePrice { get; set; }
        public int RetailPrice { get; set; }
    }
}
