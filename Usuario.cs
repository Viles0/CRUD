using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Usuario
    {
       public string ID { get; set;}
       public  string Nombre { get; set;}

        public Usuario()
        {

        }
        public Usuario(string ID, string Nombre)
        {
            this.ID = ID;
            this.Nombre = Nombre;
        }
    }
}
