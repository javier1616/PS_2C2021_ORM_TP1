using System;
using System.Collections.Generic;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public abstract class Menu
    {

        protected string tituloDelMenu;
        // menuConsole se usa para mostrar por pantalla que se realiza en cada accion
        protected private Dictionary<string, string> menuConsole = new Dictionary<string, string>();
        // opcion seleccionada validada
        protected private string option;
        
        protected private bool salirDelMenu_flag = false;

        public void MostrarMenu()
        {
            Console.WriteLine(tituloDelMenu);

            foreach (KeyValuePair<string, string> elem in menuConsole)
            {
                Console.WriteLine(elem.Key + " . " + elem.Value);
            }

            Console.WriteLine("");
            this.ValidarOpcion();
            this.EjecutarOpcion();
        }


        void ValidarOpcion()
        {
            string opcionElegida;
            bool existeLaClave = false;

            do
            {
                Console.Write("Seleccione una opcion: ");
                opcionElegida = Console.ReadLine();

                if (menuConsole.ContainsKey(opcionElegida))
                {
                    existeLaClave = true;
                    option = opcionElegida;
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta ("+opcionElegida+"). Seleccione una opcion: ");
                }

            } while (!(existeLaClave));

        }

        public abstract void EjecutarOpcion();

        public bool SalirDelMenu()
        {
            return salirDelMenu_flag;
        }

    }
}
