using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Evaluaciones
    {
        public string UniqueID { get; set; }
        public string Nombre { get; set; }
        public Alumnos Alumno { get; set; }
        public Asignaturas Asignatura { get; set; }
        public float Nota { get; set; }
        public Cursos Curso { get; set; }

        public Evaluaciones() { string UniqueID = Guid.NewGuid().ToString(); }
    }


}
