using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace Eshop.RazorPage.Services.Auth;

public class AuthService(HttpClient client, IHttpContextAccessor accessor) : IAuthService
{
    private const string ModuleName = "Auth";
    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
    {
        var result = await client.PostAsJsonAsync($"{ModuleName}/login", command);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> RequestRegistration(RequestRegistrationCommand command)
    {
        var result = await client.PostAsJsonAsync($"{ModuleName}/register", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ConfirmRegistration(ConfirmRegistrationCommand command)
    {
        var result = await client.PostAsJsonAsync($"{ModuleName}/register/confirm", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> RequestPasswordReset(RequestPasswordResetCommand command)
    {
        var result = await client.PostAsJsonAsync($"{ModuleName}/password/request-reset", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ConfirmPasswordReset(ConfirmPasswordResetCommand command)
    {
        var result = await client.PostAsJsonAsync($"{ModuleName}/password/confirm-reset", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult<LoginResponse>?> RefreshToken()
    {
        var refreshToken = accessor.HttpContext?.Request.Cookies["refreshToken"];
        var result = await client.PostAsync($"{ModuleName}/refresh-token?refreshToken={refreshToken}", null);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> Logout()
    {
        var result = await client.DeleteAsync($"{ModuleName}/logout");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}