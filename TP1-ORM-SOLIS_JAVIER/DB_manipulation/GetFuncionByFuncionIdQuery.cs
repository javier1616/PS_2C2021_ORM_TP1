using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetFuncionByFuncionIdQuery

    {
        public Funciones GetFuncionByFuncionId(int funcionId)
        {

            Context context = new Context();
            
            return  context.Set<Funciones>().Where(x => x.FuncionId == funcionId).First();

        }
    }
}
