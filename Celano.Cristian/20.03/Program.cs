using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._03
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int ingreso;
            int max=0;
            int min=0;
            int acum=0;
            int prom;
            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("ingrese un numero");
                ingreso = int.Parse (Console.ReadLine());
                acum = acum + ingreso;
                if (i == 0)
                {
                    max = ingreso;
                    min = ingreso;
                }
                if (max < ingreso)
                    max = ingreso;
                if (min > ingreso)
                    min = ingreso;
            }
            prom = acum / i;
            Console.WriteLine("Max: {0}\nMin: {1}\nProm: {2}", max, min, prom);
            Console.Read();
        }
    }
}
