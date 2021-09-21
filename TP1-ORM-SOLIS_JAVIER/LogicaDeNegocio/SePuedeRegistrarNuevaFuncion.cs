using System;
using System.Collections.Generic;
using TP1_ORM_SOLIS_JAVIER.DB_manipulation;
using TP1_ORM_SOLIS_JAVIER.Entities;
using TP1_ORM_SOLIS_JAVIER.EntitiesDTO;


namespace TP1_ORM_SOLIS_JAVIER.LogicaDeNegocio
{
    public class SePuedeRegistrarNuevaFuncion
    {
        public bool VerificarEspacioEnSalaParaAgregarFuncion(FuncionesDTO funcion)
        {

            GetFuncionesBySalaIdQuery getFuncionesBySalaIdQuery = new GetFuncionesBySalaIdQuery();
            TimeSpan ventana = new TimeSpan(2, 30, 0);

            bool noSeSuperpone_flag = false;

            List<Funciones> funcionesSuperpuestas = new List<Funciones>();
            List<Funciones> funcionesConIgualDiaSala = new List<Funciones>();

            List<Funciones> funcionesConIgualSala = getFuncionesBySalaIdQuery.GetFuncionesBySalaId(funcion.SalaId);

            Console.WriteLine("Funciones con igual sala.count:"+funcionesConIgualSala.Count);

            foreach (Funciones elem in funcionesConIgualSala)
            {
                if (elem.Fecha == funcion.Fecha)
                {
                    funcionesConIgualDiaSala.Add(elem);
                }
            
            }

            Console.WriteLine("Funciones con igual dia y sala.count:" + funcionesConIgualDiaSala.Count);

            TimeSpan horaInicioNuevaFuncion = funcion.Horario;
            TimeSpan horaFinNuevaFuncion = funcion.Horario + ventana;

            foreach (Funciones elem in funcionesConIgualDiaSala)
            {
                if ( ((elem.Horario >= horaInicioNuevaFuncion) && (elem.Horario < horaFinNuevaFuncion)) ||
                     (((elem.Horario + ventana) > horaInicioNuevaFuncion) && (elem.Horario <= horaInicioNuevaFuncion)) )
                {
                    Console.WriteLine("Validacion:");
                    Console.WriteLine("elem.Horario: "+elem.Horario);
                    Console.WriteLine("horaInicioNuevaFuncion: "+horaInicioNuevaFuncion);
                    Console.WriteLine("horaFinNuevaFuncion: "+horaFinNuevaFuncion);
                    Console.WriteLine("ventana: "+ventana);
                    Console.WriteLine("elem.Horario + ventana: "+ (elem.Horario + ventana));
                    Console.WriteLine("--------------------------");
                    funcionesSuperpuestas.Add(elem);
                }

            }

            Console.WriteLine("Funciones superpuestas count: " + funcionesSuperpuestas.Count);

            if (funcionesSuperpuestas.Count == 0)
            {
                noSeSuperpone_flag = true;
            }

            return noSeSuperpone_flag;

        }

    }
}
