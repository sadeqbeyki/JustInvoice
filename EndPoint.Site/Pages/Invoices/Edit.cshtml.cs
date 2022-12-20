using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Pages.Invoices;

public class EditModel : PageModel
{
    public SelectList Units;
    public SelectList Products;

    private readonly IInvoiceApplication _invoiceApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;

    public EditModel(IProductApplication productApplication,
        IUnitApplication unitApplication,
        IInvoiceApplication invoiceApplication)
    {
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _invoiceApplication = invoiceApplication;
    }


    public IActionResult OnGet(int id)
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

        Invoice = _invoiceApplication.GetInvoice(id);
        Invoice.Items = _invoiceApplication.GetItems(id);

        return Page();
    }
    [BindProperty]
    public InvoiceDto Invoice { get; set; }
    public IActionResult OnPost(int id)
    {
        Invoice.Id = id;

        var result = _invoiceApplication.Update(Invoice);
        return RedirectToPage("./Index", result);
    }
}
