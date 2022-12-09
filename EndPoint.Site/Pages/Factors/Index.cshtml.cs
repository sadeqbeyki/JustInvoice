using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages.Factors;

public class IndexModel : PageModel
{
    private readonly IFactorApplication _factorApplication;
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;
    public List<FactorItemDto> Factors { get; set; }
    //public List<ProductViewModel> Products { get; set; }
    //public List<UnitViewModel> Units { get; set; }


    public IndexModel(IItemApplication itemApplication,
        IProductApplication productApplication,
        IUnitApplication unitApplication,
        IFactorApplication factorApplication)
    {
        _itemApplication = itemApplication;
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _factorApplication = factorApplication;
    }

    public void OnGet()
    {
        Factors = _factorApplication.GetFactors();
    }
  
    public IActionResult OnGetRemove(int id)
    {
        _factorApplication.Delete(id);
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetDetails(int id)
    {
        _factorApplication.Delete(id);
        return RedirectToPage("./Index");
    }
}
