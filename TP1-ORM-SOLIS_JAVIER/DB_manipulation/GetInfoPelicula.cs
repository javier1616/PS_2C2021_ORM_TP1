using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetInfoPelicula
    {
        public Peliculas Informacion(int id)
        {


            Context context = new Context();


            return context.Set<Peliculas>().
                            Where(x => x.PeliculaId == id).First();
        }
    }
}
