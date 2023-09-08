using E_CommerceApp.Models;
using E_CommerceApp.ViewModels;

namespace E_ComerceApp.Mappers.Interfaces
{
    public interface IProductMapper
    {
        Product MapViewModelToProduct(ProductWithCategoryAndBrandViewModel viewModel);
        ProductWithCategoryAndBrandViewModel MapProductToViewModel(Product product);

    }
}
