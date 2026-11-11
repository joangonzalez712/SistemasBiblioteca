using SistemasBiblioteca.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemasBiblioteca.Datos
{
    public class EditorialDatos
    {
        Conexion conexion = new Conexion();

        public void Guardar(Editorial editorial)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                "INSERT INTO Editoriales (Nombre) VALUES (@Nombre)";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@Nombre",
                editorial.Nombre);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable Listar()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                "SELECT * FROM Editoriales";

            SqlDataAdapter da =
                new SqlDataAdapter(
                    consulta,
                    cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void Actualizar(Editorial editorial)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"UPDATE Editoriales
                  SET Nombre=@Nombre
                  WHERE IdEditorial=@IdEditorial";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdEditorial",
                editorial.IdEditorial);

            cmd.Parameters.AddWithValue(
                "@Nombre",
                editorial.Nombre);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public void Eliminar(int idEditorial)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"DELETE FROM Editoriales
                  WHERE IdEditorial=@IdEditorial";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdEditorial",
                idEditorial);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public bool TieneLibros(int idEditorial)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"SELECT COUNT(*)
                  FROM Libros
                  WHERE IdEditorial=@IdEditorial";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdEditorial",
                idEditorial);

            int cantidad =
                Convert.ToInt32(
                    cmd.ExecuteScalar());

            cn.Close();

            return cantidad > 0;
        }
        public DataTable CargarCombo()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                "SELECT * FROM Editoriales";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }
    }
}