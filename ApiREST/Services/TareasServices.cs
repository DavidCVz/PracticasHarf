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
    public void Save(Tarea tarea)
    {
        context.Add(tarea);
        context.SaveChanges();
    }

    // UPDATE
    public void Update (Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;

            context.SaveChanges();
        }
    }

    // DELETE
    public void Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            context.Tareas.Remove(tareaActual);
            context.SaveChanges();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    void Save(Tarea tarea);
    void Update (Guid id, Tarea tarea);
    void Delete(Guid id);
}