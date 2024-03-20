using Microsoft.EntityFrameworkCore;
using Peliculas.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar servicios de Entity Framework Core
builder.Services.AddDbContext<PeliculasSqlContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios de MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Resto del código

// Configuración del pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
