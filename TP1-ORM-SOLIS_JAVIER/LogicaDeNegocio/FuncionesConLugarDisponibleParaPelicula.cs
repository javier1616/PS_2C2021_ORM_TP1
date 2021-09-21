
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;

namespace TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio
{
    public class FuncionesConLugarDisponibleParaPelicula
    {
        public List<Funciones> FuncionesDisponiblesParaPelicula(Peliculas pelicula)
        {
            GetFuncionesByPeliculaIdQuery getFuncionesByPeliculaIdQuery = new GetFuncionesByPeliculaIdQuery();
            GetTicketsByFunctionIdQuery getTicketsByFunctionIdQuery = new GetTicketsByFunctionIdQuery();
            GetSalaByIdQuery getSalaByIdQuery = new GetSalaByIdQuery();
            List<Funciones> listaDeFuncionesDeUnaPelicula;
            List<Tickets> listaDeTicketsDeUnaFuncion;
            List<Funciones> listaDeFuncionesDisponibles = new List<Funciones>();
            Salas sala;
            int cantidadDeTicketsVendidos;

            listaDeFuncionesDeUnaPelicula = getFuncionesByPeliculaIdQuery.GetFuncionesByPeliculaId(pelicula.PeliculaId);

            foreach (Funciones elem in listaDeFuncionesDeUnaPelicula)
            {
                listaDeTicketsDeUnaFuncion = getTicketsByFunctionIdQuery.GetTicketsByFunctionId(elem.FuncionId);
                sala = getSalaByIdQuery.GetSalaById(elem.SalaId);

                cantidadDeTicketsVendidos = listaDeTicketsDeUnaFuncion.Count;

                if (cantidadDeTicketsVendidos < sala.Capacidad)
                {
                    listaDeFuncionesDisponibles.Add(elem);                    
                }

            }

            return listaDeFuncionesDisponibles;

        }

    }
}
