using System;
using System.Data;
using System.Data.SqlClient;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Datos
{
    public class PrestamoDatos
    {
        Conexion conexion = new Conexion();

        public DataTable CargarUsuarios()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                "SELECT * FROM Usuarios";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }

        public DataTable CargarLibros()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                "SELECT * FROM Libros WHERE Stock > 0";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void Guardar(Prestamo prestamo)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"INSERT INTO Prestamos
                (
                    IdUsuario,
                    IdLibro,
                    FechaPrestamo,
                    Estado
                )
                VALUES
                (
                    @IdUsuario,
                    @IdLibro,
                    @FechaPrestamo,
                    @Estado
                )";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdUsuario",
                prestamo.IdUsuario);

            cmd.Parameters.AddWithValue(
                "@IdLibro",
                prestamo.IdLibro);

            cmd.Parameters.AddWithValue(
                "@FechaPrestamo",
                prestamo.FechaPrestamo);

            cmd.Parameters.AddWithValue(
                "@Estado",
                prestamo.Estado);

            cmd.ExecuteNonQuery();

            string actualizarStock =
                @"UPDATE Libros
                  SET Stock = Stock - 1
                  WHERE IdLibro = @IdLibro";

            SqlCommand cmdStock =
                new SqlCommand(actualizarStock, cn);

            cmdStock.Parameters.AddWithValue(
                "@IdLibro",
                prestamo.IdLibro);

            cmdStock.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable Listar()
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            string consulta =
                @"SELECT
                    p.IdPrestamo,
                    u.Nombre + ' ' + u.Apellido AS Usuario,
                    l.Titulo AS Libro,
                    p.FechaPrestamo,
                    p.FechaDevolucion,
                    p.Estado
                FROM Prestamos p
                INNER JOIN Usuarios u
                    ON p.IdUsuario = u.IdUsuario
                INNER JOIN Libros l
                    ON p.IdLibro = l.IdLibro";

            SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn);

            DataTable dt =
                new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void Devolver(int idPrestamo)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string obtenerLibro =
                @"SELECT IdLibro
                  FROM Prestamos
                  WHERE IdPrestamo=@IdPrestamo";

            SqlCommand cmdLibro =
                new SqlCommand(obtenerLibro, cn);

            cmdLibro.Parameters.AddWithValue(
                "@IdPrestamo",
                idPrestamo);

            int idLibro =
                Convert.ToInt32(
                    cmdLibro.ExecuteScalar());

            string consulta =
                @"UPDATE Prestamos
                  SET Estado='Devuelto',
                      FechaDevolucion=GETDATE()
                  WHERE IdPrestamo=@IdPrestamo";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdPrestamo",
                idPrestamo);

            cmd.ExecuteNonQuery();

            string stock =
                @"UPDATE Libros
                  SET Stock = Stock + 1
                  WHERE IdLibro=@IdLibro";

            SqlCommand cmdStock =
                new SqlCommand(stock, cn);

            cmdStock.Parameters.AddWithValue(
                "@IdLibro",
                idLibro);

            cmdStock.ExecuteNonQuery();

            cn.Close();
        }
    }
}