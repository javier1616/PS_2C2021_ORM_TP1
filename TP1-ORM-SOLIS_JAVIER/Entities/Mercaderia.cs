using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }   // PK como se llama xxId (EF Core lo reconoce )
        public string Nombre { get; set; }

        //defino TipoMercaderiaID como FK            
        public int TipoMercaderiaId { get; set; }   // FK Property
        public TipoMercaderia TipoMercaderia { get; set; } // Reference Property

        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }

        // ComandaMercaderia contiene FK de esta tabla
        public ICollection<ComandaMercaderia> ComandaMercaderia { get; set; }
    }
}
