using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.Entities; 
using TP1_ORM_SOLIS_JAVIER.Classes.Menus;
using TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos; 

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class IngresarInformacion
    {

        public void RegistrarMercaderia(string tipoMercaderiaId)
        {

            IngresarObjetoEnBase creador = new IngresarObjetoEnBase();

            string[] queDatoPedir = new string[] {"Nombre de la mercaderia: ",
                                                  "Precio: ",
                                                  "Ingredientes: ",
                                                  "Preparacion: ",
                                                  "Imagen: "};

            string[] tipoDeDatoEsperado = new string[] {"string_50",
                                                  "int",
                                                  "string",
                                                  "string",
                                                  "string"};


            string[] datosIngresados = new string[queDatoPedir.Length];

            Console.WriteLine("");
            Console.WriteLine("Ingrese datos de la mercaderia");
            Console.WriteLine("");

            for(int i=0; i < 5; i++)
            {
                do
                {
                    Console.Write(queDatoPedir[i]);
                    datosIngresados[i] = Console.ReadLine();
                } while (!ValidacionDeDatos.ValidarDato(datosIngresados[i],
                                                        tipoDeDatoEsperado[i]));

            }

            Console.WriteLine("Datos ingresados. Guardando en Base de Datos...");


            creador.CreateMercaderia(datosIngresados,tipoMercaderiaId);

            Console.WriteLine("Listo.");
            Console.WriteLine("");

        }


        public void RegistrarComanda(List<Mercaderia> listaDeMercaderiaDeLaComanda)
        {

            IngresarObjetoEnBase creador = new IngresarObjetoEnBase();

            int formaEntregaId;            

            MenuSeleccionarFormaEntrega menuSeleccionarFormaEntrega =
                new MenuSeleccionarFormaEntrega();


            // obtengo la forma de Entrega
            menuSeleccionarFormaEntrega.MostrarMenu();
            formaEntregaId = menuSeleccionarFormaEntrega.GetOpcionElegida();

            Console.Write("Generando comanda y comandaMercaderia...");


            creador.CreateComanda(listaDeMercaderiaDeLaComanda, formaEntregaId);                 

            Console.WriteLine("Listo");
            Console.WriteLine("");

        }

    }

}
