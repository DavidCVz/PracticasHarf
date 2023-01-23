using ProyectoApiEF.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoApiEF.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nombre { get;set; }

    [Required]
    public string Descripcion { get;set; }
    public virtual ICollection<Tarea> Tareas { get; set; }

}