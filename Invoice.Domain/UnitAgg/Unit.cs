using Invoice.Domain.ItemAgg;

namespace Invoice.Domain.UnitAgg;

public class Unit : BaseEntity
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }

}
