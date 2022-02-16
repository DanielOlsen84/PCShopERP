namespace PCShopERP.Models
{
    //HARD DISK DRIVE
    public class HDD
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public double RPM { get; set; }
        public int Size { get; set; }
        public int PurchasePrice { get; set; }
        public int RetailPrice { get; set; }
    }
}
