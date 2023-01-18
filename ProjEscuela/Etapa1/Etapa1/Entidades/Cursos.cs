using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Cursos
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }
        public Cursos() 
        { 
            UniqueID = Guid.NewGuid().ToString();
        }

        public Cursos(string nombre, TiposJornada jornada)
        {
            Nombre = nombre;
            Jornada = jornada;
            UniqueID = Guid.NewGuid().ToString();
        }
    }

}
