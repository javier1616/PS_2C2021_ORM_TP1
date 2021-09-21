using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetSalasQuery
    {
        public List<Salas> GetSalas()
        {
            Context context = new Context();
          
            return context.Set<Salas>().ToList();
        }
    }
}
