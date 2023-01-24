using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApiEF;

var builder = WebApplication.CreateBuilder(args);

//Configuracion general del EF
//builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));

//Configurando un servicio para conectarse a SQL Server mediante un String de conexion
//String 2: Data Source=(local);Initial Catalog=TareasDB;Trusted_Connection=True;Integrated Security=True;user id=sa;password=c593a0de27
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Mapeo de metodos
app.MapGet("/dbconexion", async ([FromServices] TareaContext dbContext) =>
{
    // Devuelve true 
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
