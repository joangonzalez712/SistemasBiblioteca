using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SistemasBiblioteca.Datos;
using SistemasBiblioteca.Entidades;
using System.Data;
namespace SistemasBiblioteca.Negocio
{
    public class AutorNegocio

    {
        AutorDatos autorDatos=new AutorDatos();

        public void Guardar(Autor autor)
        {
            if(string.IsNullOrWhiteSpace(autor.Nombre))

            {

                throw new Exception("Debe ingresar el nombre del autor");


            }


            if (string.IsNullOrWhiteSpace(autor.Apellido))

            {

                throw new Exception("Debe ingresar el Apellido del autor");


            }

           


            autorDatos.Guardar(autor);


           



        }


        public DataTable Listar()
        {
            return autorDatos.Listar();
        }

        public void Actualizar(Autor autor)
        {
            if (string.IsNullOrWhiteSpace(autor.Nombre))
            {
                throw new Exception(
                    "Debe ingresar el nombre");
            }

            if (string.IsNullOrWhiteSpace(autor.Apellido))
            {
                throw new Exception(
                    "Debe ingresar el apellido");
            }

            autorDatos.Actualizar(autor);
        }
        public void Eliminar(int idAutor)
        {
            autorDatos.Eliminar(idAutor);
        }

        public DataTable CargarCombo()
        {
            return autorDatos.CargarCombo();
        }
    }
}
