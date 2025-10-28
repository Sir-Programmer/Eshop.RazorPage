namespace Eshop.RazorPage.Models.Auth;

public class ConfirmRegistrationCommand
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string VerificationCode { get; set; }
}