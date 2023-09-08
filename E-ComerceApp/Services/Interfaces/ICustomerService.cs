using E_CommerceApp.ViewModels;

namespace E_CommerceApp.Services.Interfaces
{
    public interface ICustomerService
    {

        List<ProductWithCategoryAndBrandViewModel> GetProductsWithCategoriesAndBrands();
        ProductWithCategoryAndBrandViewModel GetProductWithDetails(int id);
       
    }


}
