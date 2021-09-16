using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; } // PK
        public string Descripcion { get; set; }

        // Mercaderia contiene una FK de esta tabla, este es el otro extremo de la relación
        public ICollection<Mercaderia> Mercaderia { get; set; }

    }
}
