using E_CommerceApp.Models;
using E_CommerceApp.ViewModels;

namespace E_ComerceApp.Services.Interfaces
{
    public interface IProductService
    {

        List<ProductWithCategoryAndBrandViewModel> GetProductsWithCategoriesAndBrands();
        ProductWithCategoryAndBrandViewModel GetProductWithDetails(int id);

    }
}
