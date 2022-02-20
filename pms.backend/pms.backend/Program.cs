global using Microsoft.EntityFrameworkCore;
global using DataAccessLayer.Models;
using DataAccessLayer.data;
using DataAccessLayer.repositories;
using DataAccessLayer.contracts;
using BusinessAccessLayer.services;

var AllowFrontend = "_AllowFrontend";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowFrontend,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080/");
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IServiceProject, ServiceProject>();
builder.Services.AddScoped<IRepository<Project>, RepositoryProject>();

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

app.UseCors(AllowFrontend);

app.Run();
