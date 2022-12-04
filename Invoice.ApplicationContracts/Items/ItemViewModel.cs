namespace Invoice.ApplicationContracts.Items;

public class ItemViewModel
{
    public long Id { get; set; }
    public string CreationDate { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long Total { get; set; }
    public string Description { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public long UnitId { get; set; }
    public string UnitName { get; set; }
}
