using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Util
{
    public static class Utilidades
    {
        public static void DibujarLinea(int tamano = 10)
        {
            WriteLine("".PadLeft(tamano, '='));
        }

        public static void DibujarTitulo(string titulo)
        {
            DibujarLinea(titulo.Length);
            WriteLine(titulo);
            DibujarLinea(titulo.Length);

        }
    }
}
