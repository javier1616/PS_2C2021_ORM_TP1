using System;
using TP1_ORM_SOLIS_JAVIER.Classes.Menus; // Clases que contienen menues


namespace TP1_ORM_SOLIS_JAVIER
{
    class Program
    {
        static void Main()
        {


            MenuPrincipal menuPrincipal = new MenuPrincipal();
            
            do
            {
                menuPrincipal.MostrarMenu();
            } while (!menuPrincipal.SalirDelMenu());

            FinalizarAplicacion();
        }

        public static void FinalizarAplicacion()
        {
            Console.WriteLine("Fin de aplicacion. Presione una tecla para salir.");
            Console.ReadKey();
        }

    }
}
