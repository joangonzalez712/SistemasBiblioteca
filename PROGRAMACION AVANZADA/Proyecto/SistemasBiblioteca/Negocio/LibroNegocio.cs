using System;
using System.Data;
using SistemasBiblioteca.Datos;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Negocio
{
    public class LibroNegocio
    {
        LibroDatos libroDatos =
            new LibroDatos();

        public void Guardar(Libro libro)
        {
            if (string.IsNullOrWhiteSpace(libro.Codigo))
            {
                throw new Exception(
                    "Ingrese el código");
            }

            if (string.IsNullOrWhiteSpace(libro.ISBN))
            {
                throw new Exception(
                    "Ingrese el ISBN");
            }

            if (string.IsNullOrWhiteSpace(libro.Titulo))
            {
                throw new Exception(
                    "Ingrese el título");
            }

            libroDatos.Guardar(libro);
        }

        public DataTable Listar()
        {
            return libroDatos.Listar();
        }

        public void Actualizar(Libro libro)
        {
            libroDatos.Actualizar(libro);
        }

        public void Eliminar(int idLibro)
        {
            libroDatos.Eliminar(idLibro);
        }
    }
}