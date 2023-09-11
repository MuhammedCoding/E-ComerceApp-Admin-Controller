using E_ComerceApp.Repositories.Interfaces;
using E_ComerceApp.ViewModels;

namespace E_ComerceApp.Services.Interfaces
{
    public interface IProfileSevice
    {
       Task<bool> UpdateProfile(RegisterViewModel profile);
       Task<RegisterViewModel> GetProfile(string id);


    }
}
