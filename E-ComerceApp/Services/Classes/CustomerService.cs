using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.Services.Interfaces;
using E_CommerceApp.ViewModels;

namespace E_ComerceApp.Services.Classes
{
    public class CustomerService : ICustomerService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CustomerService(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
        }

        public List<ProductWithCategoryAndBrandViewModel> GetProductsWithCategoriesAndBrands()
        {
            throw new NotImplementedException();
        }

        public ProductWithCategoryAndBrandViewModel GetProductWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
