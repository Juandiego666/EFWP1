using Microsoft.EntityFrameworkCore;
using EFWP1.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// 2. Agregar servicios MVC
builder.Services.AddControllersWithViews();

// 3. Construir la aplicación (aquí se define 'app')
var app = builder.Build();

// 4. Configurar el pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto apuntando al controlador Categorias
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categorias}/{action=Index}/{id?}");

app.Run();