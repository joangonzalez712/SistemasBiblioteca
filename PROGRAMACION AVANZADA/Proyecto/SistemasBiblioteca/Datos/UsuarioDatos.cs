using System;
using System.Data;
using System.Data.SqlClient;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Datos
{
    public class UsuarioDatos
    {
        Conexion conexion = new Conexion();

        public void Guardar(Usuario usuario)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"INSERT INTO Usuarios
                (Nombre,Apellido,Documento,Telefono,Correo)
                VALUES
                (@Nombre,@Apellido,@Documento,@Telefono,@Correo)";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            cmd.Parameters.AddWithValue("@Correo", usuario.Correo);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable Listar()
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

        public void Actualizar(Usuario usuario)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                @"UPDATE Usuarios
                  SET Nombre=@Nombre,
                      Apellido=@Apellido,
                      Documento=@Documento,
                      Telefono=@Telefono,
                      Correo=@Correo
                  WHERE IdUsuario=@IdUsuario";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            cmd.Parameters.AddWithValue("@Correo", usuario.Correo);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public void Eliminar(int idUsuario)
        {
            SqlConnection cn =
                conexion.ObtenerConexion();

            cn.Open();

            string consulta =
                "DELETE FROM Usuarios WHERE IdUsuario=@IdUsuario";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue(
                "@IdUsuario",
                idUsuario);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}