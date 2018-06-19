using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Externa.Sellada;
using System.IO;
using System.Data.SqlClient;


namespace Entidades.Alumnos
{
    public static class Extensora
    {
        public static String ObtenerInfo(this Entidades.Alumnos.Persona p)
        {
            return p.Nombre + " - " + p.Apellido + " - " + p.Edad + " - " + p.Sexo.ToString();
        }

        public static String ObtenerInfoDLL(this Entidades.Externa.Sellada.PersonaExternaSellada p)
        {
            return p.Nombre + " - " + p.Apellido + " - " + p.Edad + " - " + p.Sexo.ToString();
        }

        public static bool EscribirArchivo(this Entidades.Externa.Sellada.PersonaExternaSellada p, String path)
        {
            bool retorno = false;
            try
            {
                StreamWriter escritor = new StreamWriter(path, true);
                escritor.WriteLine(DateTime.Now + " " + p.ObtenerInfoDLL());
                escritor.Close();
                retorno = true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al escribir en el archivo");
            }
            return retorno;
        }

        public static bool EsNulo(this Object obj)
        {
            bool retorno = false;

            if (obj == null)
            {
                retorno = true;
            }

            return retorno;
        }
        public static int CantidadCaracteres(this String palabra)
        {
            return palabra.Length;
        }

        public static bool EscribirEnBaseDeDatos(this Externa.Sellada.PersonaExternaSellada p)
        {
            bool retorno = false;
            try
            {
                int cant;
                String query = "INSERT INTO Persona (apellido,nombre,sexo) values ('"+p.Apellido+"','"+p.Nombre+"',"+p.Sexo.GetHashCode()+")";
            
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                Console.WriteLine(query);
                cant = comando.ExecuteNonQuery();
                conexion.Close();
                retorno = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al escribir en la bd");
            }


            return retorno;
        }

        public static List<Persona> LeerEnBaseDeDatos(this Entidades.Alumnos.Persona p)
        {
            List<Persona> personas=new List<Persona>();
            try
            {
                String query = "SELECT p.nombre,p.apellido,p.sexo FROM Persona as p";
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    personas.Add(new Persona(lector[1].ToString(), lector[0].ToString(), 21, (Entidades.Alumnos.ESexo)lector[2]));

                }
                lector.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer la BD");
            }
        
            return personas;
        }
    }
}
