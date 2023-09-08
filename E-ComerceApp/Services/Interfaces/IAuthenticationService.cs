using E_ComerceApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace E_ComerceApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<(SignInResult result, string role)> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
