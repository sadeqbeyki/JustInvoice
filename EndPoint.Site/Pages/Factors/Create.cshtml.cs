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
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SelectList Units;
    public SelectList Products;

    private readonly IFactorApplication _factorApplication;
    private readonly IItemApplication _itemApplication;
    private readonly IProductApplication _productApplication;
    private readonly IUnitApplication _unitApplication;

    public CreateModel(IItemApplication itemApplication,
        IProductApplication productApplication,
        IUnitApplication unitApplication,
        IFactorApplication factorApplication,
        IWebHostEnvironment webHostEnvironment)
    {
        _itemApplication = itemApplication;
        _productApplication = productApplication;
        _unitApplication = unitApplication;
        _factorApplication = factorApplication;
        _webHostEnvironment = webHostEnvironment;
    }

    public void OnGet()
    {
        Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");//
        Units = new SelectList(_unitApplication.GetUnits(), "Id", "Name");//

        Factor.Items.Add(new ItemDto() { Id = 1 });
    }
    [BindProperty]
    public FactorDto Factor { get; set; } = new FactorDto();
    public IActionResult OnPost()
    {
        string uniqueFileName = GetUploadFileName(Factor);
        Factor.PhotoUrl = uniqueFileName;
        
        _factorApplication.Create(Factor);
        return RedirectToPage("./Index");
    }

    private string GetUploadFileName(FactorDto model)
    {
        string uniqueFileName = string.Empty;
        if (model.Photo != null)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            model.Photo.CopyTo(fileStream);
        }
        return uniqueFileName;
    }
}
