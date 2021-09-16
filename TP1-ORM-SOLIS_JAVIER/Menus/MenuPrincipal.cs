using System;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    class MenuPrincipal : Menu
    {
        

        public MenuPrincipal()
        {
            
            tituloDelMenu = " TP1-ORM-JAVIER_SOLIS - MENU PRINCIPAL:";

            menuConsole.Add( "1", "Registrar Mercaderia (platos, bebidas o postre)");
            menuConsole.Add("2", "Registrar Comandas (pedido del cliente)");
            menuConsole.Add("3", "Listar comandas con detalle de platos");
            menuConsole.Add("4", "Listar informacion de mercaderia");
            menuConsole.Add("5", "Salir de la aplicacion");

        }

        override public void EjecutarOpcion()
        {
            
            MenuIngresarMercaderia menuIngresarMercaderia = new MenuIngresarMercaderia();
            MenuIngresarComanda menuIngresarComanda = new MenuIngresarComanda();


            switch (option) //option esta definido en la superclase
            {
                case "1":
                    menuIngresarMercaderia.MostrarMenu();
                    break;
                case "2":
                    menuIngresarComanda.MostrarMenu();
                    break;
                case "3":
                    listarInformacion.ListarComandas();
                    break;
                case "4":
                    listarInformacion.ListarMercaderia();
                    break;
                case "5":
                    salirDelMenu_flag = true;
                    break;
                default:
                    Console.WriteLine("ERROR !");
                    break;
            }
        }

    }

}
