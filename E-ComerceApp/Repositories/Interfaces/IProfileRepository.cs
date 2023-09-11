using E_ComerceApp.ViewModels;

namespace E_ComerceApp.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        void UpdateProfile(RegisterViewModel viewModel);
    }
}
