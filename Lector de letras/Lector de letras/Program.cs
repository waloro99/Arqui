using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lector_de_letras
{
    class Program
    {
        //Declaracion de variables
        public static String cadena = "";
        public static char[] textoC;
        public static int contador=32;


        static void Main(string[] args)
        {
            Console.WriteLine("ESCRIBA LA PALABRA O LETRA: ");
            cadena = Console.ReadLine();
            textoC = cadena.ToCharArray(0, cadena.Length);
            for (int i = 0; i < cadena.Length; i++)
            {
                Salida(textoC[i]);
                Console.WriteLine(textoC[i]);
            }
            Console.ReadKey();
        }


        public static void Salida(char letra)
        {
            // escribir dentro de un txt para dar una solucion y se crea en la direccion de abajo
            string salida = @"C:\Users\walte\Desktop\Salida{0}.tst";
            var NuevoArchivo = string.Format(salida, letra.ToString());
            StreamWriter Escribir = new StreamWriter(NuevoArchivo);
            String en, load, address, reloj,resultado;

            Escribir.WriteLine("load Screen.hdl, \n");
            Escribir.WriteLine("output-file screen.out, \n");
            Escribir.WriteLine("output-list in out, \n");


            for (int i = 0; i < 15; i++)
            {
                if (i<3)
                {
                    en = "set in %B0000000000000000, ";
                    load = "set load 1 , ";
                    address = "set address %B"+ Address(contador) + ", ";
                    reloj = "tick, tock, output;";
                    resultado = (en + load + address + reloj);
                    Escribir.WriteLine(resultado);
                    contador += 32; // luego se pasaraa binario
                }
                else if (i>11)
                {
                    en = "set in %B0000000000000000, ";
                    load = "set load 1 , ";
                    address = "set address %B" + Address(contador) + ", ";
                    reloj = "tick, tock, output;";
                    resultado = (en + load + address + reloj);
                    Escribir.WriteLine(resultado);
                    contador += 32; // luego se pasaraa binario
                    //Reinicia contador 
                    if (contador == 512)
                    {
                        contador = 32;
                    }
                }
                else
                {
                    en = "set in %B"+ En(letra) +", ";
                    load = "set load 1 , ";
                    address = "set address %B" + Address(contador) + ", ";
                    reloj = "tick, tock, output;";
                    resultado = (en + load + address + reloj);
                    Escribir.WriteLine(resultado);
                    contador += 32; // luego se pasaraa binario
                }
            }
            Escribir.Close();
        }


        //Se debde de leer la letra y hacer la secuencia de ceros y unos
        public static string En(char letra)
        {
            return "0000111001110000";
        }

        public static string Address(int numero)
        {
            //Codigo para pasar a binario el numero
            String cadena = "";
            while (numero > 0)
            {
                if (numero % 2 == 0)
                {
                    cadena = "0" + cadena;
                }
                else
                {
                    cadena = "1" + cadena;
                }
                numero = (int)(numero / 2);
            }

            // verificar que el numero sea de 13 digitos
            if (cadena.Length != 13)
            {
                int falta = 13 - cadena.Length;
                string ceros = "";
                for (int i = 0; i < falta; i++)
                {
                    ceros = ceros + "0";
                }
                cadena = ceros + cadena;
            }

            return cadena;
        }
    }
}
