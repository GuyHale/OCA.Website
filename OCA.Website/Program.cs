using Amazon;
using Amazon.Extensions.NETCore.Setup;
using MudBlazor.Services;
using OCA.Website.Interfaces;
using OCA.Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services
    .AddSingleton<ICryptocurrency, CryptocurrencyService>()
    .AddSingleton<IApiKeyCreation, ApiKeyCreation>()
    .AddHttpContextAccessor()
    .AddHttpClient("CIP.API", client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["CIP.API.Url"]);
    }).Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
