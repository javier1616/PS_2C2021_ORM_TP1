using System;
using System.Collections.Generic;
using System.Text;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }
        public string Descripcion { get; set; }

        // Comanda contiene una FK de esta tabla, este es el otro extremo de la relación
        public ICollection<Comanda> Comanda { get; set; }

    }
}
