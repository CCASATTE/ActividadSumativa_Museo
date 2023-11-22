using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Controller;
using System.Diagnostics.Eventing.Reader;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControllerGuia.InicializarGuia();
            ControllerJefeMuseo.InicilizarJefeMuseo();
            ControllerRelacionPublica.InicializarRelacionPublica();
            ControllerObraArte.InicilizarObraArte();
            ControllerExposicion.InicializarExposicion();
            ControllerInsumo.IncializarInsumo();
            ControllerTour.InicializarTourEscolar();    
           
            bool cerrarSesion = true;
            while (cerrarSesion)
            {
                string tipoUser = LoginUser();
                Console.WriteLine(tipoUser);
                if (tipoUser == "Jefe")
                {
                    int opcion;
                    do
                    {
                        opcion = MenuJefeMuseo();
                        switch (opcion)
                        {
                            case 1:
                                if (ControllerTour.ObtenerTours().Count > 0)
                                {
                                    AsignarGuia();
                                }
                                else
                                {
                                    Console.WriteLine("No se a creado ningun TOUR!");
                                }
                                break;
                            case 2:
                                VerTourEscolar(ControllerTour.ObtenerTours());
                                break;
                            case 3:
                                VerInsumos(ControllerInsumo.ObtenerInsumos());
                                break;
                            case 4:
                                opcion = 0;
                                break;
                            case 0:
                                cerrarSesion = false;
                               break;
                            default:
                                Console.WriteLine("Opcion Invalida");
                                break;
                        }
                    } while (opcion != 0);

                }
                else if (tipoUser == "Guia")
                {
                    int opcion;
                    do
                    {
                        opcion = MenuGuia();
                        switch (opcion)
                        {
                            case 1:
                                RealizarTours();
                                break;
                             case 2:
                                VerTourEscolar(ControllerTour.ObtenerTours());
                                break;
                            case 3:
                                PreprararIsumos();
                                break;
                            case 4:
                                opcion = 0;
                                break;
                                case 0:
                                cerrarSesion = false;
                                    break;  
                            default:
                                Console.WriteLine("Opcion Invalida");
                                break;
                        }
                    } while (opcion != 0);
                }
                else if (tipoUser == "RP")
                {
                    int opcion;
                    do
                    {
                        opcion = MenuRelacionPublica();
                        switch (opcion)
                        {
                            case 1:
                                AsignarDisponibilidad();
                                break;
                            case 2:
                                VerInsumos(ControllerInsumo.ObtenerInsumos());
                                break;
                            case 3:
                                opcion = 0;
                                break;
                            case 0: 
                                cerrarSesion=false; 
                                 break;
                            default:
                                Console.WriteLine("Opcion Invalida");
                                break;
                        }
                    } while (opcion != 0);
                }
            }
           
        }
        //Menus de Entidades
        static int MenuJefeMuseo()
        {
            int opcion;
            Console.WriteLine("-- Menú Jefe Museo --");
            Console.WriteLine("[1] Asignar Guia");
            Console.WriteLine("[2] Ver listado de Tour");
            Console.WriteLine("[3] Ver listado de Insumos");
            Console.WriteLine("[4] Cerrar Sesión");
            Console.WriteLine("[0] Salir");
            do
            {
                Console.WriteLine("Selecciona una opción: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese solo números.");
                }
            } while (true);
            return opcion;
        }
        static int MenuGuia()
        {
            int opcion;
            Console.WriteLine("-- Menú Guia --");
            Console.WriteLine("[1] Realizar Tour");
            Console.WriteLine("[2] Ver listado de Tour");
            Console.WriteLine("[3] Preparar Insumos");
            Console.WriteLine("[4] Cerrar Sesion");
            Console.WriteLine("[0] Salir");
           do
            {
                Console.WriteLine("Selecciona una opción: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese solo números.");
                }
            } while (true);
            return opcion;
        }
        static int MenuRelacionPublica()
        {
            int opcion;
            Console.WriteLine("-- Menú Relaciones Publicas --");
            Console.WriteLine("[1] Ver Disponibilidad");
            Console.WriteLine("[2] Ver listado de Insumos");
            Console.WriteLine("[3] Cerrar Sesion");
            Console.WriteLine("[0] Salir");
            do
            {
                Console.WriteLine("Selecciona una opción: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingrese solo números.");
                }
            } while (true);
            return opcion;
        }
        //Iniciar Sesion
        static String LoginUser()
        {
            Console.WriteLine("Ingrese Usuario");
            String User = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            String Pass = Console.ReadLine();
            foreach (JefeMuseo admin in ControllerJefeMuseo.ObtenerJefeMuseos())
            {
                if (admin.Usuario == User && admin.Contraseña == Pass)
                {
                    return "Jefe";
                }

            }
            foreach (Guia guia in ControllerGuia.ObtenerGuias())
            {
                if (guia.Usuario == User && guia.Contraseña == Pass)
                {
                    return "Guia";
                }

            }
            foreach (RelacionPublica guia in ControllerRelacionPublica.ObtenerRelacionesPublicas())
            {
                if (guia.Usuario == User && guia.Contraseña == Pass)
                {
                    return "RP";
                }

            }
            return "Usuario No Existe!";
        }
        //Asignar
        static void AsignarGuia()
        {
            List<Tour> listadoDeTours = ControllerTour.ObtenerTours().Where(tour => tour.Estado == "VERIFICADO").ToList();
            if (!listadoDeTours.Any())
            {
                Console.WriteLine("--No hay datos para Mostrar--");
            }
            else
            {
                VerTourEscolar(listadoDeTours);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Seleccione Tour por ID:");
                int idTour = Convert.ToInt32(Console.ReadLine());
                VerGuias(ControllerGuia.ObtenerGuias());
                bool estado = false;
                int cantidadGuias = 0;
                List<Guia> guias = new List<Guia>();
                do
                {
                    if(cantidadGuias >= 3)
                    {
                        Console.WriteLine("---NO SE ACEPTAN MAS GUIAS---");
                        estado = true;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese Id del Guia");
                        int idBuscado = Convert.ToInt32(Console.ReadLine());
                        Guia guiaEncontrado = ControllerGuia.ObtenerGuias().Find(guia => guia.Id == idBuscado);
                        if (guiaEncontrado == null)
                        {
                            Console.WriteLine("No se Encontro el Guia");
                            estado = true;
                        }
                        else
                        {
                            guias.Add(guiaEncontrado);
                            Console.WriteLine("----GUIA AGREGADO CORRECTAMENTE----");
                            bool creado = ControllerTour.AgregarGuia(idTour, guias);
                            cantidadGuias += 1;
                            Console.WriteLine("¿Desea agregar mas guias? [s] SI - [n] NO");
                            String opcion = Console.ReadLine();
                            if (opcion == "s")
                            {
                                estado = false;
                            }
                            else if (opcion == "n")
                            {
                                estado = true;
                            }
                            else
                            {
                                Console.WriteLine("Opcion no Validad");
                                estado = true;
                            }
                        }
                    }
                } while(!estado); 
                
            }
        }
        static void AsignarDisponibilidad()
        {
            List<Tour> listadoDeTour = ControllerTour.ObtenerTours().Where(tour => tour.Estado == "SOLICITADO").ToList();
            if (!listadoDeTour.Any())
            {
                Console.WriteLine("--No hay datos para Mostrar--");
            }
            else
            {
                VerTourEscolar(listadoDeTour);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Seleccione una Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("¿Desea confirmar datos del Tour [s] SI - [n] NO");
                String opcion = Console.ReadLine();
                if (opcion == "s")
                {
                    ControllerTour.CambiarEstado(id, "VERIFICADO");
                    Console.WriteLine("-----TOUR VERIFICADO CORRECTAMENTE-----");
                }
                else if (opcion == "n")
                {
                    Console.WriteLine("-----No se realizo ningun Cambio-----");
                }
                else
                {
                    Console.WriteLine("Opcion no valida");
                }
            }
        }
        static void PreprararIsumos()
        {
            List<Tour> listaDeTours = ControllerTour.ObtenerTours().Where(tour => tour.Estado == "ASIGNADO").ToList();
            if(!listaDeTours.Any())
            {
                Console.WriteLine("----No hay Datos para Mostrar----");
            }
            else
            {
                VerTourEscolar(listaDeTours);
                Console.WriteLine("--------------------");
                Console.WriteLine("Seleccione Tour por ID:");
                int idTour = Convert.ToInt32(Console.ReadLine());
                VerInsumos(ControllerInsumo.ObtenerInsumos());
                bool estado = true;
                List<Insumo> listadoInsumo = new List<Insumo>();
                do
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Seleccione Insumo por ID:");
                    int idInsumo = Convert.ToInt32(Console.ReadLine());
                    Insumo insumoSeleccionado = ControllerInsumo.ObtenerInsumos().Find(insumo => insumo.Id == idInsumo);
                    Console.WriteLine($"Indique cantidad a asignar (maximo: {insumoSeleccionado.Cantidad})");
                    int cantidadInsumo = Convert.ToInt32(Console.ReadLine());
                    if (insumoSeleccionado.Cantidad < cantidadInsumo)
                    {
                        Console.WriteLine("Esta sobre la cantidad maxima del Insumo");
                        estado = false;
                    }else if(cantidadInsumo < 0)
                    {
                        Console.WriteLine("Vuelva a Intentarlo");
                        estado = false;
                    }
                    else
                    {
                        Insumo insumoAgregar = ControllerInsumo.ObtenerInsumos().Find(ins => ins.Id == idInsumo);
                        if (insumoAgregar == null)
                        {
                            Console.WriteLine("No se ha encontrado Insumo");
                            estado = false;
                        }
                        else
                        {
                            insumoAgregar.Cantidad = cantidadInsumo;
                            listadoInsumo.Add(insumoAgregar);
                            Console.WriteLine("------INSUMO AGREGADO CORRECTAMENTE----");
                            bool creado = ControllerTour.AgregarInsumo(idTour, listadoInsumo,"PREPARADO");
                            Console.WriteLine("Desea Agregar mas Insumos? [s] SI - [n] NO");
                            String opcion = Console.ReadLine();
                            if (opcion == "s")
                            {
                                estado = false;
                            }
                            else
                            {
                                estado = true;
                            }
                        }
                    }
                } while (!estado);
            }
        }
        static void RealizarTours()
        {
            List<Tour> listaDeTours = ControllerTour.ObtenerTours().Where(tour => tour.Estado == "PREPARADO").ToList();
            if (!listaDeTours.Any())
            {
                Console.WriteLine("-- NO HAY DATOS PARA MOSTRAR --");
            }
            else
            {
                VerTourEscolar(listaDeTours);
                Console.WriteLine("Seleccione la Id del Tour:");
                int opcion = Convert.ToInt32(Console.ReadLine());
                foreach (var item in listaDeTours)
                {
                    if (opcion != item.Id )
                    {
                        Console.WriteLine("-- Id no econtrada --");
                        break;
                    }
                else
                    {
                        Console.WriteLine("¿Desea Realizar el Tour Correspondiente? [s] SI - [n] NO");
                        String selec = Console.ReadLine();  
                        if(selec == "s")
                        {
                            ControllerTour.CambiarEstado(opcion, "REALIZADO");
                            Console.WriteLine("-- TOUR REALIZADO --");
                            break;
                        }else if(selec == "n")
                        {
                            Console.WriteLine("--- NO SE REALIZO NINGUN CAMBIO --");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("OPCION NO VALIDA");
                            break;
                        }
                       
                    }
                }
                
            }
        }
        //Ver Metodos
        static void VerInsumos(List<Insumo> listadoInsumo)
        {
            foreach (var item in listadoInsumo)
            {
                Console.WriteLine($"-- Id:{item.Id} | Nombre: {item.Nombre} |  Cantidad: {item.Cantidad}");
            }
        }
        static void VerGuias(List<Guia> listadoGuia)
        {
            foreach (Guia item in listadoGuia)
            {
                Console.WriteLine($"Id:{item.Id}");
                Console.WriteLine($"Usuario:{item.Usuario}");
                Console.WriteLine($"Nombre:{item.Nombre} {item.Apellido}");
                Console.WriteLine();
            }
        }
        static void VerTourEscolar(List<Tour> tours)
        {
            foreach (Tour item in (tours))
            {
                Console.WriteLine($"------ TOURS ------------");
                Console.WriteLine($"-- ID:{item.Id} | Estado:{item.Estado}");
                Console.WriteLine($"-- Fecha:{item.Fecha} {item.HoraIncio} ");
                Console.WriteLine($"-- Curso:{item.Curso} | {item.Alumnos} Alumnos");
                Console.WriteLine($"-- Adulto a Cargo:{item.AdultoCargo} | Profesor:{item.Profesor}");
                Console.WriteLine($"-- Cupos:{item.Cupos} | Exposición:{item.Exposicion}");
                Console.WriteLine();
                Console.WriteLine($"---- LISTADO DE OBRAS DE ARTES -- CANTIDAD:{item.ListadoObra.Count()} ----");
                VerObrasArte(item.ListadoObra);
                Console.WriteLine();
                Console.WriteLine($"---- LISTADO DE GUIA -- CANTIDAD:{item.ListadoGuia.Count()} ----");
                VerGuias(item.ListadoGuia);
                Console.WriteLine($"---- LISTADO DE INSUMOS -- CANTIDAD:{item.ListadoInsumo.Count()} ----");
                VerInsumos(item.ListadoInsumo);
                Console.WriteLine();
            }
        }
        static void VerObrasArte(List<ObraArte> listadoObra)
        {
            foreach (ObraArte item in listadoObra)
            {
                Console.WriteLine($"-- Id:{item.Id} | {item.Nombre}");
                Console.WriteLine($"-- Autor:{item.Autor} | Fecha:{item.Fecha}");
                Console.WriteLine($"-- Descripción:{item.Descripcion}");
                Console.WriteLine();
            }
        }
       
    }
}