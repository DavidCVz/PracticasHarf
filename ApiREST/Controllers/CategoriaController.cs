using Microsoft.AspNetCore.Mvc;
using ApiREST.Services;
using ApiREST.Models;

namespace ApiREST.Controllers;

[Route("api/[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class CategoriaController : ControllerBase
{
    // Atributo que contiene la abstraccion de las operaciones en Categorias
    ICategoriaService categoriaService; 

    // Se recibe el servicio
    public CategoriaController(ICategoriaService service)
    {
        categoriaService = service;
    }

    // Retorna una consulta de todos los datos
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok("Registro guardado con exito");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.Update(id, categoria);
        return Ok("Actualizacion exitosa");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }
}