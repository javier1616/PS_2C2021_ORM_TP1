using System;
using System.Text.RegularExpressions;

namespace TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos
{
    public class ValidarFecha
    {
        public bool Validar(string fecha)
        {
            bool esValido = false;
            string dia,mes,anio;
            DateTime date;

            if (fecha == "")
            {
                Console.WriteLine("ERROR. No ingreso fecha.");
            }
            else
            {
            
                // @"\d{ 1, 2 }/\d{ 1,2}\(\d{ 4}|\d{ 2}" - permite variar formato  dd | d / m | mm / yy | yyyy
                Regex re = new Regex(@"\d{2}/\d{2}/\d{4}");

                if (re.IsMatch(fecha))
                {
                    dia = fecha.Substring(0, 2);
                    mes = fecha.Substring(3, 2);
                    anio = fecha.Substring(6, 4);

                    if (DateTime.TryParse(dia+"/"+mes+"/"+anio, out date))
                    {
                        esValido = true;
                    }
                    else
                    {
                        Console.WriteLine("ERROR. Ingrese una fecha valida (ver formato de ingreso).");
                    }
                }

            }

            return esValido;
        }

    }
}
