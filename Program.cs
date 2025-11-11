using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using StudentApi.Data;
using StudentApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=students.db"));

builder.Services.AddControllers();

var app = builder.Build();

// create DB if missing
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Global exception handler - returns JSON {error: "..."}
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var ex = feature?.Error;

        var result = JsonSerializer.Serialize(new
        {
            error = "An unexpected error occurred. Try again later.",
            detail = ex?.Message // in dev you can include this; remove in production
        });

        await context.Response.WriteAsync(result);
    });
});

app.MapControllers();

app.Run();
