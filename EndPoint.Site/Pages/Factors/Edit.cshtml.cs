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
    //public FactorDto Command;
    public List<ItemDto> ItemList;
    public SelectList Items;
    public SelectList Units;
    public SelectList Products;

    private readonly IFactorApplication _factorApplication;
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;
    //public List<FactorDto> Factors { get; set; }

    public EditModel(IItemApplication itemApplication,
        IProductApplication productApplication,
        IUnitApplication unitApplication,
        IFactorApplication factorApplication)
    {
        _itemApplication = itemApplication;
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _factorApplication = factorApplication;
    }
    public FactorItemDto? Command { get; set; }


    public IActionResult OnGet(int id)
    {
        //Command = _factorApplication.GetFactor(id);
        //Command.Items = _itemApplication.GetItems();
        //Command = _factorApplication.GetFactorWithItems(id);

        return Page();
    }
    public IActionResult OnPost(int id, FactorItemDto command)
    {
        command.Id = id;

        var result = _factorApplication.Edit(command);
        return RedirectToPage("./Index", result);
    }
}
