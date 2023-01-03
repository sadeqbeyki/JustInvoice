using JI.Domain.Common;
using JI.Domain.InvoiceAgg;

namespace JI.Domain.UnitAgg;

public class Unit : BaseEntity
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }

}
