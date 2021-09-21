using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetFuncionesBySalaIdQuery

    {
        public List<Funciones> GetFuncionesBySalaId(int salaId)
        {

            Context context = new Context();
            
            return  context.Set<Funciones>().Where(x => x.SalaId == salaId).ToList();

        }
    }
}
