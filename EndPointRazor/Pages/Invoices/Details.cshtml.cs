using JI.DomainContracts.Invoices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPointRazor.Pages.Invoices;

public class DetailsModel : PageModel
{
    public InvoiceDto Invoice { get; set; } = new InvoiceDto();
    private readonly IInvoiceApplication _invoiceApplication;

    public DetailsModel(IInvoiceApplication invoiceApplication)
    {
        _invoiceApplication = invoiceApplication;
    }

    public void OnGet(int id)
    {
        Invoice = _invoiceApplication.GetDetails(id);
    }
}

