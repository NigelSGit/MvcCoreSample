var builder = WebApplication.CreateBuilder(args); // creates a new web application builder, e.g. Kestrel web server, configuring services

builder.Services.AddControllersWithViews(); // enables the MVC pattern

var app = builder.Build();

app.UseStaticFiles(); // serves static files like CSS, JS, images  

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // shows detailed error pages in development
}

app.MapDefaultControllerRoute(); // sets up the default route for MVC

app.Run();
