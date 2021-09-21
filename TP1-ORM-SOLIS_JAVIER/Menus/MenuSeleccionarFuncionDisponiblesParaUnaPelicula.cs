using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuSeleccionarFuncionesDisponiblesParaUnaPelicula : Menu
    {
        string opcionParaVolverAlMenu = "X";

        public MenuSeleccionarFuncionesDisponiblesParaUnaPelicula(int peliculaId)
        {
            GetPeliculaByIdQuery getPeliculaById = new GetPeliculaByIdQuery();

            Peliculas pelicula = getPeliculaById.GetPeliculaById(peliculaId);

            FuncionesConLugarDisponibleParaPelicula funcionesDisponibles = new FuncionesConLugarDisponibleParaPelicula();
            List<Funciones> listaDeFuncionesDisponibles = funcionesDisponibles.FuncionesDisponiblesParaPelicula(pelicula);

            GetTicketsByFunctionIdQuery getTicketsByFunctionIdQuery = new GetTicketsByFunctionIdQuery();
            GetSalaByIdQuery getSalaById = new GetSalaByIdQuery();

            List<Tickets> listaDeTickets;
            Salas sala;
            int cantidadDeTicketsDisponibles;


            if (listaDeFuncionesDisponibles.Count == 0)
            {
                Console.WriteLine("  - No hay funciones disponibles para esa película - ");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Funciones Disponibles para: " + pelicula.Titulo);
                Console.WriteLine("--------------------------------------------------");

                foreach (Funciones elem in listaDeFuncionesDisponibles)
                {

                    listaDeTickets = getTicketsByFunctionIdQuery.GetTicketsByFunctionId(elem.FuncionId);
                    sala = getSalaById.GetSalaById(elem.SalaId);

                    cantidadDeTicketsDisponibles = sala.Capacidad - listaDeTickets.Count;

                    string cadena = "Funcion: " + pelicula.Titulo + " - " + elem.Fecha + " - " + elem.Horario +
                                    "Tickets disponibles: " + cantidadDeTicketsDisponibles;
                    menuConsole.Add(elem.FuncionId.ToString(), cadena);
                }
            }
        }            

        override public void EjecutarOpcion()
        {
        
        }


        public int GetOpcionElegida()
        {
            return Int32.Parse(option);
        }

    }

}
