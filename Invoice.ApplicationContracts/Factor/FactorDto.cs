using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public class FactorDto
{
    public long Id { get; set; }
    public string CreationDate { get; set; }
    public string Name { get; set; }
    public long Total { get; set; }
    public string Description { get; set; }
    public List<ItemDto> Items { get; set; } = new List<ItemDto>();
}