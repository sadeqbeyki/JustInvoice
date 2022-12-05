using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Invoice.Domain.ItemAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Pages.Factors;

public class CreateModel : PageModel
{
    public SelectList Units;
    public SelectList Products;
    public CreateFactor Command;

    private readonly IFactorApplication _factorApplication;
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;



    public CreateModel(IItemApplication itemApplication,
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
        //Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        //Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

        FactorViewModel viewModel = new()
        {
            Items = new List<ItemViewModel>()
        };
        Item row1 = new();
        Item row2 = new();
        Item row3 = new();
        viewModel.CreationDate = DateTime.Now.ToFarsi();
        viewModel.Items.Add(row1);
        viewModel.Items.Add(row2);
        viewModel.Items.Add(row3);
        return ViewResult(viewModel);

    }
    public IActionResult OnPost(CreateFactor factorModel, CreateItem itemModel)
    {
        _factorApplication.Create(factorModel, itemModel);
        return RedirectToPage("./Index");
    }
}
