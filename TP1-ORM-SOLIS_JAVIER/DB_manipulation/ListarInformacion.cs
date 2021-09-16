using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class ListarInformacion
    {
        public void ListarComandas()
        {
            
            List<ComandaMercaderia> listaComandaMercaderia;
            Mercaderia mercaderia;
            FormaEntrega formaEntrega;

            ObtenerObjetoDeBase obtenedor = new ObtenerObjetoDeBase();


            List<Comanda> listaComandas = obtenedor.ObtenerListaComandas();

            Console.WriteLine("");
            Console.WriteLine("Listado de Comandas");
            Console.WriteLine("--------------------------------------------------");


            foreach (Comanda elem in listaComandas)
            {

                Console.WriteLine("Codigo: " + elem.ComandaId + "  -   Fecha: " + elem.Fecha);
                Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -");

                listaComandaMercaderia = obtenedor.ObtenerListaComandaMercaderia(elem.ComandaId);

                foreach (ComandaMercaderia item in listaComandaMercaderia)
                {

                    mercaderia = obtenedor.ObtenerMercaderia(item.MercaderiaId);

                    Console.Write(mercaderia.Nombre + "  -  ");
                    Console.WriteLine("Precio: " + mercaderia.Precio);
                }

                Console.WriteLine("");
                Console.Write("Total: $ " + elem.PrecioTotal+"      ");


                formaEntrega = obtenedor.ObtenerFormaEntrega(elem.FormaEntregaId);

                Console.WriteLine(" Modo de envio: " + formaEntrega.Descripcion);
                Console.WriteLine("-  -  -  -  -  -  -  -  -  -  -");
               
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Fin  de Comandas");
            Console.WriteLine("");

        }



        public void ListarMercaderia()
        {

            ObtenerObjetoDeBase listador = new ObtenerObjetoDeBase();
            
            TipoMercaderia tipoMercaderia;
            List<Mercaderia> listaDeMercaderia = listador.ObtenerListadoDeMercaderia();

            Console.WriteLine("");
            Console.WriteLine("Listado de Mercaderias");
            Console.WriteLine("----------------------");


            foreach (Mercaderia elem in listaDeMercaderia)
            {

                Console.WriteLine("Nombre: "+ elem.Nombre+" - Id: "+elem.MercaderiaId);

                tipoMercaderia = listador.ObtenerTiposDeMercaderia(elem.TipoMercaderiaId);

                Console.WriteLine("TipoMercaderia: "+ tipoMercaderia.Descripcion);
                Console.WriteLine("Precio: "+ elem.Precio);
                Console.WriteLine("Ingredientes: " + elem.Ingredientes);
                Console.WriteLine("Preparacion: " + elem.Preparacion);
                Console.WriteLine("URL Imagen: " + elem.Imagen);
                Console.WriteLine();

            }
            
            Console.WriteLine("--------------------------");
            Console.WriteLine("Fin  de Mercaderias");
            Console.WriteLine("");

        }

    }
}
