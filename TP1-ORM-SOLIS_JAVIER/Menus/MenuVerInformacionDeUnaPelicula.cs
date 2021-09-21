using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuVerInformacionDeUnaPelicula : Menu
    {
        string opcionParaVolverAlMenu = "X";

        public MenuVerInformacionDeUnaPelicula()
        {

            GetPeliculasQuery listador = new GetPeliculasQuery();
            List<Peliculas> listadoDePeliculas = new List<Peliculas>();

            tituloDelMenu = " Peliculas en cartelera - Seleccionar para ver informacion ";

            listadoDePeliculas = listador.GetPeliculas();

            foreach (Peliculas elem in listadoDePeliculas)
            {
                menuConsole.Add( elem.PeliculaId.ToString(), elem.Titulo);
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
                Console.WriteLine("Tenes que mostrar la info de la pelicula");

                GetInfoPelicula informacion = new GetInfoPelicula();

                Peliculas pelicula = informacion.Informacion(Int32.Parse(option));

                Console.WriteLine("");
                Console.WriteLine("Información de pelicula");
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("PeliculaId: " + pelicula.PeliculaId);
                Console.WriteLine("Titulo: " + pelicula.Titulo);
                Console.WriteLine("Poster: " + pelicula.Poster);
                Console.WriteLine("Sinopsis: " + pelicula.Sinopsis);
                Console.WriteLine("Trailer: " + pelicula.Trailer);

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("");

            }
        
        }


        public int GetOpcionElegida()
        {
            return Int32.Parse(option);
        }

    }

}
