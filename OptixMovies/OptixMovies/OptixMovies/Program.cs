using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using OptixMovies.Components;
using OptixMovies.Database;
using OptixMovies.Database.InitialData;
using OptixMovies.Repositories;
using OptixMovies.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<ApiService>();

builder.Services.AddDbContext<OptixContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "OptixMoviesDB");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<OptixContext>());

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddRazorPages();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OptixContext>();
    DataGenerator.Initialize(services);
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseMvcWithDefaultRoute();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();


app.Run();
