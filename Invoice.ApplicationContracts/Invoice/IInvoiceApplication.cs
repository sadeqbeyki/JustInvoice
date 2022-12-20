using AppFramework;
using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Invoice;

public interface IInvoiceApplication
{
    OperationResult Create(InvoiceDto command);
    OperationResult Update(InvoiceDto command);
    InvoiceDto GetDetails(long id);
    InvoiceDto GetDelete(long id);
    InvoiceDto GetInvoice(long id);
    List<ItemDto> GetItems(long id);
    List<InvoiceDto> GetInvoices();

    void Delete(int key);

}
