using System;
using System.Data;
using SistemasBiblioteca.Datos;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Negocio
{
    public class PrestamoNegocio
    {
        PrestamoDatos prestamoDatos =
            new PrestamoDatos();

        public void Guardar(Prestamo prestamo)
        {
            prestamoDatos.Guardar(prestamo);
        }

        public DataTable Listar()
        {
            return prestamoDatos.Listar();
        }

        public void Devolver(int idPrestamo)
        {
            prestamoDatos.Devolver(idPrestamo);
        }

        public DataTable CargarUsuarios()
        {
            return prestamoDatos.CargarUsuarios();
        }

        public DataTable CargarLibros()
        {
            return prestamoDatos.CargarLibros();
        }
    }
}