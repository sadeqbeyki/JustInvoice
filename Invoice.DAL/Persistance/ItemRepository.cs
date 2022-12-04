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
                Name = x.Name,
                Price = x.Price,
                Count = x.Count,
                Sum = x.Sum,
                Description = x.Description,

            }).FirstOrDefault(x => x.Id == id);
    }

    public List<ItemViewModel> GetItems()
    {
        return _invoiceContext.Items.Select(c => new ItemViewModel
        {
            Id = c.Id,
            ProductName = c.ProductName.Name.ToString(),
            UnitName = c.UnitName.Name.ToString(),
            Name = c.Name,
            Price = c.Price,
            Count = c.Count,
            Sum = c.Sum,
            Description = c.Description,
            CreationDate = c.CreationDate.ToFarsi()
        }).ToList();
    }
}
