using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;

namespace Invoice.ApplicationContracts.Items;

public class ItemDto
{
    public long Id { get; set; }
    public string CreationDate { get; set; }
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    //public List<ProductViewModel> Products { get; set; }
    public long UnitId { get; set; }
    public string UnitName { get; set; }
    //public List<UnitViewModel> Units { get; set; }
    public long FactorId { get; set; }


}
