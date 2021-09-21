using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio
{
    public class VerificarSiHayLugarEnFuncion
    {
        public bool VerificarLugaresDisponibles(int funcionId, int cantidad)
        {
            GetFuncionByFuncionIdQuery getFuncionByFuncionId = new GetFuncionByFuncionIdQuery();
            GetTicketsByFunctionIdQuery getTicketsByFunctionIdQuery = new GetTicketsByFunctionIdQuery();
            GetSalaByIdQuery getSalaByIdQuery = new GetSalaByIdQuery();
            GetTicketsByFunctionIdQuery getTickets = new GetTicketsByFunctionIdQuery();

            Funciones funcion;
            Salas sala;
            List<Tickets> listaDeTickets = new List<Tickets>();
            int ticketsVendidos = 0;
            bool hayLugar = false;


            funcion = getFuncionByFuncionId.GetFuncionByFuncionId(funcionId);
            sala = getSalaByIdQuery.GetSalaById(funcion.SalaId);
            listaDeTickets = getTickets.GetTicketsByFunctionId(funcionId);

            ticketsVendidos = listaDeTickets.Count;

            if ((ticketsVendidos + cantidad) <= sala.Capacidad) hayLugar = true;

            return hayLugar;

        }

    }
}
