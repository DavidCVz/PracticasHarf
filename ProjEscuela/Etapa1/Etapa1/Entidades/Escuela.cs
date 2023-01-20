using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Etapa1.Entidades
{
    public class Escuela
    {
        string nombre;

        //Forma 1. Forma de acceder y modificar una propiedad de clase
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); }
        }

        //Forma 2. Forma simplificada de acceder y modificar una propiedad
        //En esta forma no es necesario definir la variable al inicio

        public int AnioCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela tiposEscuela { get; set; }
        public TiposJornada tiposJornada { get; set; }

        public List<Cursos> Cursos { get; set; }

        public List<Evaluaciones> Evaluaciones { get; set; }

        //public Cursos[] cursos { get; set; }

        //public Escuela(string nombre, int AnioCreacion)
        //{
        //    this.nombre = nombre;
        //    this.AnioCreacion = AnioCreacion;
        //}

        // METODO DE ASIGNACION CON TUPLAS
        // Argumentos | Atributos de clase | Asignacion de Argumentos
        public Escuela(string nombre, int Anio) => (Nombre, AnioCreacion) = (Nombre, Anio); 

    }
}
