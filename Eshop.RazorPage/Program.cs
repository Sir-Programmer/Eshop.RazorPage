using Eshop.RazorPage.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddRazorPages();
services.RegisterApiServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();