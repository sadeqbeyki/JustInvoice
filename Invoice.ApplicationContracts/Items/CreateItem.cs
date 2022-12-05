using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;

namespace Invoice.ApplicationContracts.Items;

public class CreateItem
{
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public List<ProductViewModel> Products { get; set; }
    public long UnitId { get; set; }
    public List<UnitViewModel> Units { get; set; }
    public long FactorId { get; set; }
}