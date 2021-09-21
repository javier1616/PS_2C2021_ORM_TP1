
using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesDTO;

namespace TP1_ORM_SOLIS_JAVIER.DB_manipulation
{
    public class PostFuncion
    {
        public void RegistrarFuncion(FuncionesDTO funcionDTO)
        {

            Context context = new Context();

            Funciones funcion = new Funciones
            {
                PeliculaId = funcionDTO.PeliculaId,
                SalaId = funcionDTO.SalaId,
                Fecha = funcionDTO.Fecha,
                Horario = funcionDTO.Horario
            };

            context.Add(funcion);
            context.SaveChanges();

        }
    }

}

