using RegistroDeJugadores.Components;
using RegistroDeJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroDeJugadores.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));

builder.Services.AddHttpClient("ApiGestionHuacales", client =>
{
    client.BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/");
});

builder.Services.AddScoped<JugadoresService>();
builder.Services.AddScoped<PartidasService>();
builder.Services.AddScoped<PlayerTypeService>();
builder.Services.AddScoped<MovimientosService>();

// Inyeccion de los API Services
builder.Services.AddHttpClient<IPartidasApiService, PartidasApiService>(client =>
{
    client.BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/");
});

builder.Services.AddHttpClient<IMovimientosApiService, MovimientosApiService>(client =>
{
    client.BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();