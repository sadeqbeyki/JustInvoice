using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Pages.Factors;

public class EditModel : PageModel
{
    public SelectList Units;
    public SelectList Products;

    private readonly IFactorApplication _factorApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;

    public EditModel(IProductApplication productApplication,
        IUnitApplication unitApplication,
        IFactorApplication factorApplication)
    {
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _factorApplication = factorApplication;
    }


    public IActionResult OnGet(int id)
    {
		Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
		Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

		Invoice = _factorApplication.GetFactor(id);
        Invoice.Items = _factorApplication.GetItems(id);

		return Page();
    }
    [BindProperty]
    public FactorDto Invoice { get; set; }
    public IActionResult OnPost(int id)
    {
        Invoice.Id = id;

        var result = _factorApplication.Update(Invoice);
        return RedirectToPage("./Index", result);
    }
}
