using AppFramework;
using Invoice.ApplicationContracts.Items;
using Invoice.DAL.Common;
using Invoice.Domain.ItemAgg;

namespace Invoice.DAL.Persistance;

public class ItemRepository : BaseRepository<long, Item>, IItemRepository
{
    private readonly InvoiceContext _invoiceContext;

    public ItemRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public EditItem GetDetails(long id)
    {
        return _invoiceContext.Items
            .Select(x => new EditItem()
            {
                Id = x.Id,
                Price = x.Price,
                Count = x.Count,
                Sum = x.Sum,
            }).FirstOrDefault(x => x.Id == id);
    }

    public List<ItemDto> GetItems()
    {
        return _invoiceContext.Items.Select(c => new ItemDto
        {
            Id = c.Id,
            Product = c.Product.Name.ToString(),
            Unit = c.Unit.Name.ToString(),
            Price = c.Price,
            Count = c.Count,
            Sum = c.Sum,
            CreationDate = c.CreationDate.ToFarsi()
        }).ToList();
    }
}
