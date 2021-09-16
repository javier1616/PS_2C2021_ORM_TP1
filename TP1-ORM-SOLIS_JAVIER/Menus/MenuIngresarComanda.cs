using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;  
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    class MenuIngresarComanda : Menu
    {

        List<Mercaderia> listaDeMercaderiaParaComanda; 
        string opcionParaVolverAlMenu = "B";
        string opcionParaConfirmarComanda = "F";

        public MenuIngresarComanda()
        {

            Context context = new Context();           
            string tipoMercaderiaId;

           

            if (listaDeMercaderiaParaComanda == null)    
            {
                listaDeMercaderiaParaComanda = new List<Mercaderia>();
            }

            tituloDelMenu = " Menu Ingresar Comanda - Seleccione el TIPO de mercaderia:";

            List<TipoMercaderia> listaTiposMercaderia = context.TipoMercaderia.ToList();

            foreach (TipoMercaderia elem in listaTiposMercaderia)
            {
                tipoMercaderiaId = (elem.TipoMercaderiaId).ToString();
                menuConsole.Add(tipoMercaderiaId, elem.Descripcion);
            }

            menuConsole.Add(opcionParaVolverAlMenu, "Cancelar y volver al Menu Principal.");
            menuConsole.Add(opcionParaConfirmarComanda, "Finalizar y Generar Comanda.");
            
        }

        

        override public void EjecutarOpcion()
        {

            if (option == opcionParaVolverAlMenu)
            {
                salirDelMenu_flag = true;
            }
            else if (option == opcionParaConfirmarComanda)
                 {
                    //Si sale por aqui ya no agrega mas Mercaderias a la comanda
                    if (listaDeMercaderiaParaComanda.Count() != 0)
                    {
                        ingresarInformacion.RegistrarComanda(listaDeMercaderiaParaComanda);
                        listaDeMercaderiaParaComanda.Clear();
                        salirDelMenu_flag = true;
                    }
                    else
                    {
                        Console.WriteLine("Comanda vacia. Volviendo a menu principal");
                    }

                 }
                 else
                 {
                   

                    // si entra por aca eligio el tipo pero no el plato
                    MenuIngresarMercaderiaEnComanda ingresarMercaderiaEnComanda =
                        new MenuIngresarMercaderiaEnComanda(option,
                                                            listaDeMercaderiaParaComanda);

                    ingresarMercaderiaEnComanda.MostrarMenu();

                    listaDeMercaderiaParaComanda =
                                  ingresarMercaderiaEnComanda.RecuperarLista();


                    this.MostrarMenu(); 
                 }

            

        }

    }

}
