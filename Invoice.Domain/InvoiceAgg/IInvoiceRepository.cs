using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;

namespace Invoice.Domain.InvoiceAgg;

public interface IInvoiceRepository : IBaseRepository<long, Invoice>
{
    InvoiceDto GetDetails(long id);
    InvoiceDto GetInvoice(long id);
    List<InvoiceDto> GetInvoices();
    List<ItemDto> GetItems(long id);
    Invoice GetInvoiceWithItems(long id);
    IQueryable<Item> GetItem(long id);

}