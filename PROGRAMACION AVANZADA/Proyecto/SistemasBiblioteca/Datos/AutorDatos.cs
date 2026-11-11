using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemasBiblioteca.Entidades;
using System.Data;

namespace SistemasBiblioteca.Datos
{
    public class AutorDatos
    {

        Conexion conexion = new Conexion();

        public void Guardar(Autor autor)

        {
            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();


            string consulta = "INSERT INTO Autores (Nombre,Apellido)  values (@Nombre,@Apellido)";



            SqlCommand cmd= new SqlCommand(consulta, cn);


            cmd.Parameters.AddWithValue(


                "@Nombre",
                autor.Nombre);

            cmd.Parameters.AddWithValue(
                "@Apellido",
                autor.Apellido
                );


            cmd.ExecuteNonQuery();


            cn.Close();
              
                
                
        }

        public DataTable Listar()
        {
            SqlConnection cn = conexion.ObtenerConexion();

            string consulta = "SELECT * FROM Autores";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }


        public void Actualizar(Autor autor)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"UPDATE Autores
          SET Nombre = @Nombre,
              Apellido = @Apellido
          WHERE IdAutor = @IdAutor";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdAutor",
                autor.IdAutor);

            cmd.Parameters.AddWithValue(
                "@Nombre",
                autor.Nombre);

            cmd.Parameters.AddWithValue(
                "@Apellido",
                autor.Apellido);

            cmd.ExecuteNonQuery();

            cn.Close();
        }


        public void Eliminar(int idAutor)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                "DELETE FROM Autores WHERE IdAutor = @IdAutor";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdAutor",
                idAutor);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable CargarCombo()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                "SELECT * FROM Autores";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }



    }
}
