using E_ComerceApp.Mappers.Interfaces;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.Services.Interfaces;
using E_CommerceApp.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace E_CommerceApp.Services.Classes
{
    public class AdminService : IAdminService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductMapper _productMapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminService(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IProductMapper productMapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productMapper = productMapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<ProductWithCategoryAndBrandViewModel> GetProductsWithCategoriesAndBrands()
        {
            List<Product> products = _productRepository.GetAllProducts();
            var productWithCategoryAndBrandViewModel = products.Select(p => _productMapper.MapProductToViewModel(p)).ToList();
            return productWithCategoryAndBrandViewModel;
        }

        public ProductWithCategoryAndBrandViewModel GetProductWithDetails(int id)
        {
            var product = _productRepository.GetProductById(id);
            var viewModel = _productMapper.MapProductToViewModel(product);
            viewModel.Brands = _brandRepository.GetAllBrands().ToList();
            viewModel.Categories = _categoryRepository.GetAllCategories().ToList();
            return viewModel;
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public ProductWithCategoryAndBrandViewModel CreateEmptyProduct()
        {
            var viewModel = new ProductWithCategoryAndBrandViewModel();
            viewModel.Brands = _brandRepository.GetAllBrands().ToList();
            viewModel.Categories = _categoryRepository.GetAllCategories().ToList();
            return viewModel;
        }

        public void UpdateProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            var product = _productRepository.GetProductById(viewModel.Id);
            if (viewModel.ImageFile != null)
            {
                string newImageUrl = SaveImage(viewModel.ImageFile);
                product.ImageUrl = newImageUrl;
            }
            product.Name = viewModel.Name;
            product.ID = viewModel.Id;
            product.Description = viewModel.Description;
            product.Price= viewModel.Price;
            product.CategoryID = viewModel.CategoryId;
            product.BrandID = viewModel.BrandId;
            product.Count = viewModel.Count;
            _productRepository.UpdateProduct(product);
        }

        public void CreateProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            var product = _productMapper.MapViewModelToProduct(viewModel);
            string newImageUrl = SaveImage(viewModel.ImageFile);
            product.ImageUrl = newImageUrl;
            _productRepository.CreateProduct(product);
        }

        public string SaveImage(IFormFile image)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
                fileStream.Close();
            }
            string imageUrl = "images/products/" + uniqueFileName;
            return imageUrl;
        }


    }


}


