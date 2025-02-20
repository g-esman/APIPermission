using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PermissionsAPI.Infrastructure.Persistence;
using PermissionsAPI.Infrastructure.Persistence.Repositories;
using PermissionsAPI.Domain.Entities; // Add this line

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Permission>, PermissionRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();