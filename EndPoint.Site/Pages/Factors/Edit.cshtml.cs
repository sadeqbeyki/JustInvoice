
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        public EditFactor Command;
        public SelectList Items;
        public SelectList Units;
        public SelectList Products;

        private readonly IFactorApplication _factorApplication;
        private readonly IItemApplication _itemApplication;
        private readonly IProductApplication _productApplication;
        private readonly IUnitApplication _unitApplication;
        public List<FactorViewModel> Factors { get; set; }

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

        public IActionResult OnGet(int id)
        {
            Command = _factorApplication.GetDetails(id);
            Command.Items = _itemApplication.GetItems();

            return Page();
        }
        public IActionResult OnPost(int id, EditFactor command)
        {
            command.Id = id;

            var result = _factorApplication.Edit(command);
            return RedirectToPage("./Index", result);
        }
    }
}
