using JI.DomainContracts.Common;
using JI.DomainContracts.Invoices;

namespace JI.Domain.InvoiceAgg;

public interface IInvoiceRepository : IBaseRepository<long, Invoice>
{
    InvoiceDto GetDetails(long id);
    List<InvoiceDto> GetInvoices();
    void DelEdit(InvoiceDto invoice);
    void AddEdit(Invoice invoice);

}