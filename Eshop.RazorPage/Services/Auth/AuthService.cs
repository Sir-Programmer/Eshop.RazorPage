using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace Eshop.RazorPage.Services.Auth;

public class AuthService(HttpClient client, IHttpContextAccessor accessor) : IAuthService
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

    public async Task<ApiResult?> RequestPasswordReset(RequestPasswordResetCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/password/request-reset", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ConfirmPasswordReset(ConfirmPasswordResetCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/password/confirm-reset", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult<LoginResponse>?> RefreshToken()
    {
        var refreshToken = accessor.HttpContext?.Request.Cookies["refreshToken"];
        var result = await client.PostAsync($"auth/refresh-token?refreshToken={refreshToken}", null);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> Logout()
    {
        var result = await client.DeleteAsync($"auth/logout");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}