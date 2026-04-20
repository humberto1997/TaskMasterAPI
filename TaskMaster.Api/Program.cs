using Microsoft.EntityFrameworkCore;
using TaskMaster.Api.Data;
using Scalar.AspNetCore; // Opcional: Una alternativa moderna a Swagger

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Servicios
builder.Services.AddControllers();

// .NET 10 usa esto por defecto para la especificación
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. Configuración del Pipeline (Aquí está el truco)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Esto genera el JSON de la API

    // Agregamos esta línea para tener una interfaz visual
    // Si prefieres el Swagger clásico, hay que instalar otro paquete, 
    // pero .NET 10 recomienda usar Scalar o el endpoint de OpenAPI
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();