using ExampleAPI.Consts;
using ExampleAPI.Models;
using ExampleAPI.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration[DbConfigurationConsts.ExampleAPIDBConfigSection]);
});
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example API");
        c.RoutePrefix = string.Empty;
    });
}

app.MapDefaultControllerRoute();

app.Run();