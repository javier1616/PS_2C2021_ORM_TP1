using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetSalaByIdQuery
    {
        public Salas GetSalaById(int salaId)
        {
            Context context = new Context();
          
            return context.Set<Salas>().
                            Where(x => x.SalaId == salaId).First();
        }
    }
}
