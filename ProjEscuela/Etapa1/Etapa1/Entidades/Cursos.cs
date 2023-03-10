using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Cursos : ObjetoEscuelaBase
    {

        public TiposJornada Jornada { get; set; }
        public List<Alumnos> Alumnos { get; set; }
        public List<Asignaturas> Asignaturas { get; set; }
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
