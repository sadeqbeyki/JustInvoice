using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor
{
    public class FactorItemDto
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string Name { get; set; }
        public long Total { get; set; }
        public string Description { get; set; }
        public List<ItemDto> Items { get; set; }
        //public long ItemId { get; set; }
        public long Price { get; set; }
        public long Count { get; set; }
        public long Sum { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
