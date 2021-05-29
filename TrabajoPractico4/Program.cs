using System;
using System.Collections.Generic;
using System.Linq;
/*
 *        Trabajo Practico N° 4 - Inscripcion.
 *        Integrantes: Carlos Charletti
 *                     Clara Zaragosa
 *                     José Llauró
 *                     Tomas Agustin Garcia Martinez
 *                     
 *        1° Cuatrimestre - Año 2021 - Curso: CAI - Mendez.
 * */


namespace TrabajoPractico4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variables para inscripciones
            int numeroRegistro;
            bool registro = false;
            bool yaseInscribio = false;
            // Fin nro registro verif.
            bool parseCuartaMateria = false;
            string cuartaMateria;
            int cicloFORcuartaMateria = 0;
            bool parseCarreras = false;
            int numerocarrera = 0;
            bool parseCodigoMateria = false;
            int codigoMateria = 0;
            bool parseCodigoCurso = false;
            int codigoCurso = 0;
            // Fin inscripcion

            #endregion
            bool seguienMenu = true;
            while (seguienMenu)
            {
                Funciones.mostrarMenu();
                int opcion;
                if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                          Funciones.existenlasBases();
                            List<Alumnos> ListadeAlumnos = new();
                            ListadeAlumnos = Funciones.CargarAlumnos();
                            List<Materias> ListadeMaterias = new();
                            ListadeMaterias = Funciones.CargarMaterias();
                            List<Cursos> ListadeCursos = new();
                            ListadeCursos = Funciones.CargarCursos();
                     

                            Console.WriteLine("Ingrese su numero de registro");
                            #region Buscar si el alumno existe en la bd
                            do
                            {
                                if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out numeroRegistro))
                                {
                                    Alumnos buscarRegistro = ListadeAlumnos.Find(x => x.nroRegistro == numeroRegistro);
                                    if (ListadeAlumnos.Contains(buscarRegistro))
                                    {
                                        List<Inscripciones> ListadeInscripciones = new();
                                        ListadeInscripciones = Funciones.CargarInscripciones();
                                        if (Funciones.ContarInscripciones(0) == 0)
                                        {

                                        }
                                        else
                                        {
                                            if (ListadeInscripciones.Count(x => x.nroRegistro == numeroRegistro) >= 1)
                                            {
                                                Funciones.MostrarError("Usted ya esta inscripto a las materias.");
                                                yaseInscribio = true;
                                                break;
                                            }
                                        }
                                       
                                        registro = true;
                                        Console.Clear();
                                        Console.WriteLine("Alumno: {0} {1}", buscarRegistro.nombre, buscarRegistro.apellido);
                                        Console.WriteLine("Usted esta oficialmente inscripto para la carrera de: {0} ", Funciones.MostrarCarrera(buscarRegistro.nroCarrera));
                                    }
                                    else
                                    {
                                        Funciones.MostrarError("El numero de registro no se encuentra en la base de datos. Ingrese nuevamente.");
                                        
                                    }

                                }
                                else
                                {
                                    Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                }
                            } while (registro == false);
                            #endregion

                            if (yaseInscribio == true) { break; }

                            #region Cuarta materia
                            //Comprobamos si quiere inscribirse a una 4ta materia
                            Console.WriteLine("¿Desea inscribirse a una cuarta materia? S/N");
                            do
                            {
                                cuartaMateria = Console.ReadLine();
                                cuartaMateria.Trim();
                                if (cuartaMateria == "S" || cuartaMateria == "s")
                                {
                                    cicloFORcuartaMateria = 3;
                                    parseCuartaMateria = true;
                                }
                                else if (cuartaMateria == "N" || cuartaMateria == "n")
                                {
                                    cicloFORcuartaMateria = 2;
                                    parseCuartaMateria = true;
                                }
                                else
                                {
                                    Funciones.MostrarError("Lo ingresado no es una opcion correcta. Ingrese nuevamente.");
                                }

                            }
                            while (parseCuartaMateria == false);
                            #endregion

                            for (int i = 0; i <= cicloFORcuartaMateria; i++)
                            {
                                Console.Clear();
                                Console.WriteLine("Seleccione la carrera para la materia N° {0} a inscribir:\n", (i + 1));
                                Console.WriteLine(Funciones.MostrarCarrera(7));

                                do
                                {
                                    if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out numerocarrera))
                                    {
                                        switch (numerocarrera)
                                        {
                                            case 1:
                                                parseCarreras = true;
                                                break;
                                            case 2:
                                                parseCarreras = true;
                                                break;
                                            case 3:
                                                parseCarreras = true;
                                                break;
                                            case 4:
                                                parseCarreras = true;
                                                break;
                                            case 5:
                                                parseCarreras = true;
                                                break;
                                            case 6:
                                                parseCarreras = true;
                                                break;
                                            default:
                                                Funciones.MostrarError("Lo ingresado no es una opcion valida. Ingrese nuevamente.");
                                                break;

                                        }
                                    }
                                    else 
                                    {
                                        Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                    }
                                }
                                while (parseCarreras == false);

                                Console.WriteLine("Las materias disponibles para la carrera {0} son: \n ", Funciones.MostrarCarrera(numerocarrera));
                                 foreach ( var buscarMaterias in ListadeMaterias.Where(x => (x.nroCarrera == numerocarrera)))
                                 {
                                    // desplegamos lista de materias de esa carrera.
                                    Console.WriteLine("{0}({1})", buscarMaterias.nombreMateria,buscarMaterias.nroMateria);
                                 }

                                Console.WriteLine("\nIngrese el codigo de la materia en la que se quiere anotar: \n");
                                do
                                {
                                    if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out codigoMateria))
                                    {
                                        Materias buscarCodigo = ListadeMaterias.Find(x => x.nroMateria == codigoMateria);
                                        // Con esto chequeamos que el tipo no se quiera inscribir 2 veces a la misma materia.
                                        if (Funciones.ContarInscripciones(0) == 0)
                                        {
                                            if (ListadeMaterias.Contains(buscarCodigo))
                                            {
                                                parseCodigoMateria = true;

                                            }
                                            else
                                            {
                                                Funciones.MostrarError("No se ha encontrado una materia con ese codigo. Ingrese nuevamente. \n");
                                            }
                                        }
                                        else 
                                        {
                                            List<Inscripciones> ListadeInscripciones = new();
                                            ListadeInscripciones = Funciones.CargarInscripciones();
                                            Inscripciones buscarInscripciones = ListadeInscripciones.Find(x => (x.nroMateria == codigoMateria) && (x.nroRegistro == numeroRegistro));
                                            if (ListadeInscripciones.Contains(buscarInscripciones))
                                            {
                                                Funciones.MostrarError("No podes inscribirte 2 veces a la misma materia. Ingrese nuevamente. \n");
                                            }
                                            else
                                            {
                                                if (ListadeMaterias.Contains(buscarCodigo))
                                                {
                                                    parseCodigoMateria = true;

                                                }
                                                else
                                                {
                                                    Funciones.MostrarError("No se ha encontrado una materia con ese codigo. Ingrese nuevamente. \n");
                                                }
                                            }
                                        }
                                                                         
                                    }
                                    else
                                    {
                                        Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                    }

                                }
                                while (parseCodigoMateria == false);
                                Console.Clear();
                                Console.WriteLine("\n Los cursos disponibles para la materia con codigo {0} son: \n", codigoMateria);
                                foreach (var buscarCursos in ListadeCursos.Where(x => x.codigoMateria == codigoMateria))
                                {
                                    // desplegamos lista de cursos de esa materia.
                                    Console.WriteLine("Curso N° {0} | Tipo: {1} | Profesor: {2} | Horario: {3} | Sede: {4} | Catedra: {5}", buscarCursos.codigoCurso, buscarCursos.descripcionCurso, buscarCursos.nombreProfesor, buscarCursos.horarioCurso, buscarCursos.sedeCurso, buscarCursos.catedraCurso);
                                }

                                Console.WriteLine("\nIngrese el numero de curso en el que se quiere anotar: \n");
                                do
                                {
                                    if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out codigoCurso))
                                    {
                                        Cursos buscarCurso = ListadeCursos.Find(x => (x.codigoCurso == codigoCurso) && (x.codigoMateria == codigoMateria));
                                        if (ListadeCursos.Contains(buscarCurso))
                                        {
                                            parseCodigoCurso = true;
                                        }
                                        else 
                                        {
                                            Funciones.MostrarError("No se ha encontrado un curso con ese codigo. Ingrese nuevamente. \n");
                                        }
                                    }
                                    else
                                    {
                                        Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                    }
                                }
                                while (parseCodigoCurso == false);

                                //Ahora si, lo inscribimos.

                                Funciones.ActualizarInscripciones(String.Format("{0},{1},{2},{3}",numeroRegistro,numerocarrera,codigoMateria,codigoCurso));
                                parseCarreras = false;
                                parseCodigoMateria = false;
                                parseCodigoCurso = false;



                                Console.ReadLine();
                                Console.Clear();

                              
                            }


                            Console.ReadLine();

                            break;
                        case 2:  // certificado de inscripcion.


                            break;
                        case 3:
                            Funciones.salir();
                            break;

                        default:

                            Funciones.MostrarError("Lo ingresado no es una opcion valida.");
                            break;
                    }

                }
                else
                {
                    Funciones.MostrarError("Lo ingresado no es una opcion valida.");
                }

            }

            Console.ReadLine();
        }
    }
}
