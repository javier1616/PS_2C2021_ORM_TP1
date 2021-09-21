using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesDTO;
using TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio;
using TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuPrincipal : Menu
    {
        
        public MenuPrincipal()
        {
            
            tituloDelMenu = " TP1-ORM-JAVIER_SOLIS - MENU PRINCIPAL:";

            menuConsole.Add("1", "Ver Información de una película");
            menuConsole.Add("2", "Ver las funciones disponibles para un titulo de una película");
            menuConsole.Add("3", "Registrar una nueva función");
            menuConsole.Add("4", "Obtener un ticket para una función");
            menuConsole.Add("5", "Ver la cantidad de tickets disponibles para una función");

            menuConsole.Add("C", "Salir de la aplicacion");

        }

        override public void EjecutarOpcion()
        {
            
            MenuVerInformacionDeUnaPelicula menuVerInformacionDeUnaPelicula = new MenuVerInformacionDeUnaPelicula();
            MenuVerFuncionesDisponiblesParaUnaPelicula menuVerFuncionesDisponiblesParaUnaPelicula =
                new MenuVerFuncionesDisponiblesParaUnaPelicula();
            MenuObtenerTickets menuObtenerTickets = new MenuObtenerTickets();
            SePuedeRegistrarNuevaFuncion sePuedeRegistrarNuevaFuncion = new SePuedeRegistrarNuevaFuncion();

            PostFuncion registrarFuncion = new PostFuncion();

            int peliculaSeleccionada, salaSeleccionada;
            DateTime fechaHoraSeleccionada;

            MenuSeleccionarPelicula menuSeleccionarPelicula = new MenuSeleccionarPelicula();

            switch (option) 
            {
                case "1":
                    menuVerInformacionDeUnaPelicula.MostrarMenu();
                    break;
                case "2":
                    menuVerFuncionesDisponiblesParaUnaPelicula.MostrarMenu();
                    break;
                case "3":
                    menuSeleccionarPelicula.MostrarMenu();
                    peliculaSeleccionada = menuSeleccionarPelicula.GetOpcionElegida();

                    MenuSeleccionarSala menuSeleccionarSala = new MenuSeleccionarSala();
                    menuSeleccionarSala.MostrarMenu();
                    salaSeleccionada = menuSeleccionarSala.GetOpcionElegida();

                    MenuSeleccionarFechaHora menuSeleccionarFechaHora = new MenuSeleccionarFechaHora();
                    fechaHoraSeleccionada = menuSeleccionarFechaHora.GetFechaHora();

                    FuncionesDTO funcionDTO = new FuncionesDTO
                    {
                        PeliculaId = peliculaSeleccionada,
                        SalaId = salaSeleccionada,
                        Fecha = fechaHoraSeleccionada.Date,
                        Horario = fechaHoraSeleccionada.TimeOfDay
                    };


                    if (sePuedeRegistrarNuevaFuncion.VerificarEspacioEnSalaParaAgregarFuncion(funcionDTO))
                    {
                        Console.Write("Datos verificados. Registrando nueva funcion...");
                        registrarFuncion.RegistrarFuncion(funcionDTO);
                        Console.WriteLine("Listo");
                    }
                    else
                    {
                        Console.WriteLine("La sala esta ocupada en ese dia y horario");
                    }

                    break;
                case "4":
                    
                    menuSeleccionarPelicula.MostrarMenu();
                    int peliId = menuSeleccionarPelicula.GetOpcionElegida();
                    int cantidadTickets;
                    bool tickets_flag = true;

                    MenuSeleccionarFuncionesDisponiblesParaUnaPelicula menuSeleccionarFunciones =
                        new MenuSeleccionarFuncionesDisponiblesParaUnaPelicula(peliId);
                    menuSeleccionarFunciones.MostrarMenu();
                    int funcionId = menuSeleccionarFunciones.GetOpcionElegida();
                    VerificarSiHayLugarEnFuncion verificarLugar = new VerificarSiHayLugarEnFuncion();
                    PostTickets postTickets = new PostTickets();
                    string usuario;
                    List<Tickets> listaDeTickets;
                    bool nombreUsuarioNoValidado_flag = true;
                    ValidacionDeDatos validador = new ValidacionDeDatos();

                    do
                    {
                        Console.WriteLine("Seleccione la cantidad de tickets que desea adquirir: ");
                        if (Int32.TryParse(Console.ReadLine(), out cantidadTickets))
                        {
                            if (cantidadTickets > 0)
                            {
                                tickets_flag = false;
                            }
                            else
                            {
                                Console.WriteLine("ERROR. Cantidad no valida.");
                            }
                        }

                    } while (tickets_flag);

                    if( verificarLugar.VerificarLugaresDisponibles(funcionId,cantidadTickets))
                    {
                        do
                        {
                            Console.WriteLine("Ingrese su nombre de usuario: ");
                            usuario = Console.ReadLine();
                            if (validador.ValidarDato(usuario, "string_50"))
                            {
                                nombreUsuarioNoValidado_flag = false;
                            }
                            else
                            {
                                Console.WriteLine("Ingrese nuevamente su nombre de usuario");
                            }
                            

                        } while (nombreUsuarioNoValidado_flag);

                        Console.Write("Generando tickets...");
                        listaDeTickets = postTickets.PostVariosTickets(funcionId, usuario, cantidadTickets);
                        Console.WriteLine("Listo.");

                        Console.WriteLine("");
                        Console.WriteLine("Tickets generados");

                        foreach (Tickets elem in listaDeTickets)
                        {
                            Console.WriteLine("Ticket ID: "+elem.TicketId);
                        }

                        Console.WriteLine("-------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("No hay lugares para la funcion seleccionada");
                    }

                    break;
                case "5":

                    MenuVerTicketsDisponiblesParaUnaFuncion verTicketsDisponiblesParaUnaFuncion =
                        new MenuVerTicketsDisponiblesParaUnaFuncion();

                    verTicketsDisponiblesParaUnaFuncion.MostrarMenu();

                    break;
                case "C":
                    salirDelMenu_flag = true;
                    break;
                default:
                    Console.WriteLine("ERROR !");
                    break;
            }
        }

    }

}
