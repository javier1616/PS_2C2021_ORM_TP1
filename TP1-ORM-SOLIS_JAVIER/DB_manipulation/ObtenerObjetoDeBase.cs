
using System;
using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
  public class ObtenerObjetoDeBase
    {
        public List<Mercaderia> ObtenerListadoDeMercaderia()
        {
            Context context = new Context();

            return context.Mercaderia.ToList();

        }

        public TipoMercaderia ObtenerTiposDeMercaderia(int id)
        {
            Context context = new Context();

            return  context.Set<TipoMercaderia>().
                            Where(x => x.TipoMercaderiaId == id).First();

        }

        public FormaEntrega ObtenerFormaEntrega(int id)
        {
            Context context = new Context();

            return context.Set<FormaEntrega>().
                                       Where(x => x.FormaEntregaId == id).
                                       First();
        }

        public Mercaderia ObtenerMercaderia(int id)
        {
            Context context = new Context();

            return context.Set<Mercaderia>().Where(x => x.MercaderiaId == id).
                                         First();
        }

        public List<ComandaMercaderia> ObtenerListaComandaMercaderia(Guid id)
        {
            Context context = new Context();

            return context.Set<ComandaMercaderia>().
                                                 Where(x => x.ComandaId == id).
                                                 ToList();
        }

        public List<Comanda> ObtenerListaComandas()
        {
            Context context = new Context();

            return context.Comanda.ToList();
        }

       
  } 
}
