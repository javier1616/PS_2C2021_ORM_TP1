using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuObtenerTickets : Menu
    {
        
        string opcionParaVolverAlMenu = "X";

        public MenuObtenerTickets()
        {

            GetPeliculasQuery obtenerPeliculas = new GetPeliculasQuery();
            
            List<Peliculas> listaDePeliculas = obtenerPeliculas.GetPeliculas();


            if (listaDePeliculas.Count == 0)
            {
                Console.WriteLine("Error. No hay peliculas en cartelera");
            }
            else
            {
                tituloDelMenu = " Menu Seleccionar Pelicula - Seleccione la pelicula que desea ver";

                foreach (Peliculas elem in listaDePeliculas)
                {
                    menuConsole.Add(elem.PeliculaId.ToString(), elem.Titulo);
                }

                menuConsole.Add(opcionParaVolverAlMenu, "Cancelar y volver al Menu Principal.");

            }
        }


        override public void EjecutarOpcion()
        {

            if (option == opcionParaVolverAlMenu)
            {
                salirDelMenu_flag = true;
            }
            else
            {
                Console.WriteLine("Funciones Disponibles:");
            }
          
        }

    }

}
