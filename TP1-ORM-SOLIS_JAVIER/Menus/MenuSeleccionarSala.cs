using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuSeleccionarSala : Menu
    {

        public MenuSeleccionarSala()
        {
            GetSalasQuery obtenerSalas = new GetSalasQuery();

            List<Salas> listaDeSalas = obtenerSalas.GetSalas();

            tituloDelMenu = "Seleccionar la Sala";

            foreach (Salas elem in listaDeSalas)
            {
                string numeroDeSala = (elem.SalaId).ToString();
                menuConsole.Add(numeroDeSala, ("Sala " + numeroDeSala + " - Capacidad: " + elem.Capacidad + " personas."));
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

