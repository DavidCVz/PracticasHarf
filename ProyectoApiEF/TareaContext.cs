using Microsoft.EntityFrameworkCore;
using ProyectoApiEF.Models;

namespace ProyectoApiEF
{
    public class TareaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }
    }
}
