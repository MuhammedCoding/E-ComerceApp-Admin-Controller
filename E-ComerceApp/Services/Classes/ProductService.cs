using E_ComerceApp.Mappers.Interfaces;
using E_ComerceApp.Services.Interfaces;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.ViewModels;

namespace E_ComerceApp.Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IProductMapper _productMapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductMapper productMapper, IProductRepository productRepository)
        {
            _productMapper = productMapper;
            _productRepository = productRepository;
        }

        public List<ProductWithCategoryAndBrandViewModel> GetProductsWithCategoriesAndBrands()
        {
            var products = _productRepository.GetAllProducts();
            return products.Select(_productMapper.MapProductToViewModel).ToList();
        }

        public ProductWithCategoryAndBrandViewModel GetProductWithDetails(int id)
        {
            var product = _productRepository.GetProductById(id);
            return _productMapper.MapProductToViewModel(product);
        }
    }
}
