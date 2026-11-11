using System;
using System.Data;
using System.Data.SqlClient;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Datos
{
    public class LibroDatos
    {
        Conexion conexion = new Conexion();

        public void Guardar(Libro libro)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"INSERT INTO Libros
                (Codigo,ISBN,Titulo,Stock,IdAutor,IdEditorial)
                VALUES
                (@Codigo,@ISBN,@Titulo,@Stock,@IdAutor,@IdEditorial)";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@Codigo", libro.Codigo);
            cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
            cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
            cmd.Parameters.AddWithValue("@Stock", libro.Stock);
            cmd.Parameters.AddWithValue("@IdAutor", libro.IdAutor);
            cmd.Parameters.AddWithValue("@IdEditorial", libro.IdEditorial);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable Listar()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                @"SELECT
                    l.IdLibro,
                    l.Codigo,
                    l.ISBN,
                    l.Titulo,
                    l.Stock,
                    a.Nombre AS Autor,
                    e.Nombre AS Editorial
                  FROM Libros l
                  INNER JOIN Autores a
                    ON l.IdAutor = a.IdAutor
                  INNER JOIN Editoriales e
                    ON l.IdEditorial = e.IdEditorial";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void Actualizar(Libro libro)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"UPDATE Libros
                  SET Codigo=@Codigo,
                      ISBN=@ISBN,
                      Titulo=@Titulo,
                      Stock=@Stock,
                      IdAutor=@IdAutor,
                      IdEditorial=@IdEditorial
                  WHERE IdLibro=@IdLibro";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
            cmd.Parameters.AddWithValue("@Codigo", libro.Codigo);
            cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
            cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
            cmd.Parameters.AddWithValue("@Stock", libro.Stock);
            cmd.Parameters.AddWithValue("@IdAutor", libro.IdAutor);
            cmd.Parameters.AddWithValue("@IdEditorial", libro.IdEditorial);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public void Eliminar(int idLibro)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                "DELETE FROM Libros WHERE IdLibro=@IdLibro";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdLibro",
                idLibro);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}