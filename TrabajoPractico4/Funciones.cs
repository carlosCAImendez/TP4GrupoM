using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Reflection;

namespace TrabajoPractico4
{
    class Funciones
    {

        #region Cargar bases de datos
        public static List<Alumnos> CargarAlumnos()
        {
            List<Alumnos> ListadeAlumnos = new List<Alumnos>();
            string direccionAlumnos = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "alumnos.txt");
            FileInfo archivobdAlumnos = new FileInfo(direccionAlumnos);
            try
            {
                StreamReader abridor = archivobdAlumnos.OpenText();
                if (archivobdAlumnos.Length == 0)
                {
                    Funciones.MostrarError("No se encuentra la base de datos de alumnos. No se puede continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                while (!abridor.EndOfStream)
                {
                    string Linea = abridor.ReadLine();
                    string[] Vector = Linea.Split(',');
                    if (!(Vector[0] == "Registro") || !(Vector[1] == "Nombre") || !(Vector[2] == "Apellido") || !(Vector[3] == "Dni") || !(Vector[4] == "Email") || !(Vector[5] == "Carrera"))
                    {
                        Alumnos A = new Alumnos();
                        A.nroRegistro = int.Parse(Vector[0]);
                        A.nombre = Vector[1];
                        A.apellido = Vector[2];
                        A.nroDNI = int.Parse(Vector[3]);
                        A.email = Vector[4];
                        A.nroCarrera = int.Parse(Vector[5]);
                        ListadeAlumnos.Add(A);
                    }
                }
                abridor.Close();
                return ListadeAlumnos;
            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo cargar la base de datos alumnos. Asegurese que no este abierta y vuelva a abrir el programa:  " + e.Source);
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }
        }

        public static List<Materias> CargarMaterias()
        {
            List<Materias> ListadeMaterias = new List<Materias>();
            string direccionMaterias = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "materias.txt");
            FileInfo archivobdMaterias = new FileInfo(direccionMaterias);
            try
            {
                StreamReader abridor = archivobdMaterias.OpenText();
                if (archivobdMaterias.Length == 0)
                {
                    Funciones.MostrarError("No se encuentra la base de datos de alumnos. No se puede continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);

                }
                while (!abridor.EndOfStream)
                {
                    string Linea = abridor.ReadLine();
                    string[] Vector = Linea.Split(',');
                    if (!(Vector[0] == "NumeroDeMateria") || !(Vector[1] == "NumeroDeCarrera") || !(Vector[2] == "Nombre"))
                    {
                        Materias A = new Materias();
                        A.nroMateria = int.Parse(Vector[0]);
                        A.nroCarrera = int.Parse(Vector[1]);
                        A.nombreMateria = Vector[2];
                        ListadeMaterias.Add(A);
                        
                    }
                }
                abridor.Close();
                return ListadeMaterias;
            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo cargar la base de datos de materias. Asegurese que no este abierta y vuelva a abrir el programa:  " + e.Message);
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }
        }

        public static List<Cursos> CargarCursos()
        {
            List<Cursos> ListadeCursos = new();
            string direccionCursos = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "cursos.txt");
            FileInfo archivobdCursos = new FileInfo(direccionCursos);
            try
            {
                StreamReader abridor = archivobdCursos.OpenText();
                if (archivobdCursos.Length == 0)
                {
                    Funciones.MostrarError("No se encuentra la base de datos de alumnos. No se puede continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                while (!abridor.EndOfStream)
                {
                    string Linea = abridor.ReadLine();

                    string[] Vector = Linea.Split(',');
                    if (Vector[0] == "CodigoCurso" && Vector[1] == "TipodeCurso" && Vector[2] == "Profesor" && Vector[3] == "Horario" && Vector[4] == "Sede" && Vector[5] == "Catedra" && Vector[6] == "CodigoMateria")
                    {
                        // Con esto nos salteamos la primera linea.
                    }
                    else
                    {
                        Cursos C = new Cursos();
                        C.codigoCurso = Int32.Parse(Vector[0]);
                        C.descripcionCurso = Vector[1];
                        C.nombreProfesor = Vector[2];
                        C.horarioCurso = Vector[3];
                        C.sedeCurso = Vector[4];
                        C.catedraCurso = Vector[5];
                        C.codigoMateria = Int32.Parse(Vector[6]);
                        ListadeCursos.Add(C);


                    }
                }
                abridor.Close();
                return ListadeCursos;


            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo cargar la base de datos de materias. Asegurese que no este abierta y vuelva a abrir el programa:  " + e.Message);
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }


        }
        public static List<Inscripciones> CargarInscripciones()
        {
            List<Inscripciones> ListadeInscripciones = new();
            string direccionInscripciones = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "inscripciones.txt");
            FileInfo archivobdInscripciones = new FileInfo(direccionInscripciones);
            try
            {
                StreamReader abridor = archivobdInscripciones.OpenText();
                if (archivobdInscripciones.Length == 0)
                {
                    abridor.Close();
                    return null;
                  
                }
                while (!abridor.EndOfStream)
                {
                    string Linea = abridor.ReadLine();

                    string[] Vector = Linea.Split(',');
              
                        Inscripciones D = new Inscripciones();
                        D.nroRegistro = Int32.Parse(Vector[0]);
                        D.nroCarrera = Int32.Parse(Vector[1]);
                        D.nroMateria = Int32.Parse(Vector[2]);
                        D.codigoCurso = Int32.Parse(Vector[3]);
                        ListadeInscripciones.Add(D);


                    
                }
                abridor.Close();
                return ListadeInscripciones;


            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo cargar la base de datos de materias. Asegurese que no este abierta y vuelva a abrir el programa:  " + e.Message);
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }


        }
        public static List<MateriasAprobadas> CargarMateriasAprobadas()
        {
         
            List<MateriasAprobadas> ListadeAprobadas = new();
            string direccionAprobadas = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "materiasAprobadas.txt");
            FileInfo archivobdAprobadas = new FileInfo(direccionAprobadas);
            try
            {
                StreamReader abridor = archivobdAprobadas.OpenText();
                if (archivobdAprobadas.Length == 0)
                {
                    Funciones.MostrarError("No se encuentra la base de datos de materias aprobadas. No se puede continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                while (!abridor.EndOfStream)
                {
                    string Linea = abridor.ReadLine();

                    string[] Vector = Linea.Split(',');
                    if (Vector[0] == "Registro" && Vector[1] == "NumeroDeMateria")
                    {
                        // Con esto nos salteamos la primera linea.
                    }
                    else
                    {
                        MateriasAprobadas C = new MateriasAprobadas();
                        C.nroRegistro = Int32.Parse(Vector[0]);
                        C.nroMateria = Int32.Parse(Vector[1]);
                        ListadeAprobadas.Add(C);


                    }
                }
                abridor.Close();
                return ListadeAprobadas;


            }
            catch (IOException e)
            {
                Console.WriteLine("No se pudo cargar la base de datos de materias. Asegurese que no este abierta y vuelva a abrir el programa:  " + e.Message);
                Console.ReadLine();
                Environment.Exit(0);
                return null;
            }


        }



        public static void existenlasBases()
        {
            string direccionAlumnos = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "alumnos.txt");
            string direccionCursos = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "cursos.txt");
            string direccionMaterias = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "materias.txt");
            string direccionMateriasAprobadas = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "materiasAprobadas.txt");
            string direccionAsignacion = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "inscripciones.txt");
            FileInfo elPlan = new FileInfo(direccionAlumnos);
            FileInfo elPlan3 = new FileInfo(direccionCursos);
            FileInfo elPlan4 = new FileInfo(direccionAsignacion);
            FileInfo elPlan5 = new FileInfo(direccionMaterias);
            FileInfo elPlan6 = new FileInfo(direccionMateriasAprobadas);
            if (!elPlan.Exists)
            {
                Funciones.MostrarError("No se encuentra la base de datos de alumnos. No se puede continuar.");
                Console.ReadLine();
                Environment.Exit(0);

            }
            if (!elPlan3.Exists)
            {
                Funciones.MostrarError("No se encuentra la base de datos de cursos. No se puede continuar.");
                Console.ReadLine();
                Environment.Exit(0);

            }
            if (!elPlan4.Exists)
            {
                try
                {
                    File.Create(direccionAsignacion).Dispose();

                }
                catch
                {
                    Funciones.MostrarError("No se pudo crear la base de datos de inscripciones. No se puede continuar.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }


            }
            if (!elPlan5.Exists)
            {
                Funciones.MostrarError("No se encuentra la base de datos de materias. No se puede continuar.");
                Console.ReadLine();
                Environment.Exit(0);

            }
            if (!elPlan6.Exists)
            {
                Funciones.MostrarError("No se encuentra la base de datos de materias aprobadas. No se puede continuar.");
                Console.ReadLine();
                Environment.Exit(0);

            }


        }
        #endregion

        #region GuardarInscripciones
        public static bool ActualizarInscripciones(string linea)
        {
            string direccion = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "inscripciones.txt");
            try
            {
                StreamWriter actualizador = new StreamWriter(direccion, true);
                if (linea.Length == 0)
                {
                    return false;
                }
                else
                {
                    actualizador.WriteLine(linea);
                    actualizador.Close();
                    Console.WriteLine("Inscripcion a materia realizada.");
                    return true;
                }
            }
            catch
            {
                Funciones.MostrarError("No se pudo guardar la inscripcion a la materia.");
                return false;
            }
        }
        #endregion

        #region funciones comunes
        public static void mostrarMenu()
        {
           
            Console.WriteLine("-------------Sistema de inscripciones------------");
            Console.WriteLine("¿Que desea hacer?");
            Console.WriteLine("1 - Inscribirse a materias");
            Console.WriteLine("2 - Solicitar certificado de inscripcion");
            Console.WriteLine("3 - Salir");
        }
        public static string MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
            return null;
        }

        public static void salir()
        {
            Console.WriteLine("Gracias por usar el sistema de asignaciones.");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        public static string MostrarCarrera(int nroCarrera)
        {
            switch (nroCarrera)
            {
                case 1:
                    return "Contador Publico";
                case 2:
                    return "Lic. en Administración";
                case 3:
                    return "Lic. en Sistemas de la información de las organizaciones";
                case 4:
                    return "Lic. en Economia";
                case 5:
                    return "Actuario en Administración";
                case 6:
                    return "Actuario en Economia";
                case 7:
                    string carreras = ("1- Contador Publico\n" + "2- Lic. en Administración\n" + "3- Lic. en Sistemas de la información de las organizaciones \n" + "4- Lic. en Economia\n" + "5- Actuario en Administración\n" + "6- Actuario en Economia");
                    return carreras;

                default:
                    return null;
            }
        }

        public static int ContarInscripciones(int opcion)
        {
            if (opcion == 1)
            {
                string direccion = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "inscripciones.txt");
                FileInfo elPlan = new FileInfo(direccion);
                int cantidad = 0;
                try
                {
                    StreamReader abridor = elPlan.OpenText();
                    while (!abridor.EndOfStream)
                    {
                        string Linea = abridor.ReadLine();

                        cantidad = cantidad + 1;


                    }
                    abridor.Close();
                    return cantidad;
                }
                catch
                {
                    Funciones.MostrarError("No hay inscripciones para mostrar.");
                    Console.ReadLine();
                    return 0;
                }
            }
            else
            {
                string direccion = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "inscripciones.txt");
                FileInfo elPlan = new FileInfo(direccion);
                int cantidad = 0;
                try
                {
                    StreamReader abridor = elPlan.OpenText();
                    while (!abridor.EndOfStream)
                    {
                        string Linea = abridor.ReadLine();

                        cantidad = cantidad + 1;


                    }
                    abridor.Close();
                    return cantidad;
                }
                catch
                {
                    return 0;
                }
            }

        }
        #endregion

    }
}
