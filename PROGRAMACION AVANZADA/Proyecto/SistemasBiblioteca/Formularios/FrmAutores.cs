using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using SistemasBiblioteca.Entidades;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class FrmAutores : Form
    {
        AutorNegocio autorNegocio = new AutorNegocio();

        int idAutorSeleccionado = 0;

        public FrmAutores()
        {
            InitializeComponent();

            CargarAutores();
        }

        private void CargarAutores()
        {
            dgvAutores.DataSource =
                autorNegocio.Listar();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Autor autor = new Autor();

                autor.Nombre = txtNombre.Text;

                autor.Apellido = txtApellido.Text;

                autorNegocio.Guardar(autor);

                CargarAutores();

                MessageBox.Show(
                    "Autor guardado correctamente");

                txtNombre.Clear();

                txtApellido.Clear();

                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAutores_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idAutorSeleccionado =
                    Convert.ToInt32(
                    dgvAutores.Rows[e.RowIndex]
                    .Cells["IdAutor"].Value);

                txtNombre.Text =
                    dgvAutores.Rows[e.RowIndex]
                    .Cells["Nombre"].Value
                    .ToString();

                txtApellido.Text =
                    dgvAutores.Rows[e.RowIndex]
                    .Cells["Apellido"].Value
                    .ToString();

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAutorSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un autor");

                    return;
                }

                Autor autor = new Autor();

                autor.IdAutor =
                    idAutorSeleccionado;

                autor.Nombre =
                    txtNombre.Text;

                autor.Apellido =
                    txtApellido.Text;

                autorNegocio.Actualizar(autor);

                CargarAutores();

                MessageBox.Show(
                    "Autor actualizado correctamente");

                txtNombre.Clear();
                txtApellido.Clear();

                idAutorSeleccionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtNombre.Clear();

            txtApellido.Clear();

            idAutorSeleccionado = 0;

            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAutorSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un autor");

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                        "¿Desea eliminar este autor?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    autorNegocio.Eliminar(
                        idAutorSeleccionado);

                    CargarAutores();

                    txtNombre.Clear();

                    txtApellido.Clear();

                    idAutorSeleccionado = 0;

                    MessageBox.Show(
                        "Autor eliminado correctamente");
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))


                {

                    MessageBox.Show(

                        "No se puede eliminar el autor porque tiene libros asociados."
                        );
                    
                }

                else
                MessageBox.Show(ex.Message);

               
            }


            



        }
    }
}

