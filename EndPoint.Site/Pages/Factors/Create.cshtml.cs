using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Pages.Factors;

public class CreateModel : PageModel
{
    public SelectList Units;
    public SelectList Products;

    private readonly IFactorApplication _factorApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;

    public CreateModel(IProductApplication productApplication,
        IUnitApplication unitApplication,
        IFactorApplication factorApplication)
    {
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _factorApplication = factorApplication;
    }

    public void OnGet()
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

        Invoice.Items.Add(new ItemDto() { Id = 1 });
    }
    [BindProperty]
    public FactorDto Invoice { get; set; } = new FactorDto();
    public IActionResult OnPost()
    {
        _factorApplication.Create(Invoice);
        return RedirectToPage("./Index");
    }
}
