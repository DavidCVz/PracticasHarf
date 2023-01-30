#region ELEMENTOS DEL CONTROLADOR
    
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers;

[ApiController]
[Route("api/[controller]")] /* define la ruta en la barra de direcciones de manera 
                                implicita en base al nombre del controlador*/
#endregion ELEMENTOS DEL CONTROLADOR

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService; // objeto que hace referencia al servicio

    private readonly ILogger<HelloWorldController> _logger;


    // Se recibe la instancia del servicio en la peticion
    public HelloWorldController(IHelloWorldService HelloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger; //Recibe la instancia del logger

        helloWorldService = HelloWorld; // Inicializa la dependencia
    }

    [HttpGet]
    public IActionResult Get(){
        _logger.LogInformation("Se ha retornado el mensaje de la dependencia");
        return Ok(helloWorldService.GetHelloWorld());
    }
}