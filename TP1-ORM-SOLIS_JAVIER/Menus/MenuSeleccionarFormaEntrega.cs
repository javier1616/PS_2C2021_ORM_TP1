using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    class MenuSeleccionarFormaEntrega : Menu
    {

        public MenuSeleccionarFormaEntrega()
        {

            Context context = new Context();
            string formaEntregaId;
            
            tituloDelMenu = " SeleccionarFormaEntrega";

            List<FormaEntrega> listaFormaEntrega = context.FormaEntrega.ToList();

            foreach (FormaEntrega elem in listaFormaEntrega)
            {
                formaEntregaId = (elem.FormaEntregaId).ToString();
                menuConsole.Add(formaEntregaId,elem.Descripcion);            
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
