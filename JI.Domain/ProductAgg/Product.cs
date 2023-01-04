using JI.Domain.Common;
using JI.Domain.InvoiceAgg;

namespace JI.Domain.ProductAgg;

public class Product : EntityBase
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }
}
