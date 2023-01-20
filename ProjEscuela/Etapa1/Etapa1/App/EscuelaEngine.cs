using System;
using System.Collections.Generic;
using System.Text;
using Etapa1.Entidades;
using Etapa1.Util;
using System.Linq;
using System.ComponentModel;
using System.Xml;

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

            // Carga de Entidades
            CargarCursos(esc);
            imprimirCursosEscuela();
            CargaAsignatuas(esc.Cursos);
            CargarAlumnos(esc.Cursos);
            CargaEvaluaciones(esc);

        }

        private void CargaAsignatuas(List<Cursos> cursos)
        {
            var listaAsignaturas = new List<Asignaturas>()
            {
                new Asignaturas() { Nombre = "POO" },
                new Asignaturas() { Nombre = "Estructura de Datos" },
                new Asignaturas() { Nombre = "Fundamentos de Programacion" },
                new Asignaturas() { Nombre = "Topicos Avanzados" },
                new Asignaturas() { Nombre = "Programacion Logica y Funcional"},
            };

            foreach (var c in cursos)
            {
                c.Asignaturas = listaAsignaturas;
            }
        }

        private void CargaEvaluaciones(Escuela esc)
        {
            var rnd = new Random();
            int contador = 0;

            foreach (var cur in esc.Cursos)
            {
                foreach (var asig in cur.Asignaturas)
                {
                    var listaEvaluaciones =
                    from alumn in cur.Alumnos
                    from a in cur.Asignaturas
                    select new Evaluaciones()
                    {
                        UniqueID = Guid.NewGuid().ToString(),
                        Nombre = (rnd.Next() % 2 == 0) ? "Ordinario" : "Extraordinario",
                        Alumno = alumn,
                        Asignatura = a,
                        Nota = float.Parse(Convert.ToString(rnd.NextDouble() * 5).Substring(0, 4)),
                        Curso = cur
                    };

                    if (esc.Evaluaciones == null)
                    {
                        esc.Evaluaciones = listaEvaluaciones.ToList();
                    }
                    else
                    {
                        esc.Evaluaciones.AddRange(listaEvaluaciones);

                    }

                }
            }

            foreach (var eval in esc.Evaluaciones)
            {
                contador++;
                Console.WriteLine($"{contador} || " +
                    $"{eval.Alumno.UniqueID.Substring(0,10)} " +
                    $"{eval.Asignatura.Nombre} " +
                    $"{eval.Nota} " +
                    $"{eval.Curso.Nombre} ");
            }
        }

        private void CargarAlumnos(List<Cursos> cursos)
        {
            Util.Utilidades.DibujarLinea();
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid" };
            string[] apellido1 = { "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumnos() { UniqueID = Guid.NewGuid().ToString(), Nombre = $"{n1} {n2} {a1}" };

            //foreach (var a in listaAlumnos)
            //{
            //    //a.UniqueID = new Random().Next().ToString();
            //    Console.WriteLine($"ID: {a.UniqueID} Nombre: {a.Nombre}");
            //}

            foreach (var c in cursos)
            {
                c.Alumnos = listaAlumnos.OrderBy((al) => al.UniqueID).Take(10).ToList();
            }

            Util.Utilidades.DibujarLinea();
            foreach (var cur in cursos)
            {
                Console.WriteLine(cur.Nombre);
                foreach (var al in cur.Alumnos)
                {
                    Console.WriteLine($"ID: {al.UniqueID} Nombre: {al.Nombre}");
                }
            }
        }

        public void CargarCursos(Escuela esc)
        {
            // El objeto recibe una nueva lista de curso creada en su definicion
            esc.Cursos = (new List<Cursos>()
            {
                    new Cursos(){Nombre = "101",},
                    new Cursos(){Nombre = "201",},
                    new Cursos(){Nombre = "301",},
                    new Cursos(){Nombre = "Prueba", Jornada = TiposJornada.Tarde},
            });
            
            // Se inicializa el atributo de la clase
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

        public void MostrarEvaluacionesCurso(List<Cursos> cursos)
        {
            foreach (var cur in cursos)
            {
                Utilidades.DibujarLinea(20);

            }
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
