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
    public void Save(Categoria categoria)
    {
        context.Add(categoria);
        context.SaveChanges();
    }

    public void Update(Guid id, Categoria categoria)
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
            context.SaveChanges(); // Guarda los datos modificados
        }
    }

    public void Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);

            context.SaveChanges();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    void Save(Categoria categoria);
    void Update(Guid id, Categoria categoria);
    void Delete(Guid id);
}