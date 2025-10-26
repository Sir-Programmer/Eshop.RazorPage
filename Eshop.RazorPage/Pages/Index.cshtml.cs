using Eshop.RazorPage.Models.Auth;
using Eshop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eshop.RazorPage.Pages;

public class IndexModel(IAuthService authService, ILogger<IndexModel> logger) : PageModel
{
    public void OnGet()
    {
        
    }
}