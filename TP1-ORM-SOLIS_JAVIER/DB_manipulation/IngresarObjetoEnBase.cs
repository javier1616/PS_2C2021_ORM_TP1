
using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
  public class IngresarObjetoEnBase
    {
        public void CreateMercaderia(string[] datos, string tipoMercaderiaId)
        {

            Context context = new Context();

            Mercaderia mercaderia = new Mercaderia
            {
                Nombre = datos[0],
                TipoMercaderiaId = Int32.Parse(tipoMercaderiaId),
                Precio = Int32.Parse(datos[1]),
                Ingredientes = datos[2],
                Preparacion = datos[3],
                Imagen = datos[4]
            };

            context.Add(mercaderia);
            context.SaveChanges();

        }


        public void CreateComanda(List<Mercaderia> listaDeMercaderiaDeLaComanda, int formaEntregaId)
        {

            Context context = new Context();
            ComandaMercaderia comandaMercaderia;
            Comanda comanda = new Comanda();
            int precioTotal = 0;

            //armo comanda

            foreach (Mercaderia elem in listaDeMercaderiaDeLaComanda)
            {
                
                precioTotal += elem.Precio;
            }

            comanda.FormaEntregaId = formaEntregaId;
            comanda.PrecioTotal = precioTotal;
            comanda.Fecha = DateTime.Now;      

            context.Add(comanda);

            context.SaveChanges();

            foreach (Mercaderia elem in listaDeMercaderiaDeLaComanda)
            {
                comandaMercaderia = new ComandaMercaderia
                {
                    MercaderiaId = elem.MercaderiaId,
                    ComandaId = comanda.ComandaId  //es el mismo siempre
                };

                context.Add(comandaMercaderia);
                context.SaveChanges();
            }
        }
  } 
}
