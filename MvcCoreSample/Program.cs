using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args); // creates a new web application builder, e.g. Kestrel web server, configuring services

// Register services in the DI container
// - AddScoped: creates a new service scope for each request
// - AddKeyedScoped: creates a new service scope for each request, but allows for keyed resolution
// - AddSingleton: creates a single instance of the service for the entire application
// - AddTransient: creates a new instance of the service each time it is requested
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>(); // registers the ICategoryRepository service with a scoped lifetime
builder.Services.AddScoped<IPieRepository, MockPieRepository>(); // registers the IPieRepository service with a scoped lifetime

builder.Services.AddControllersWithViews(); // enables the MVC pattern

var app = builder.Build();

// Register middleware components in the HTTP request pipeline, i.e. services that handle requests and responses
app.UseStaticFiles(); // serves static files like CSS, JS, images  

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // shows detailed error pages in development
}

app.MapDefaultControllerRoute(); // sets up the default route for MVC

app.Run();
