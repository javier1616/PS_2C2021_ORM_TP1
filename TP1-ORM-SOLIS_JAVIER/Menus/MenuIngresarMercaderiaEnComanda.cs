using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    class MenuIngresarMercaderiaEnComanda : Menu
    {

        string opcionParaVolverAlMenu = "B";
        List<Mercaderia> listaMercaderiaAcumulada; 


        public MenuIngresarMercaderiaEnComanda(string tipoMercaderia, 
                                               List<Mercaderia> listaMercaderiaParaComanda)
        {

            Context context = new Context();
            string mercaderiaId;
            List<Mercaderia> listaMercaderia;

            listaMercaderiaAcumulada = listaMercaderiaParaComanda.ToList();
            //copia las listas para poder utilizarlas con otros metodos

            tituloDelMenu = " Seleccionar Mercaderia para ingresar en comanda:";

            listaMercaderia = context.Set<Mercaderia>()
                                     .Where(x => x.TipoMercaderiaId == 
                                                 Int32.Parse(tipoMercaderia)).ToList();

            if (listaMercaderia.Any())
            {
                Console.WriteLine("Aun no existen productos del tipo seleccionado.");
            }

            foreach (Mercaderia elem in listaMercaderia)
            {
                mercaderiaId = (elem.MercaderiaId).ToString();
                menuConsole.Add(mercaderiaId,elem.Nombre);            
            }

            
            menuConsole.Add(opcionParaVolverAlMenu, "Volver al Menu De Tipos de Mercaderia");

        }

        override public void EjecutarOpcion()
        {

            Mercaderia mercaderia;
            Context context = new Context();

            // Aqui option es el Id de la Mercaderia que vas a ingresar a la comanda

            if (option == opcionParaVolverAlMenu)
            {
                salirDelMenu_flag = true;
            }
            else
            {

                //Aqui busca y agrega la mercaderia a la lista

                mercaderia = context.Set<Mercaderia>()
                                     .Where(x => x.MercaderiaId ==
                                                 Int32.Parse(option)).First();

                listaMercaderiaAcumulada.Add(mercaderia);
                Console.WriteLine("Se añadio " + mercaderia.Nombre + " a su pedido");

                Console.WriteLine("Total acumulado de productos: " +
                                            listaMercaderiaAcumulada.Count());

            }

        }

        public List<Mercaderia> RecuperarLista()
        {

            return listaMercaderiaAcumulada;

        }

    }

}
