using System.Collections.Generic;
using System.Linq;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    class GetTicketsByFunctionIdQuery
    {
        public List<Tickets> GetTicketsByFunctionId(int funcionId)
        {
            Context context = new Context();
          
            return context.Set<Tickets>().
                            Where(x => x.FuncionId == funcionId).ToList();
        }
    }
}
