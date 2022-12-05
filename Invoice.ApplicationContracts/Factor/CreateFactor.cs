using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public class CreateFactor
{
    public string CreationDate { get; set; }
    public string Name { get; set; }
    public long Total { get; set; }
    public string Description { get; set; }
    public List<ItemDto> Items { get; set; }
}
