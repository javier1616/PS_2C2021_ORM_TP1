using System;

namespace TP1_ORM_SOLIS_JAVIER.Entities
{
    public class Tickets
    {
        public Guid TicketId { get; set; } // PK

        //defino FuncionId como FK            
        public int FuncionId { get; set; }   // FK Property
        public Funciones Funciones { get; set; } // Reference Property

        public string Usuario { get; set; }

    }
}
