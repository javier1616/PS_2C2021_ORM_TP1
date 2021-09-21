using System;
using System.Text.RegularExpressions;

namespace TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos
{
    public class ConvertirStrAFecha
    {

        public DateTime Convertir(string fecha)
        {
            string dia, mes, anio;
            DateTime date;

            // @"\d{ 1, 2 }/\d{ 1,2}\(\d{ 4}|\d{ 2}" - permite variar formato  dd | d / m | mm / yy | yyyy
            Regex re = new Regex(@"\d{2}/\d{2}\(\d{4}");

            if (re.IsMatch(fecha))
            {
                dia = fecha.Substring(0, 2);
                mes = fecha.Substring(3, 2);
                anio = fecha.Substring(6, 4);

                if (DateTime.TryParse(mes + "/" + dia + "/" + anio, out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("ERROR. Error de conversion de fecha");
                    return DateTime.MinValue;    //  (1/1/0001 12:00:00 AM)
                }

            }

            Console.WriteLine("ERROR. Error de conversion de fecha");
            return DateTime.MinValue;    //  (1/1/0001 12:00:00 AM)

        }

    }
}
