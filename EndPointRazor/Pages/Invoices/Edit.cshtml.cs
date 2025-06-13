using JI.ApplicationContracts.Invoice;
using JI.DomainContracts.Invoices;
using JI.DomainContracts.Products;
using JI.DomainContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPointRazor.Pages.Invoices;

public class EditModel : PageModel
{
    public SelectList Units;
    public SelectList Products;

    private readonly IInvoiceApplication _invoiceApplication;
    private readonly IGetAllProductsQuery _productApplication;
    private readonly IGetAllUnitsQuery _unitApplication;

    public EditModel(IGetAllProductsQuery productApplication,
        IGetAllUnitsQuery unitApplication,
        IInvoiceApplication invoiceApplication)
    {
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _invoiceApplication = invoiceApplication;
    }

    public void OnGet(int id)
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

        Invoice = _invoiceApplication.GetDetails(id);
        Invoice.Items.Add(new ItemDto() { Id = 1 });
    }
    [BindProperty]
    public InvoiceDto Invoice { get; set; } = new InvoiceDto();
    public IActionResult OnPost(int id)
    {
        Invoice.Id = id;

        var result = _invoiceApplication.Update(Invoice);
        return RedirectToPage("./Index", result);
    }
}
