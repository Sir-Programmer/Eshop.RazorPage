using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace Eshop.RazorPage.Services.Auth;

public interface IAuthService
{
    Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
    Task<ApiResult?> RequestRegistration(RequestRegistrationCommand command);
    Task<ApiResult?> ConfirmRegistration(ConfirmRegistrationCommand command);
}