﻿using Invoice.ApplicationContracts.Invoice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages.Invoices;

public class IndexModel : PageModel
{
    private readonly IInvoiceApplication _invoiceApplication;

    public List<InvoiceDto> Invoices { get; set; }

    public IndexModel(IInvoiceApplication invoiceApplication)
    {
        _invoiceApplication = invoiceApplication;
    }

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
    public JsonResult OnPostDelete(int id)
    {
         _invoiceApplication.Delete(id);
        return new JsonResult("./Index");
    }
}
