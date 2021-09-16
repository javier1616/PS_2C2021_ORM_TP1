using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    class MenuIngresarMercaderia : Menu
    {

        string opcionParaVolverAlMenu = "B";

        public MenuIngresarMercaderia()
        {

            Context context = new Context();
            string tipoMercaderiaId;
            
            tituloDelMenu = " Ingresar Mercaderia:";

            List<TipoMercaderia> listaTiposMercaderia = context.TipoMercaderia.ToList();

            foreach (TipoMercaderia elem in listaTiposMercaderia)
            {
                tipoMercaderiaId = (elem.TipoMercaderiaId).ToString();
                menuConsole.Add(tipoMercaderiaId,elem.Descripcion);            
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
                ingresarInformacion.RegistrarMercaderia(option);            
            }

            Console.WriteLine("");

        }

    }

}
