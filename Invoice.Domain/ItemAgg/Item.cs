using Invoice.Domain.FactorAgg;
using Invoice.Domain.ProductAgg;
using Invoice.Domain.UnitAgg;

namespace Invoice.Domain.ItemAgg
{
    public class Item : BaseEntity
    {
        public long Price { get; set; }
        public long Count { get; set; }
        public long Sum { get; set; }
        public long ProductId { get; set; }
        public Product ProductName { get; set; }
        public long UnitId { get; set; }
        public Unit UnitName { get; set; }
        public long FactorId { get; set; }
        public Factor FactorName { get; set; }
    }
}
