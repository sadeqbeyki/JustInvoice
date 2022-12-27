using JI.ApplicationContracts.Invoice;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages.Invoices;

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

