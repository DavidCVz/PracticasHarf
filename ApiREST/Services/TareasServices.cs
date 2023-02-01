using ApiREST.Models; // Modelos que serviran para manupular los datos
namespace ApiREST.Services;

public class TareaService : ITareaService
{
    public TareaContext context;

    public TareaService(TareaContext dbcontext)
    {
        context = dbcontext;
    }

    // READ
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    // CREATE
    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    // UPDATE
    public async Task Update (Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;

            await context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            context.Tareas.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update (Guid id, Tarea tarea);
    Task Delete(Guid id);
}