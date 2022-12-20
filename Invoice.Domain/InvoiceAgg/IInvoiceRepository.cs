using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;

namespace Invoice.Domain.InvoiceAgg;

public interface IInvoiceRepository : IBaseRepository<long, Invoice>
{
    InvoiceDto GetDetails(long id);
    InvoiceDto GetDelete(long id);

    InvoiceDto GetInvoice(long id);
    List<InvoiceDto> GetInvoices();
    List<ItemDto> GetItems(long id);
}