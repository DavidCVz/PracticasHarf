using System;
using System.Collections.Generic;
using System.Text;
using Etapa1.Entidades;
using Etapa1.Util;

namespace Etapa1.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine() 
        {
            
        }

        public void inicializar()
        {
            // Creacion de objeto Escuela
            Escuela esc = new Escuela("ITMina", 1986);

            // Asignacion de valores a los atributos del objeto
            esc.Pais = "Mexico";
            esc.Ciudad = "Coatzacoalcos";
            esc.tiposEscuela = TiposEscuela.Primaria;
            esc.tiposJornada = TiposJornada.Noche;

            // El objeto recibe una nueva lista de curso creada en su definicion
            esc.Cursos = (new List<Cursos>()
            {
                    new Cursos(){Nombre = "101",},
                    new Cursos(){Nombre = "201",},
                    new Cursos(){Nombre = "301",},
                    new Cursos(){Nombre = "Prueba", Jornada = TiposJornada.Tarde},
            });

            esc.Cursos.Add(new Cursos("Prueba", TiposJornada.Tarde));

            Escuela = esc;
        }

        public void EliminarCurso()
        {
            Console.WriteLine("Ingrese el Nombre del curso");
            //string idCurso = Console.ReadLine();
            string nombreCurso = Console.ReadLine();
            //EliminarCurso(idCurso, esc.Cursos);
            //ElimiarCursoDelegate(idCurso, esc);
            EliminarCursoLambda(nombreCurso);
            imprimirCursosEscuela();
        }


        public void imprimirCursosEscuela()
        {
            // Se imprimen los cursos de UNA escuela
            Utilidades.DibujarLinea();
            foreach (Cursos c in Escuela.Cursos)
            {
                Console.WriteLine($"Nombre: {c.Nombre} ID: {c.UniqueID} Jornada:{c.Jornada}");
            }
        }

        // Se imprimen LAS escuelas de una LISTA de escuelas
        public void imprimirEscuela()
        {
            Utilidades.DibujarTitulo("DATOS DE LA ESCUELA");
            Console.WriteLine($"Nombre de escuela {Escuela.Nombre} \n" +
                $"Año de creacion: {Escuela.AnioCreacion} \n" +
                $"Pais: {Escuela.Pais} \n" +
                $"Ciudad: {Escuela.Ciudad} \n" +
                $"Tipo de escuela: {Escuela.tiposEscuela}");

        }

        /// <summary>
        /// FORMAS DE ELIMINAR ELEMENTOS DENTRO DE UNA COLECCION "LIST"
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="cursos"></param>
        /// 

        // CICLOS
        private void EliminarCurso(string idCurso, List<Cursos> cursos)
        {
            //Recorrremos la lista de cursos en la escuela
            for (int i = 0; i < cursos.Count; i++)
            {
                // Si se encuentra el ID, se removera el curso comparando
                // el objeto encontrado con el de la lista de la escuela
                if (cursos[i].UniqueID == idCurso)
                {
                    Console.WriteLine($"Eliminando curso: {cursos[i].Nombre}");
                    cursos.Remove(cursos[i]);
                }
            }

            //int indice = 0;
            //var cursoX = new Cursos();

            //foreach (var cur in cursos)
            //{
            //    if (cur.UniqueID == idCurso)
            //    {
            //        cursoX = cur;
            //    }
            //}
            //cursos.Remove(cursoX);
        }

        // DELEGATE
        private void ElimiarCursoDelegate(string idCurso)
        {
            Escuela.Cursos.RemoveAll(delegate (Cursos cur) { return idCurso == cur.UniqueID; });
        }

        // LAMBDA
        private void EliminarCursoLambda(string nombreCur)
        {
            Escuela.Cursos.RemoveAll((cur) => (nombreCur == cur.Nombre && cur.Jornada == TiposJornada.Tarde));
        }
    }
}
