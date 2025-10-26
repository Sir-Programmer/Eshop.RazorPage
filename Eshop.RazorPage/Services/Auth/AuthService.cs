using Eshop.RazorPage.Models;
using Eshop.RazorPage.Models.Auth;

namespace Eshop.RazorPage.Services.Auth;

public class AuthService(HttpClient client) : IAuthService
{
    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
    {
        var result = await client.PostAsJsonAsync("auth/login", command);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }
}