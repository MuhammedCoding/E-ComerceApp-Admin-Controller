using E_ComerceApp.Mappers.Interfaces;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.Services.Interfaces;
using E_CommerceApp.ViewModels;

namespace E_CommerceApp.Services.Classes
{
    public class AdminService : IAdminService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductMapper _productMapper;

        public AdminService(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IProductMapper productMapper )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _productMapper = productMapper;
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
            var product = _productMapper.MapViewModelToProduct(viewModel);
            _productRepository.UpdateProduct(product);
        }

        public void CreateProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            var product = _productMapper.MapViewModelToProduct(viewModel);
            _productRepository.CreateProduct(product);
        }


    }


}


