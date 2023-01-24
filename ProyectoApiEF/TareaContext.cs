using Microsoft.EntityFrameworkCore;
using ProyectoApiEF.Models;

namespace ProyectoApiEF
{
    public class TareaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

        //Definiendo las reglas de los atributos de cada entidad (Tabla)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tabla Categoria (PADRE)
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired();
            });

            //Table Tarea (HIJA)
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                // DEFINICION PARA CLAVES FORANEAS
                // p.Categoria es la propiedad virtual en la clase Tarea 
                // p.Tareas es la propiedad virtual en la clase Categoria
                // p.CategoriaId, es la clave que relaciona las tablas en la clase Tarea
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);

                //Para ignorar atributos de la clase
                tarea.Ignore(p => p.Resumen);
            });
        }
    }
}
