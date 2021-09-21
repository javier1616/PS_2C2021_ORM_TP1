using System;
using TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos;

namespace TP1_ORM_SOLIS_JAVIER.Classes.Menus
{
    public class MenuSeleccionarFechaHora : Menu
    {
        DateTime fecha_hora;
        string fecha, horario;

        public MenuSeleccionarFechaHora()
        {
            bool fechaCorrectaFlag = false;
            bool horaCorrectaFlag = false;
            int horas,minutos,dia,mes,anio;

            ValidarFecha validarFecha = new ValidarFecha();
            ValidarHora validarHora = new ValidarHora();

            tituloDelMenu = "Seleccion de Hora y Fecha";

            while (!fechaCorrectaFlag && !horaCorrectaFlag)
            {
                fechaCorrectaFlag = false;
                horaCorrectaFlag = false;

                while (!fechaCorrectaFlag)
                {
                    Console.WriteLine("Seleccione Fecha para la función (formato dd/mm/yyyy)");
                    fecha = Console.ReadLine();
                    fechaCorrectaFlag = validarFecha.Validar(fecha);
                }

                while (!horaCorrectaFlag)
                {
                    Console.WriteLine("Seleccione Hora para la función (formato hh:mm)");
                    horario = Console.ReadLine();
                    horaCorrectaFlag = validarHora.Validar(horario);
                }

                dia = Int32.Parse(fecha.Substring(0, 2));
                mes = Int32.Parse(fecha.Substring(3, 2));
                anio = Int32.Parse(fecha.Substring(6, 4));
                horas = Int32.Parse(horario.Substring(0, 2));
                minutos = Int32.Parse(horario.Substring(3, 2));
                
                fecha_hora = new DateTime(anio, mes, dia, horas, minutos, 0);

            }

        }

        override public void EjecutarOpcion()
        {

        }

        public DateTime GetFechaHora()
        {
            return fecha_hora;  
        }

    }

}

