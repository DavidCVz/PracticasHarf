using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public class ObjetoEscuelaBase
    {
        public string UniqueID { get; set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase() 
        { 
            UniqueID= Guid.NewGuid().ToString();    
        }  
    }
}
