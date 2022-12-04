﻿
using Invoice.Domain.ItemAgg;

namespace Invoice.Domain.FactorAgg
{
    public class Factor : BaseEntity
    {
        public string Name { get; set; }
        public long Total { get; set; }
        public string Description { get; set; }
        public long ItemId { get; set; }
        public List<Item> Items { get; set; }

    }
}
