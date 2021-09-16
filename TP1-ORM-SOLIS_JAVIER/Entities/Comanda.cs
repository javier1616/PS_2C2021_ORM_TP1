using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class Comanda
    {
        public Guid ComandaId { get; set; }

        //defino FormaEntregaId como FK            
        public int FormaEntregaId { get; set; }   // FK Property
        public FormaEntrega FormaEntrega { get; set; } // Reference Property

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        // ComandaMercaderia contiene una FK de esta tabla, este es el otro extremo de la relación
        public ICollection<ComandaMercaderia> ComandaMercaderia { get; set; }
    }
}
