using E_ComerceApp.Mappers.Interfaces;
using E_CommerceApp.Models;
using E_CommerceApp.Repositories.Interfaces;
using E_CommerceApp.ViewModels;

namespace E_ComerceApp.Mappers.Classes
{

    public class ProductMapper : IProductMapper
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductMapper(IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
        }
        public Product MapViewModelToProduct(ProductWithCategoryAndBrandViewModel viewModel)
        {
            return new Product
            {
                ID = viewModel.Id,
                Name = viewModel.Name,
                BrandID = viewModel.BrandId,
                CategoryID = viewModel.CategoryId,
                Price = viewModel.Price,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                Count = viewModel.Count,
            };
        }

        public ProductWithCategoryAndBrandViewModel MapProductToViewModel(Product product)
        {
            return new ProductWithCategoryAndBrandViewModel
            {
                Id = product.ID,
                Name = product.Name,
                BrandId = product.BrandID,
                CategoryId = product.CategoryID,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Count = product.Count,
                Description = product.Description,
                BrandName = _brandRepository.GetBrandById(product.BrandID).Name,
                BrandImage = _brandRepository.GetBrandById(product.BrandID).Image,
                CategoryImage = _categoryRepository.GetCategoryById(product.CategoryID).Image,
                CategoryName = _categoryRepository.GetCategoryById(product.CategoryID).Name,
                Brands = _brandRepository.GetAllBrands().ToList(),
                Categories = _categoryRepository.GetAllCategories().ToList()
        };
        }
    }
}
