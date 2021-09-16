using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; } // PK

        //defino MercaderiaId como FK            
        public int MercaderiaId { get; set; }   // FK Property
        public Mercaderia Mercaderia { get; set; } // Reference Property

        //defino ComandaId como FK            
        public Guid ComandaId { get; set; }   // FK Property
        public Comanda Comanda { get; set; } // Reference Property
    }
}
