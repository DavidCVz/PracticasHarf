var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// La inyeccion de dependencias siempre va antes de la construccion de la API
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); // Se creara una instancia de la dependencia a nivel de controlador/clase
// builder.Services.AddSingleton<>; // Se crea una unica instancia a nivel de API
builder.Services.AddSingleton<IHelloWorldService>(p => new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// MIDDLEWARES

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage(); //Pagina de i

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
