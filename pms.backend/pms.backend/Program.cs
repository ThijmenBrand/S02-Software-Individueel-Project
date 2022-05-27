global using Microsoft.EntityFrameworkCore;
global using DataAccessLayer.Models;
using DataAccessLayer.data;
using DataLayer.repos.task;
using DataLayer.repos.sprint;
using DataLayer.repos.project;
using DataLayer.repos.users;
using BusinessLayer.services.project;
using BusinessLayer.services.sprint;
using BusinessLayer.services.tasks;
using BusinessLayer.services.Users;
using Authorization;
using Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ValidatorMiddleware;

var AllowFrontend = "_AllowFrontend";

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;

    services.AddCors();
    services.AddControllers();

    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));

    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IServiceProject, ServiceProject>();
    services.AddScoped<IExcecuteServiceProject, ProjectExcecute>();
    services.AddScoped<IProjectRepo<Project>, RepositoryProject>();
    services.AddScoped<ITasksRepo<Tasks>, TasksRepo>();
    services.AddScoped<IExcecuteSprintService, ExcecuteSprintService>();
    services.AddScoped<ITasksService, TasksService>();
    services.AddScoped<IExcecuteTasksService, ExcecuteTasksService>();
    services.AddScoped<ISprintRepo<Sprint>, SprintsRepo>();
    services.AddScoped<ISprintService, SprintService>();
    services.AddScoped<IUsersRepo<User>, UsersRepo>();
    services.AddScoped<IUsersService, UserService>();
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IInputMiddleWare, InputMiddleWare>();
    services.AddHttpContextAccessor();

    services.AddSwaggerGen();
    services.AddEndpointsApiExplorer();

    services.AddCors(options =>
    {
        options.AddPolicy(name: AllowFrontend,
                          builder =>
                          {
                              builder.WithOrigins("http://localhost:8080/");
                          });
    });

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:Secret"]))
        };
    });

}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseCors(AllowFrontend);

    app.Run();
}
