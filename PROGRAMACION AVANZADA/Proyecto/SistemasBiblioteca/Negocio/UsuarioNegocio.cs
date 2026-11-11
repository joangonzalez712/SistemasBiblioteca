using System;
using System.Data;
using SistemasBiblioteca.Datos;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Negocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos usuarioDatos =
            new UsuarioDatos();

        public void Guardar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("Ingrese el nombre");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                throw new Exception("Ingrese el apellido");

            if (string.IsNullOrWhiteSpace(usuario.Documento))
                throw new Exception("Ingrese el documento");

            usuarioDatos.Guardar(usuario);
        }

        public DataTable Listar()
        {
            return usuarioDatos.Listar();
        }

        public void Actualizar(Usuario usuario)
        {
            usuarioDatos.Actualizar(usuario);
        }

        public void Eliminar(int idUsuario)
        {
            usuarioDatos.Eliminar(idUsuario);
        }
    }
}