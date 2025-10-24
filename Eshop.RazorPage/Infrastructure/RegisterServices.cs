using Eshop.RazorPage.Services.Auth;
using Eshop.RazorPage.Services.Banners;
using Eshop.RazorPage.Services.Categories;
using Eshop.RazorPage.Services.Comments;
using Eshop.RazorPage.Services.MainPage;
using Eshop.RazorPage.Services.Orders;
using Eshop.RazorPage.Services.Products;
using Eshop.RazorPage.Services.Roles;
using Eshop.RazorPage.Services.Sellers;
using Eshop.RazorPage.Services.ShippingMethods;
using Eshop.RazorPage.Services.Sliders;
using Eshop.RazorPage.Services.Transactions;
using Eshop.RazorPage.Services.Users;

namespace Eshop.RazorPage.Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["ApiBaseUrl"]!;

        services.AddHttpClient<IAuthService, AuthService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IBannerService, BannerService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<ICategoryService, CategoryService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<ICommentService, CommentService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IMainPageService, MainPageService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IOrderService, OrderService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IProductService, ProductService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IRoleService, RoleService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<ISellerService, SellerService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IShippingMethodService, ShippingMethodService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<ISliderService, SliderService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<ITransactionService, TransactionService>(options => options.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IUserService, UserService>(options => options.BaseAddress = new Uri(baseUrl));
        
        return services;
    }
}