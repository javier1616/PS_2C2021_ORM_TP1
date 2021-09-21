using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetPeliculasQuery
    {
        public List<Peliculas> GetPeliculas()
        {

            Context context = new Context();

            return context.Peliculas.ToList();
        }
    }
}
