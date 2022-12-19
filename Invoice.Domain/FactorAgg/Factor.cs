using Invoice.Domain.ItemAgg;

namespace Invoice.Domain.FactorAgg
{
    public class Factor : BaseEntity
    {
        public Factor()
        {
            Items = new List<Item>();
        }

        public string Name { get; set; }

        public long Total { get; set; }
        
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public string PhotoUrl { get; set; }

        public string Photo { get; set; }

    }
}
