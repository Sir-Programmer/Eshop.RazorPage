using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace Eshop.RazorPage.Services.Auth;

public class AuthService(HttpClient client) : IAuthService
{
    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/login", command);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> RequestRegistration(RequestRegistrationCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/register", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ConfirmRegistration(ConfirmRegistrationCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/register/confirm", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}