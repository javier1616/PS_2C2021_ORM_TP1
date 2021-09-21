using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuSeleccionarPelicula : Menu
    {

        public MenuSeleccionarPelicula()
        {
            GetPeliculasQuery obtenerPeliculas = new GetPeliculasQuery();
            tituloDelMenu = "Seleccionar Pelicula";

            List<Peliculas> listaDePeliculas = obtenerPeliculas.GetPeliculas();
                        
            foreach (Peliculas elem in listaDePeliculas)
            {
                menuConsole.Add(elem.PeliculaId.ToString(),elem.Titulo);            
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
