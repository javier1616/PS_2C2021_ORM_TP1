using System;

namespace TP1_ORM_SOLIS_JAVIER.ValidacionesDeDatos
{
    public class ValidacionDeDatos
    {
        public bool ValidarDato(string cadena, string tipoDeDato)
        {
            bool esValido = false;

            if(cadena == "")
            {
                Console.WriteLine("ERROR. Recuerde ingresar un valor !");
            }
            else
            {

                switch (tipoDeDato)
                {
                    case "string":

                        esValido = true;
                        break;

                    case "string_50":

                        if (cadena.Length <= 50)
                        {
                            esValido = true;
                        }
                        else
                        {
                            Console.Write("Nombre muy largo.");
                            Console.WriteLine("Ingrese un nombre mas corto.");
                        }

                        break;

                    case "int":

                        int value;

                        if (Int32.TryParse(cadena, out value))
                        {
                            if (value <= 0)
                            {
                                Console.WriteLine("Debe ingresar un valor positivo");
                            }
                            else
                            {
                                esValido = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Debe ingresar un numero entero");
                        }

                        break;

                    default:

                        Console.WriteLine("ERROR !");
                        break;

                }

            }

            return esValido;
        }

    }
}
