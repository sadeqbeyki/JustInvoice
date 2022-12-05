using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.WebUi.Pages.Factors;

public class IndexModel : PageModel
{
    private readonly IFactorApplication _factorApplication;
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;
    public List<FactorViewModel> Factors { get; set; }
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
    public PartialViewResult OnGetCreate()
    {

        //var command = new CreateFactor
        //{
        //    Items = new List<CreateItem>
        //   {
        //       new CreateItem
        //       {
        //            Products = _productApplication.GetProducts(),
        //            Units = _unitApplication.GetUnits()
        //       }

        //   }

        //};
        var command = new CreateItem
        {
            Products = _productApplication.GetProducts(),
            Units = _unitApplication.GetUnits()
        };
        return Partial("Create", command);
    }
    public JsonResult OnPostCreate(CreateFactor factorModel, CreateItem itemModel)
    {
        var result = _factorApplication.Create(factorModel, itemModel);
        return new JsonResult(result);
    }

    public PartialViewResult OnGetEdit(long id)
    {
        var item = _itemApplication.GetDetails(id);
        item.Products = _productApplication.GetProducts();
        item.Units = _unitApplication.GetUnits();
        return Partial("Edit", item);
    }
    public JsonResult OnPostEdit(long id, EditItem model)
    {
        var result = _itemApplication.Edit(model);
        return new JsonResult(result);
    }

    public IActionResult OnGetRemove(int id)
    {
        _itemApplication.Delete(id);
        return RedirectToPage("./Index");
    }
}
