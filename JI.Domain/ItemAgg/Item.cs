using JI.Domain.ProductAgg;
using JI.Domain.UnitAgg;
using System.ComponentModel.DataAnnotations.Schema;

namespace JI.Domain.ItemAgg;

public class Item : BaseEntity
{
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long UnitId { get; set; }
    public Unit Unit { get; set; }
    public long InvoiceId { get; set; }
    public InvoiceAgg.Invoice Invoice { get; set; }
    [NotMapped]
    public bool IsDeleted { get; set; } = false;
}
