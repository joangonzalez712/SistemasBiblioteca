using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemasBiblioteca.Datos
{
    public class Conexion
    {
        private string cadenaconexion =

            @"Data Source=(localdb)\MSSQLLocalDB;
            Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;initial Catalog=SistemaBiblioteca";

        public SqlConnection ObtenerConexion()

        { 
        
        return new SqlConnection (cadenaconexion);
        
        }

    }
}
