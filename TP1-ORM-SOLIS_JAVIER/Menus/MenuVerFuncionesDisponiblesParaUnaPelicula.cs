using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuVerFuncionesDisponiblesParaUnaPelicula : Menu
    {
        string opcionParaVolverAlMenu = "X";

        public MenuVerFuncionesDisponiblesParaUnaPelicula()
        {

            GetPeliculasQuery listador = new GetPeliculasQuery();
            List<Peliculas> listadoDePeliculas = new List<Peliculas>();

            tituloDelMenu = " Peliculas en cartelera - Seleccionar pelicula para ver funciones disponibles ";

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

                GetPeliculaByIdQuery getPeliculaById = new GetPeliculaByIdQuery();

                Peliculas pelicula = getPeliculaById.GetPeliculaById(Int32.Parse(option));

                FuncionesConLugarDisponibleParaPelicula funcionesDisponibles = new FuncionesConLugarDisponibleParaPelicula();
                List<Funciones> listaDeFuncionesDisponibles = funcionesDisponibles.FuncionesDisponiblesParaPelicula(pelicula);

                if (listaDeFuncionesDisponibles.Count == 0)
                {
                    Console.WriteLine("  - No hay funciones disponibles para esa película - ");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Funciones Disponibles para: " + pelicula.Titulo);
                    Console.WriteLine("--------------------------------------------------");

                    foreach (Funciones elem in listaDeFuncionesDisponibles)
                    {

                        Console.WriteLine("Fecha: "+ elem.Fecha.Day+"/"+elem.Fecha.Month+"/"+elem.Fecha.Year+
                                          "  Hora: "+ elem.Horario+"  Sala: "+ elem.SalaId);
                         

                    }

                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("");
                }

            }
        
        }


        public int GetOpcionElegida()
        {
            return Int32.Parse(option);
        }

    }

}
