using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrdeApi.Data;  

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos con Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Agregamos los controladores para las APIs
builder.Services.AddControllers();

// Configuración para la exploración de los puntos finales de la API
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger para documentar la API
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Orders API",
        Version = "v1",
        Description = "API para gestionar las órdenes y productos",
        Contact = new OpenApiContact
        {
            Name = "Daniel Montaño",
            Email = "email@dominio.com"
        }
    });
});

var app = builder.Build();

// Configuración de la aplicación para el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders API v1");
        c.RoutePrefix = string.Empty;  
    });
}

app.UseHttpsRedirection();  // Redirección de HTTP a HTTPS
app.UseAuthorization();     // Autorización para las peticiones

// Mapeamos los controladores
app.MapControllers();

// Ejecutamos la aplicación
app.Run();
