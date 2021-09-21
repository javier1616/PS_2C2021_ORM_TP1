
using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesDTO;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    public class PostTickets
    {
        public List<Tickets> PostVariosTickets(int funcionId, string usuario, int cantidad)
        {

            List<Tickets> listaDeTickets = new List<Tickets>();

            Context context = new Context();

            for (int i = 1; i <= cantidad; i++)
            {
                Tickets ticket = new Tickets
                {
                    TicketId = new Guid(),
                    FuncionId = funcionId,
                    Usuario = usuario,
                };

                context.Add(ticket);
                context.SaveChanges();
                listaDeTickets.Add(ticket);

            }

            return listaDeTickets;

        }
    }

}

