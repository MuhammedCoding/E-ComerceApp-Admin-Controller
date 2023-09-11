using E_ComerceApp.Services.Interfaces;
using E_CommerceApp.Services.Interfaces;
using E_CommerceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProductService _productService;

        public AdminController(IAdminService adminService , IProductService productService)
        {
            _adminService = adminService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProductsWithCategoriesAndBrands());
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _productService.GetProductWithDetails(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateProduct(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            _adminService.DeleteProduct(id);
            return RedirectToAction("index");
        }

        public IActionResult CreateProduct()
        {
            var viewModel = _adminService.CreateEmptyProduct();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            if (viewModel.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The ImageFile field is required.");
            }
            if (ModelState.IsValid)
            {
               
                _adminService.CreateProduct(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}


