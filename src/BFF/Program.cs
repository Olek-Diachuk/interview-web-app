using BFF.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequireApiAccessScope", policy =>
        policy.RequireClaim(ClaimConstants.Scope, builder.Configuration["AzureAdB2C:Scope"]!));

builder.Services.AddHttpClient("inventory", c =>
    c.BaseAddress = new Uri("http://localhost:81/"));

builder.Services.AddHttpClient("payment", c =>
    c.BaseAddress = new Uri("http://localhost:82/"));

builder.Services.AddTransient<Func<string, HttpHandler>>(sp => clientName =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient(clientName);
    return new HttpHandler(client);
});

builder.Services.AddTransient<InventoryHandler>();
builder.Services.AddTransient<PaymentHandler>();
builder.Services.AddTransient<OrderHandler>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
