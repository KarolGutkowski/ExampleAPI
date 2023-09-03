using ExampleAPI.Models;
using ExampleAPI.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<PostDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ExampleAPIDBContextConnection"]);
});
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();