using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    public interface IDireccion
    {
        string Direccion { get; set; }
        void MostrarDireccion();
    }
}
