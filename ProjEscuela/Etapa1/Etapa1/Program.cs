using Etapa1.Entidades;
using Etapa1.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuelaEngine escuela = new EscuelaEngine();

            escuela.inicializar();
            escuela.imprimirEscuela();
            escuela.imprimirCursosEscuela();
            escuela.EliminarCurso();
        }
    }
}
