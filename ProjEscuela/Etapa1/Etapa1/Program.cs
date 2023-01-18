using Etapa1.Entidades;
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

           // Cursos x= new Cursos { Nombre="602", Jornada=TiposJornada.Tarde};
           // esc.Cursos.Add(x);

            // Creacion de una lista de escuelas
            List<Escuela> escuelas = new List<Escuela>();


            // Se agrega la escuela anterior
            escuelas.Add(esc);

            //Se muestra la infomacion
            imprimirEscuela(escuelas);
            imprimirCursosEscuela(esc);
            Console.WriteLine("Ingrese el Nombre del curso");
            //string idCurso = Console.ReadLine();
            string nombreCurso = Console.ReadLine();
            //EliminarCurso(idCurso, esc.Cursos);
            //ElimiarCursoDelegate(idCurso, esc);
            EliminarCursoLambda(nombreCurso, esc);
            imprimirCursosEscuela(esc);

        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            // Se imprimen los cursos de UNA escuela
            Console.WriteLine("======================");
            foreach (Cursos c in escuela.Cursos)
            {
                Console.WriteLine($"Nombre: {c.Nombre} ID: {c.UniqueID} Jornada:{c.Jornada}");
            }
        }

        // Se imprimen LAS escuelas de una LISTA de escuelas
        private static void imprimirEscuela(List<Escuela> escuela)
        {
            foreach (var esc in escuela)
            {
                Console.WriteLine($"Nombre de escuela {esc.Nombre} \n" +
                    $"Año de creacion: {esc.AnioCreacion} \n" +
                    $"Pais: {esc.Pais} \n" +
                    $"Ciudad: {esc.Ciudad} \n" +
                    $"Tipo de escuela: {esc.tiposEscuela}");

            }
        }
        
        /// <summary>
        /// FORMAS DE ELIMINAR ELEMENTOS DENTRO DE UNA COLECCION "LIST"
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="cursos"></param>
        /// 
        
        // CICLOS
        private static void EliminarCurso(string idCurso, List<Cursos> cursos)
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
        private static void ElimiarCursoDelegate(string idCurso, Escuela escuela)
        {
            escuela.Cursos.RemoveAll(delegate (Cursos cur) { return idCurso == cur.UniqueID; });
        }

        // LAMBDA
        private static void EliminarCursoLambda(string nombreCur, Escuela escuela)
        {
            escuela.Cursos.RemoveAll((cur) => (nombreCur == cur.Nombre && cur.Jornada == TiposJornada.Tarde) );
        }
    }
}
