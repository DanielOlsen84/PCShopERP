namespace PCShopERP.Models
{
    public class InventoryObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public ComponentType Type { get; set; }
        public int InStore { get; set; }
        public int Reserved { get; set; }

        public enum ComponentType
        {
            Chassi,
            CPU,
            GPU,
            HDD,
            Motherboard,
            PSU,
            RAM
        }
    }
}
