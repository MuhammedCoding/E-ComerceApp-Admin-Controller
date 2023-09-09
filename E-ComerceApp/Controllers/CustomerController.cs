using E_ComerceApp.Services.Interfaces;
using E_CommerceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_ComerceApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private IProductService _productService;
        public CustomerController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
           List<ProductWithCategoryAndBrandViewModel> products = _productService.GetProductsWithCategoriesAndBrands();
           return View(products);
        }


    }
}
