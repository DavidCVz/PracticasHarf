using ApiREST.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiREST.Models;

public class Categoria
{
    //[Key] // Indica una clave primaria
    public Guid CategoriaId { get; set; }

    //[Required] // Indica la propiedad NOT NULL en base de datos
    //[MaxLength(150)] // Indica una restriccion en la base de datos
    public string Nombre { get;set; }

    //[Required] // Indica la propiedad NOT NULL en base de datos
    public string Descripcion { get;set; }

    public int Peso { get;set; }

    [JsonIgnore] // Atributo que hace que cuando se haga una consulta
    // No traiga todos los registros de tareas
    public virtual ICollection<Tarea> Tareas { get; set; }

}