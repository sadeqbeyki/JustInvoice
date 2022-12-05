using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public class FactorViewModel
{
    public long Id { get; set; }
    public string CreationDate { get; set; }
    public string Name { get; set; }
    public long Total { get; set; }
    public string Description { get; set; }
    public List<ItemViewModel> Items { get; set; }
}
