using ApiREST.Models; // Modelos que serviran para manupular los datos
namespace ApiREST.Services;

public class CategoriaService : ICategoriaService
{
    TareaContext context; // Contexto que permitira la conexion con la BD

    // Se debe de recibir el contexto para relizar las operaciones sobre la base de datos
    public CategoriaService(TareaContext dbcontext)
    {
        context = dbcontext;
    }

    // Retorna una coleccion de todas las categorias almacenados en la BD
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias; // Select * from Categorias
    }

    // Guarda una categoria entrante
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null) // Si existen datos en la peticion
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
/*          categoriaActual.Nombre = categoria.Nombre;
            categoria.Descripcion = categoria.Descripcion;
            categoria.Peso = categoria.Peso; */
            context.Update(categoriaActual);
            await context.SaveChangesAsync(); // Guarda los datos modificados
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);

            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}