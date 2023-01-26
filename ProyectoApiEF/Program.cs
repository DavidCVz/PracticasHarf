using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApiEF;
using ProyectoApiEF.Models;
using System.Formats.Tar;

var builder = WebApplication.CreateBuilder(args);

//Configuracion general del EF
//builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));

//Configurando un servicio para conectarse a SQL Server mediante un String de conexion
//String 2: Data Source=(local);Initial Catalog=TareasDB;Trusted_Connection=True;Integrated Security=True;user id=sa;password=c593a0de27
// El atributo FromServices de los endpoins hace referencia a la configuracion de los servicios: builder.Services.AddSqlServer
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Mapeo de metodos CONSULTA
app.MapGet("/dbconexion", async ([FromServices] TareaContext dbContext) =>
{
    // Devuelve true 
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

// CONSULTA
app.MapGet("/api/tareas", async ([FromServices] TareaContext dbContext) =>
{
    //Logica
    //"dbContext.Tareas" Representa la coleccion de datos que existe en la base de datos.
    // dbContext: Contexto de la base de datos de EF
    // .Tareas: Tabla de tareas en la BD
    return Results.Ok(
        //dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == ProyectoApiEF.Models.Prioridad.Bajo)); // Equivalente a una consulta anidada JOIN
        dbContext.Tareas.Where(p => p.PrioridadTarea == ProyectoApiEF.Models.Prioridad.Bajo)); // Equivalente a una consulta anidada JOIN
        //dbContext.Categorias.Include(p => p.Tareas).Where(p => p.Peso >= 50)); // Equivalente a SELECT en una tabla
});

// INSERCCION DE DATOS
app.MapPost("/api/tareas", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea) => //
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea); // Forma 1.
    //await dbContext.Tareas.AddAsync(tarea); //Forma 2.

    await dbContext.SaveChangesAsync(); // Confirmar los cambios y guardarlos en la BD

    return Results.Ok("Inserccion de datos correctamente");
});

// ACTUALIZACION DE DATOS
app.MapPut("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => //
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok("Datos actualizados correctamente");
    }
    return Results.NotFound("Datos no encontrados");
});

// ELIMINAR DATOS
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromRoute] Guid id) => //
{
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok("Datos eliminados correctamente");
    }
    return Results.NotFound("Datos no encontrados");
});

app.Run();
