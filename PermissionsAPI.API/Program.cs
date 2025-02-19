using Microsoft.EntityFrameworkCore;
using PermissionsAPI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar servicios
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();