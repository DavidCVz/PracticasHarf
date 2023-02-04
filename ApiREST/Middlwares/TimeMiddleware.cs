public class TimeMiddleware
{
    // Propiedad que ayuda a invocar al middleware siguiente dentro del ciclo de middlewares
    readonly RequestDelegate next;

    // Constructor que ayuda a recibir la dependencia RequestDelegate
    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest; // Se asigna la informacion para poder hacer el llamado al sig middleware
    }

    // Metodo "Invoke" por defecto que viene en todos los middlewares
    public async Task Invoke(HttpContext context) // "context" representa el Request, toda la info se encuentra en este objeto
    {
        // Hace el llamado del siguiente request
        await next(context); /*Ejecuta todos los middlewares que esten despues
        de "app.UseTimeMiddleware();" en "Program.cs", y luego ejecuta la tarea
        que se encuentra dentro del "if"*/

        /* Si en el Request dentro del Query, dentro de los parametros que se colocan en la url
            existe algun parametro que tenga una clave igual a time */
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            Console.WriteLine("Inicia if de Time");
            /*Si existe, dentro de la respuesta del request, se escribe con el WriteAsync la hora actual*/
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            Console.WriteLine("Termina de dar la hora");
            return;
        }
        /*await next(context); /* Si se mueve esta tarea al final entonces solo se ejecutara la sentencia if,
        descartando las operaciones en las rutas de los*/
    }
}

/*Clase que ayudara a agregar el nuevo middleware dentro de la configuracion de la API (program.cs)*/
public static class TimeMiddlewareExtension
{
    /*Metodo que recibe el IAplicationBuilder y lo retorna con el middleware agregado*/
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) // Recibe el parametro del contexto actual
    {
        // Se retorna la instancia del middleware personalizado TimeMiddleware
        return builder.UseMiddleware<TimeMiddleware>();
    }
}