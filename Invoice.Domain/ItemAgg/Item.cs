﻿using Invoice.Domain.ProductAgg;
using Invoice.Domain.UnitAgg;

namespace Invoice.Domain.ItemAgg
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public long Count { get; set; }
        public long Sum { get; set; }
        public long Total { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }
        public Product ProductName { get; set; }
        public long UnitId { get; set; }
        public Unit UnitName { get; set; }
    }
}
