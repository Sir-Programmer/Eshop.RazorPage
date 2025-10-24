using Eshop.RazorPage.Services.Auth;

namespace Eshop.RazorPage.Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["ApiBaseUrl"]!;

        services.AddHttpClient<IAuthService, AuthService>(options => options.BaseAddress = new Uri(baseUrl));
        
        return services;
    }
}