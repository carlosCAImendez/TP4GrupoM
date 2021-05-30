using System;
using System.Collections.Generic;
using System.IO;
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
            bool inscribiocuartaMateria = false;
            bool parseCantidadMaterias = false;
            int cantidadMaterias = 0;
            bool parseCarreras = false;
            int numerocarrera = 0;
            bool parseCodigoMateria = false;
            int codigoMateria = 0;
            bool parseCodigoCurso = false;
            int codigoCurso = 0;
            bool parseFinalizarInscripcion = false;
            string finalizarInscripcion;
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
                            yaseInscribio = false;
                            Console.Clear();
                            Funciones.existenlasBases();
                            List<Alumnos> ListadeAlumnos = new();
                            ListadeAlumnos = Funciones.CargarAlumnos();
                            List<Materias> ListadeMaterias = new();
                            ListadeMaterias = Funciones.CargarMaterias();
                            List<Cursos> ListadeCursos = new();
                            ListadeCursos = Funciones.CargarCursos();
                            List<Inscripciones> ListaInscripcionesProvisoria = new();


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
                                    inscribiocuartaMateria = true;
                                    parseCuartaMateria = true;
                                }
                                else if (cuartaMateria == "N" || cuartaMateria == "n")
                                {
                                    cicloFORcuartaMateria = 2;
                                    inscribiocuartaMateria = false;
                                    parseCuartaMateria = true;
                                }
                                else
                                {
                                    Funciones.MostrarError("Lo ingresado no es una opcion correcta. Ingrese nuevamente.");
                                }

                            }
                            while (parseCuartaMateria == false);
                            #endregion

                            //Comprobamos a cuantas se quiere inscribir, si selecciono la cuarta materia no hacemos esto.
                          if (inscribiocuartaMateria == false)
                          { 
                            Console.WriteLine("A cuantas materias desea inscribirse?");
                            do
                            {
                                if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out cantidadMaterias))
                                {
                                    if (cantidadMaterias == 0 || cantidadMaterias > 3)
                                    {
                                        Funciones.MostrarError("La cantidad de materias no puede ser 0, ni mayor a 3. Ingrese nuevamente.");
                                    }
                                    else
                                    {
                                            cicloFORcuartaMateria = cantidadMaterias - 1;
                                            parseCantidadMaterias = true;
                                    }
                                }
                                else
                                {
                                    Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                }
                            }
                            while (parseCantidadMaterias == false);
                          }

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
                                       
                                          //  List<Inscripciones> ListadeInscripciones = new();
                                           // ListadeInscripciones = Funciones.CargarInscripciones();
                                            Inscripciones buscarInscripciones = ListaInscripcionesProvisoria.Find(x => (x.nroMateria == codigoMateria) && (x.nroRegistro == numeroRegistro));
                                            if (ListaInscripcionesProvisoria.Contains(buscarInscripciones))
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
                                            Funciones.MostrarError("No se ha encontrado un curso con ese numero. Ingrese nuevamente. \n");
                                        }
                                    }
                                    else
                                    {
                                        Funciones.MostrarError("Lo ingresado no es un numero valido. Ingrese nuevamente.");
                                    }
                                }
                                while (parseCodigoCurso == false);

                                //Lo guardamos en una lista hasta que confirme.
                                ListaInscripcionesProvisoria.Add(new Inscripciones() { nroRegistro = numeroRegistro, nroCarrera = numerocarrera, nroMateria = codigoMateria, codigoCurso = codigoCurso });
                                
                                parseCarreras = false;
                                parseCodigoMateria = false;
                                parseCodigoCurso = false;
                                registro = false;
                                parseCantidadMaterias = false;
                                parseCuartaMateria = false;
                                yaseInscribio = false;
                                inscribiocuartaMateria = false;
                                

                                Console.Clear();

                              
                            }

                            Console.WriteLine("Se estaría inscribiendo a las siguientes materias: ¿Desea confirmar? S/N \n");
                 
                                foreach (var item in ListaInscripcionesProvisoria)
                                {
                                    string materia = ListadeMaterias.Find(x => x.nroMateria == item.nroMateria).nombreMateria;
                                string cursoProfe = ListadeCursos.Find(x => (x.codigoCurso == item.codigoCurso) && (x.codigoMateria == item.nroMateria)).nombreProfesor;
                                    string sede = ListadeCursos.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).sedeCurso;
                                    string horario = ListadeCursos.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).horarioCurso;
                                    string modalidad = ListadeCursos.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).descripcionCurso;

                                    Console.WriteLine("Materia: {0} \n Profesor: {1} Sede: {2} Horario: {3} Modalidad: {4}", materia, cursoProfe, sede, horario, modalidad);
                                }
                            
                            do
                            {
                                finalizarInscripcion = Console.ReadLine();
                                finalizarInscripcion.Trim();

                                if (finalizarInscripcion == "S" || finalizarInscripcion == "s")
                                {
                                    //Ahora si, lo inscribimos.
                                   
                                    foreach (var item in ListaInscripcionesProvisoria)
                                    {
                                        Funciones.ActualizarInscripciones(String.Format("{0},{1},{2},{3}", item.nroRegistro, item.nroCarrera, item.nroMateria, item.codigoCurso));
                                    }
                                    Console.WriteLine("Se ha inscripto correctamente a las materias.");
                                    parseFinalizarInscripcion = true;

                                }
                                else if (finalizarInscripcion == "N" || finalizarInscripcion == "n")
                                {
                                    ListaInscripcionesProvisoria.Clear();
                                    parseFinalizarInscripcion = true;
                                    break;
                                }
                                else
                                {
                                    Funciones.MostrarError("Lo ingresado no es una opcion correcta. Ingrese nuevamente.");
                                }


                            } while (parseFinalizarInscripcion == false);

                            parseFinalizarInscripcion = false;
                            Console.ReadLine();

                            break;
                        case 2:  // certificado de inscripcion. ///
                            Console.Clear();
                            Funciones.existenlasBases();
                            List<Alumnos> ListadeAlumnos2 = new();
                            ListadeAlumnos2 = Funciones.CargarAlumnos();
                            List<Materias> ListadeMaterias2 = new();
                            ListadeMaterias2 = Funciones.CargarMaterias();
                            List<Cursos> ListadeCursos2 = new();
                            ListadeCursos2 = Funciones.CargarCursos();

                            Console.WriteLine("Ingrese su numero de registro");
                            #region Buscar si el alumno existe en la bd
                            do
                            {
                                if (Int32.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.None, null, out numeroRegistro))
                                {
                                    Alumnos buscarRegistro = ListadeAlumnos2.Find(x => x.nroRegistro == numeroRegistro);

                                    if (ListadeAlumnos2.Contains(buscarRegistro))
                                    {
                                        List<Inscripciones> ListadeInscripciones = new();
                                        ListadeInscripciones = Funciones.CargarInscripciones();
                                        Inscripciones buscarSiseinscribio = ListadeInscripciones.Find(x => x.nroRegistro == numeroRegistro);
                                        if (Funciones.ContarInscripciones(0) == 0)
                                        {
                                            Funciones.MostrarError("Usted no esta inscripto a las materias.");
                                        }
                                        else if (!ListadeInscripciones.Contains(buscarSiseinscribio))
                                        {
                                            Funciones.MostrarError("Usted no esta inscripto a las materias.");
                                        }
                                        else
                                        {
                                            if (ListadeInscripciones.Count(x => x.nroRegistro == numeroRegistro) >= 1)
                                            {
                                                registro = true;
                                                Console.Clear();
                                                Console.WriteLine("Alumno: {0} {1}", buscarRegistro.nombre, buscarRegistro.apellido);
                                                Console.WriteLine("Certificado de inscripcion:");
                                                string direccion = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "certificado" + numeroRegistro +  ".txt");
                                                FileInfo certificado = new FileInfo(direccion);
                                                if (certificado.Exists)
                                                {
                                                    Funciones.MostrarError("Ya existe un certificado de inscripción generado.");
                                                    break;
                                                }
                                                File.Create(direccion).Dispose();
                                                StreamWriter actualizador = new StreamWriter(direccion, true);
                                                actualizador.WriteLine("|Cod|Materia|Curso|Tipo|Titular|Docente|Dias y horarios|Sede|");
                                                foreach (var item in ListadeInscripciones.Where(x=> x.nroRegistro == numeroRegistro))
                                                {
                                                    string materia = ListadeMaterias2.Find(x => (x.nroMateria == item.nroMateria)).nombreMateria;
                                                    string cursoProfe = ListadeCursos2.Find(x => (x.codigoCurso == item.codigoCurso) && (x.codigoMateria == item.nroMateria)).nombreProfesor;
                                                    string sede = ListadeCursos2.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).sedeCurso;
                                                    string horario = ListadeCursos2.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).horarioCurso;
                                                    string modalidad = ListadeCursos2.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).descripcionCurso;
                                                    string catedra = ListadeCursos2.Find(x => x.codigoCurso == item.codigoCurso && (x.codigoMateria == item.nroMateria)).catedraCurso;

                                                    Console.WriteLine("Materia: {0} \n Profesor: {1} Sede: {2} Horario: {3} Modalidad: {4}", materia, cursoProfe, sede, horario, modalidad);
                                                    actualizador.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", item.nroMateria, materia, item.codigoCurso, modalidad, catedra,cursoProfe,horario,sede );
                                                  
                                                }
                                                actualizador.Close();
                                                Console.WriteLine("\nCertificado de inscripción generado.");

                                            }
                                        }

                                     


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
                            Console.WriteLine();
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
