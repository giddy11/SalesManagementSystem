using CoreBusiness.DatabaseServicesDirectory;
using CoreBusiness.DataStorePluginInterfaces;
using WebApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IDatabaseCategoryService, DatabaseCategoryService>();
builder.Services.AddSingleton<IDatabaseProductService, DatabaseProductService>();
builder.Services.AddSingleton<IDatabaseUserService, DatabaseUserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
