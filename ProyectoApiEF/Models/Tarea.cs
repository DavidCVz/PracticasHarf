using ProyectoApiEF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoApiEF.Models
{
    public class Tarea
    {
        //[Key] // Indica una clave primaria
        public Guid TareaId { get; set; }

        //[ForeignKey("CategoriaId")] // Indica una clave foranea
        public Guid CategoriaId { get; set; }

        //[Required] // Indica la propiedad NOT NULL en base de datos
        //[MaxLength(200)] // Indica una restriccion en la base de datos
        public string Titulo { get; set;}
        public Guid Descripcion { get; set; }
        public Prioridad PrioridadTarea { get; set;}
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }

        [NotMapped] //Para indicar que un atributo no se creara en la base de datos
        public string Resumen { get; set; }
    }

    public enum Prioridad
    {
        Bajo,
        Media,
        Alta
    }
}
