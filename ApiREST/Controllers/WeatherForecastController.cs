using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers;

[ApiController]
[Route("api/[controller]")] /* define la ruta en la barra de direcciones de manera 
                                implicita en base al nombre del controlador*/
public class WeatherForecastController : ControllerBase
{
    // Arreglo que contiene
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    // Crea una nueva lista del modelo WeatherForecast
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    // Constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        // Cada que se realice una peticion, se ejecuta todo el cuerpo del constructor
        Console.WriteLine("Inicio de ciclo for");
        for (int i = 0; i < 10000; i++)
        {
            Console.WriteLine(i);
        }

        /* Si la lista no contiene datos, entonces crea una coleccion Enumerable 
            de datos aleatoreos usando la sentencia .Select, y transformandola en List*/
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    // Verbo GET
    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/WeatherForecast")] // Define una ruta de manera explicita 
    [Route("[action]")] /* [action] hace referencia al nombre del metodo "GetW" automaticamente, 
                            sin importar si el nombre del metodo cambia */
    public IEnumerable<WeatherForecast> GetW()
    {
        return ListWeatherForecast;
    }

    // Verbo POST
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    // Verbo DELETE
    // {index} refiere al parameto de entrada en la URL de la posicion del elemento a eliminar
    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
