using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class Asignaturas
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }
        public Asignaturas() { string UniqueID = Guid.NewGuid().ToString(); }

    }
}
