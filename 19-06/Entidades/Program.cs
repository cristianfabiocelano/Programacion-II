using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Alumnos;
using Entidades.Externa;
using Entidades.Externa.Sellada;
namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Cristian", "Celano", 20, Entidades.Alumnos.ESexo.Masculino);
            PersonaExternaSellada p2 = new PersonaExternaSellada("Lucas", "Perez", 21, Externa.Sellada.ESexo.Indefinido);
            List<Persona> personas = p1.LeerEnBaseDeDatos();
            Console.WriteLine(p1.ToString());
            Console.Read();
            //p2.EscribirArchivo("C:\\Users\\alumno\\Desktop\\Texto.txt");

            p2.EscribirEnBaseDeDatos();

            foreach (Persona item in personas)
            {
               Console.WriteLine(item.ObtenerInfo());
            }
            Console.WriteLine();
            Console.Read();
            Console.Read();
        }
    }
}
