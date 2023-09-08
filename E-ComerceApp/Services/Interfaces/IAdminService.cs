using E_CommerceApp.ViewModels;

namespace E_CommerceApp.Services.Interfaces
{
    public interface IAdminService
    {

        void UpdateProduct(ProductWithCategoryAndBrandViewModel viewModel);
        void DeleteProduct(int id);
        ProductWithCategoryAndBrandViewModel CreateEmptyProduct();
        void CreateProduct(ProductWithCategoryAndBrandViewModel viewModel);
    }


}
