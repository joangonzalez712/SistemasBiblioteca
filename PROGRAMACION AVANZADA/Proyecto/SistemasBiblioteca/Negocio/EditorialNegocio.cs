using System;
using System.Data;
using SistemasBiblioteca.Datos;
using SistemasBiblioteca.Entidades;

namespace SistemasBiblioteca.Negocio
{
    public class EditorialNegocio
    {
        EditorialDatos editorialDatos =
            new EditorialDatos();

        public void Guardar(Editorial editorial)
        {
            if (string.IsNullOrWhiteSpace(editorial.Nombre))
            {
                throw new Exception(
                    "Debe ingresar el nombre de la editorial");
            }

            editorialDatos.Guardar(editorial);
        }

        public DataTable Listar()
        {
            return editorialDatos.Listar();
        }

        public void Actualizar(Editorial editorial)
        {
            if (string.IsNullOrWhiteSpace(editorial.Nombre))
            {
                throw new Exception(
                    "Debe ingresar el nombre de la editorial");
            }

            editorialDatos.Actualizar(editorial);
        }

        public void Eliminar(int idEditorial)
        {
            if (editorialDatos.TieneLibros(idEditorial))
            {
                throw new Exception(
                    "No se puede eliminar la editorial porque tiene libros asociados.");
            }

            editorialDatos.Eliminar(idEditorial);
        }

        public DataTable CargarCombo()
        {
            return editorialDatos.CargarCombo();
        }
    }
}