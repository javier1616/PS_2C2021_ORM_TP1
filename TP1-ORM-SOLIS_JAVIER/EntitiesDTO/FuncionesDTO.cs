using System;

namespace TP1_ORM_SOLIS_JAVIER.EntitiesDTO
{
    public class FuncionesDTO
    {          
        public int PeliculaId { get; set; }              
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
    }
}
