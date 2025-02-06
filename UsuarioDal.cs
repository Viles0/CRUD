using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class UsuarioDal
    {
        public static int Crear(string ID, string Nombre)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.Conexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert into Usuario (ID, Nombre) Values ('{0}', '{1}')", ID, Nombre), Conn);
                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }
        public static List<Usuario> BuscarUsuario(String ID, String Nombre)
        {
            List<Usuario> Lista = new List<Usuario>();
            using (SqlConnection Conn = ConexionBD.Conexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select ID,Nombre From Usuario Where ID = '{0}' or Nombre = '{1}'", ID, Nombre), Conn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario pusuario = new Usuario();
                    pusuario.ID = Convert.ToString(reader.GetInt32(0));
                    pusuario.Nombre = reader.GetString(1);
                    Lista.Add(pusuario);
                }
                Conn.Close();
                return Lista;
            }
        }
        public static Usuario ModificarUsuario(string pID, string pNombre)
        {
            using (SqlConnection Conn = ConexionBD.Conexion())
            {
                Usuario pusuario = new Usuario();
                SqlCommand comando = new SqlCommand(string.Format("Select ID, Nombre From Usuario Where ID = '{0}' or Nombre= '{1}'", pID, pNombre), Conn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    pusuario.ID = Convert.ToString(reader.GetInt32(0));
                    pusuario.ID = reader.GetString(1);
                }
                Conn.Close();
                return pusuario;
            }
        }
        public static bool EliminarUsuario(string ID)
        {
            using(SqlConnection Conn = ConexionBD.Conexion())
            {
                SqlCommand comando = new SqlCommand("DELETE From Usuario Where ID = ID", Conn);
                comando.Parameters.AddWithValue("ID", ID);

                int rowsAffected = comando.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
