using AppFramework;

namespace JI.ApplicationContracts.Invoice;

public interface IInvoiceApplication
{
    OperationResult Create(InvoiceDto command);
    OperationResult Update(InvoiceDto command);
    InvoiceDto GetDetails(long id);
    List<InvoiceDto> GetInvoices();
    OperationResult Delete(long id);
    OperationResult Edit(InvoiceDto model);

}