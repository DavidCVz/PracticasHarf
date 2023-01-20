using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Alumnos
    {
        public string UniqueID { get; set; }
        public string Nombre { get; set; }

        public Alumnos() { string UniqueID = Guid.NewGuid().ToString(); }

       

    }
}
