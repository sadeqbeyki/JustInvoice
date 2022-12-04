using Invoice.Domain.ItemAgg;

namespace Invoice.Domain.ProductAgg;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }
}
