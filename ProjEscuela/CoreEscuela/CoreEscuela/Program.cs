using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string nombre;

        public string direccion;

        public int anioFundacion;

        public void Timbrar()
        {
            Console.WriteLine("Timbrando...");
            Console.Beep(10000, 3000);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Escuela escuela = new Escuela();

            escuela.nombre = "ITMina";
            escuela.direccion = "Av Universidad S/N";
            escuela.anioFundacion = 1983;

            escuela.Timbrar();
        }
    }
}
