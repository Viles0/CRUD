using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class ConexionBD
    {
        public static SqlConnection Conexion()
        {
            SqlConnection Conn = new SqlConnection("Data Source= DESKTOP-E5DE62R\\COBOPOLI3T;Initial Catalog=CRUD;Integrated Security=True");
            Conn.Open();
            return Conn;
        }
    }
}
