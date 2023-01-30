
public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld(){
        return "Hello World!";
    }
}

// La interfaz nos va a ayudar a manejar un tipo abstracto que se puede cambiar en otro momento
// Esta interfaz solo EXPONE los metodos y atributos de una clase
public interface IHelloWorldService
{
    public string GetHelloWorld();
}