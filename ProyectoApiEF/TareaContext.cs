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
            //Configurando las semillas
            #region SEEDS

            //Seeds de Categorias
            List<Categoria> categoriaInit = new List<Categoria>();
            categoriaInit.Add(new Categoria { 
                CategoriaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502763"),
                Nombre = "Actividades pendientes",
                Peso = 20,
            });
            categoriaInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502702"),
                Nombre = "Actividades personales",
                Peso = 50,
            });
            categoriaInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("a91aee3b-2de8-4020-a99c-682aea2515d7"),
                Nombre = "Actividades laborales",
                Peso = 100,
            });


            //Seeds de Tareas
            List<Tarea> tareasInit = new List<Tarea>();

            tareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502710"),
                CategoriaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502763"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios publicos",
                FechaCreacion = DateTime.Now,
            });
            tareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502720"),
                CategoriaId = Guid.Parse("e2a2a013-09ce-4446-bfc1-3aacab502702"),
                PrioridadTarea = Prioridad.Bajo,
                Titulo = "Terminar de ver serie The Last Of Us",
                FechaCreacion = DateTime.Now,
            });
            tareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("5af3b1d4-5fc1-4445-87f3-2dbe112d0286"),
                CategoriaId = Guid.Parse("a91aee3b-2de8-4020-a99c-682aea2515d7"),
                PrioridadTarea = Prioridad.Alta,
                Titulo = "Realizar examen de certificacion",
                FechaCreacion = DateTime.Now,
            });
            #endregion SEEDS

            //Tabla Categoria (PADRE)
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                // Clave primaria
                categoria.HasKey(p => p.CategoriaId);

                // Atributos
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);

                // Para agregar datos iniciales a la tabla Categoria se usa la funcion HasData
                // recibiendo como parametro una lista de datos de Categorias
                categoria.HasData(categoriaInit);
            });

            //Table Tarea (HIJA)
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");

                //Clave primaria
                tarea.HasKey(p => p.TareaId);

                // DEFINICION PARA CLAVES FORANEAS
                // p.Categoria es la propiedad virtual en la clase Tarea 
                // p.Tareas es la propiedad virtual en la clase Categoria
                // p.CategoriaId, es la clave que relaciona las tablas en la clase Tarea
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                
                //Atributos
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);

                //Para ignorar atributos de la clase
                tarea.Ignore(p => p.Resumen);

                // Para agregar datos iniciales a la tabla Tarea se usa la funcion HasData
                // recibiendo como parametro una lista de datos de Categorias
                tarea.HasData(tareasInit);
            });
        }
    }
}
