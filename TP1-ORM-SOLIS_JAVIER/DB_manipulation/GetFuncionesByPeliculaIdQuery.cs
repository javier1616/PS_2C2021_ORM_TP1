using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetFuncionesByPeliculaIdQuery
    {
        public List<Funciones> GetFuncionesByPeliculaId(int id)
        {

            Context context = new Context();

            return context.Set<Funciones>().Where(x => x.PeliculaId == id).ToList();
        }

    }

}

