using ProyectoApiEF.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoApiEF.Models;

public class Categoria
{
    [Key] // Indica una clave primaria
    public Guid CategoriaId { get; set; }

    [Required] // Indica la propiedad NOT NULL en base de datos
    [MaxLength(150)] // Indica una restriccion en la base de datos
    public string Nombre { get;set; }

    [Required] // Indica la propiedad NOT NULL en base de datos
    public string Descripcion { get;set; }
    public virtual ICollection<Tarea> Tareas { get; set; }

}