using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApiEF;

var builder = WebApplication.CreateBuilder(args);

//Configuracion general del EF
//builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));

//Configurando un servicio para conectarse a SQL Server mediante un String de conexion
//String 2: Data Source=(local);Initial Catalog=TareasDB;Trusted_Connection=True;Integrated Security=True;user id=sa;password=c593a0de27
// El atributo FromServices de los endpoins hace referencia a la configuracion de los servicios: builder.Services.AddSqlServer
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

app.MapGet("/api/tareas", async ([FromServices] TareaContext dbContext) =>
{
    //Logica
    //"dbContext.Tareas" Representa la coleccion de datos que existe en la base de datos.
    // dbContext: Contexto de la base de datos de EF
    // .Tareas: Tabla de tareas en la BD
    return Results.Ok(
        //dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == ProyectoApiEF.Models.Prioridad.Bajo)); // Equivalente a una consulta anidada JOIN
        //dbContext.Tareas.Where(p => p.PrioridadTarea == ProyectoApiEF.Models.Prioridad.Bajo)); // Equivalente a una consulta anidada JOIN
        dbContext.Categorias.Include(p => p.Tareas).Where(p => p.Peso >= 50)); // Equivalente a SELECT en una tabla
});

app.Run();
