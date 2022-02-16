namespace PCShopERP.Models
{
    //POWER SUPPLY UNIT
    public class PSU
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public int Watt { get; set; }
        public int PurchasePrice { get; set; }
        public int RetailPrice { get; set; }
    }
}
