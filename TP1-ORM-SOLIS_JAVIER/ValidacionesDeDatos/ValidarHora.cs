using System;
using System.Text.RegularExpressions;

namespace TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos
{
    public class ValidarHora
    {
        public bool Validar(string horario)
        {
            bool esValido = false;
            int hora, minutos;
            

            if (horario == "")
            {
                Console.WriteLine("ERROR. No ha ingresado hora.");
            }
            else
            {

                Regex re = new Regex(@"\d{2}:\d{2}");

                if (re.IsMatch(horario))
                {
                    hora = Int32.Parse(horario.Substring(0, 2));
                    minutos = Int32.Parse(horario.Substring(0, 2));

                    if (hora > 23 || minutos > 60)
                    {
                        Console.WriteLine("ERROR. Ingrese una hora valida (ver formato de ingreso).");
                    }
                    else
                    {
                        esValido = true;
                    }
                }

            }
            return esValido;
        }

    }
}
