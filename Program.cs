using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 👇 Registramos servicios de controladores (para la API)
builder.Services.AddControllers();

var app = builder.Build();

// 👇 Middleware para mostrar errores en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// 👇 Habilitamos archivos estáticos (wwwroot)
app.UseDefaultFiles();   // Busca index.html por defecto
app.UseStaticFiles();    // Sirve CSS, JS, imágenes, etc.

// 👇 Rutas de la API
app.MapControllers();

// 👇 Arrancamos la aplicación
app.Run();