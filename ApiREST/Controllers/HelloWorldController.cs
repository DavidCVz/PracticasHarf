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

    // Se recibe la instancia del servicio en la peticion
    public HelloWorldController(IHelloWorldService HelloWorld)
    {
        helloWorldService = HelloWorld;
    }

    public IActionResult Get(){
        return Ok(helloWorldService.GetHelloWorld());
    }
}