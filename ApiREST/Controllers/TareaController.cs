using Microsoft.AspNetCore.Mvc;
using ApiREST.Services;
using ApiREST.Models;

namespace ApiREST.Controllers;

[Route("api/[controller]")] // "api/[controller]" Ruta dinamica que usa el nombre del controlador
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService Service)
    {
        tareaService = Service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        tareaService.Get();
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok("Registro guardado con exito");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok("Actualizacion correcta");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok("Elimincion exitosa");
    }
}