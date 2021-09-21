using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuVerTicketsDisponiblesParaUnaFuncion : Menu
    {
        string opcionParaVolverAlMenu = "X";

        GetPeliculasQuery peliculas = new GetPeliculasQuery();
        List<Peliculas> listadoDePeliculas = new List<Peliculas>();
        Peliculas pelicula = new Peliculas();
        Salas sala = new Salas();

        int cantidadDeTicketsDisponibles;

        public MenuVerTicketsDisponiblesParaUnaFuncion()
        {

            GetFuncionesQuery funciones = new GetFuncionesQuery();            
            List<Funciones> listadoDeFunciones = new List<Funciones>();
            string cadena;

            tituloDelMenu = " Funciones - Seleccionar una funcion para ver los tickets disponibles";

            listadoDeFunciones = funciones.GetFunciones();
            listadoDePeliculas = peliculas.GetPeliculas();
                                    

            foreach (Funciones elem in listadoDeFunciones)
            {
                pelicula = listadoDePeliculas.Find(p => p.PeliculaId == elem.PeliculaId);
                cadena = (pelicula.Titulo + " - Sala: " + elem.SalaId + " - Fecha: " + elem.Fecha.ToShortDateString() + " - Hora: " + elem.Horario);
                menuConsole.Add( elem.FuncionId.ToString(), cadena);
            }

            menuConsole.Add(opcionParaVolverAlMenu, "Volver al Menu Principal");

        }

        override public void EjecutarOpcion()
        {
            

            if (option == opcionParaVolverAlMenu)
            {
                salirDelMenu_flag = true;
            }
            else
            {
                
                GetFuncionByFuncionIdQuery getFuncionById = new GetFuncionByFuncionIdQuery();
                GetSalaByIdQuery getSalaById = new GetSalaByIdQuery();
                GetTicketsByFunctionIdQuery getTicketsByFunction = new GetTicketsByFunctionIdQuery();
                GetPeliculaByIdQuery getPeliculaById = new GetPeliculaByIdQuery();
                Funciones funcion = new Funciones();


                List<Tickets> listaDeTicketsPorFuncion = new List<Tickets>();


                funcion = getFuncionById.GetFuncionByFuncionId(Int32.Parse(option));
                sala = getSalaById.GetSalaById(funcion.SalaId);
                pelicula = getPeliculaById.GetPeliculaById(funcion.PeliculaId);

                listaDeTicketsPorFuncion = getTicketsByFunction.GetTicketsByFunctionId(funcion.FuncionId);


                cantidadDeTicketsDisponibles = sala.Capacidad - listaDeTicketsPorFuncion.Count;

                Console.WriteLine("");
                Console.WriteLine("Funcion: " + pelicula.Titulo + " - " + funcion.Fecha.ToShortDateString() + " - " + funcion.Horario);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Cantidad de tickets disponibles: " + cantidadDeTicketsDisponibles);
                Console.WriteLine("--------------------------------------------------");

            }

        }

        public int GetOpcionElegida()
        {
            return Int32.Parse(option);
        }

    }

}
