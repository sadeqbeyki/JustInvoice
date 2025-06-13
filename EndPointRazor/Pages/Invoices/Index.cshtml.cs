using JI.DomainContracts.Invoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPointRazor.Pages.Invoices;

public class IndexModel(IInvoiceApplication invoiceApplication) : PageModel
{
    private readonly IInvoiceApplication _invoiceApplication = invoiceApplication;
    public List<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto> { };


    public void OnGet()
    {
        Invoices = _invoiceApplication.GetInvoices();
    }

    public IActionResult OnGetDetails(int id)
    {
        _invoiceApplication.GetDetails(id);
        return RedirectToPage("./Details");
    }
    [BindProperty]
    public InvoiceDto Invoice { get; set; } = new InvoiceDto();
    public PartialViewResult OnGetDelete(int id)
    {
        Invoice = _invoiceApplication.GetDetails(id);
        return Partial("Delete", Invoice);
    }

    public JsonResult OnPostDelete(long id)
    {
        var result = _invoiceApplication.Delete(id);
        return new JsonResult(result);

    }
}
