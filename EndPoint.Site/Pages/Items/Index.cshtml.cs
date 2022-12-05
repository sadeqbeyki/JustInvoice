using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Site.Pages.Items;

public class IndexModel : PageModel
{
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;
    public List<ItemDto> Items { get; set; }


    public IndexModel(IItemApplication itemApplication,
        IProductApplication productApplication,
        IUnitApplication unitApplication)
    {
        _itemApplication = itemApplication;
        _productApplication = productApplication;
        _unitApplication = unitApplication;
    }

    public void OnGet()
    {
        Items = _itemApplication.GetItems();
    }
    public PartialViewResult OnGetCreate()
    {
        var command = new CreateItem
        {
            Products = _productApplication.GetProducts(),
            Units = _unitApplication.GetUnits()
        };
        return Partial("Create", command);
        //return Partial("Create", new CreateFactor());
    }
    public JsonResult OnPostCreate(CreateItem model)
    {
        var result = _itemApplication.Create(model);
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
