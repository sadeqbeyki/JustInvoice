using AppFramework;
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
    public ItemDto Items;

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
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");

        //FactorDto factorDto = new()
        //{
        //    Items = new List<ItemDto>()
        //};

        //ItemDto row1 = new();
        //ItemDto row2 = new();
        //ItemDto row3 = new();
        //factorDto.CreationDate = DateTime.Now.ToFarsi();
        //factorDto.Items.Add(row1);
        //factorDto.Items.Add(row2);
        //factorDto.Items.Add(row3);
        //return Page();

    }
    [BindProperty]
    public FactorItemDto? Command { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        _factorApplication.Create(Command);
        return RedirectToPage("./Index");
    }
}