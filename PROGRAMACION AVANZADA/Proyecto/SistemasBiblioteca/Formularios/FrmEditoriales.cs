using System;
using System.Windows.Forms;
using SistemasBiblioteca.Entidades;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class FrmEditoriales : Form
    {
        EditorialNegocio editorialNegocio =
            new EditorialNegocio();

        int idEditorialSeleccionada = 0;

        public FrmEditoriales()
        {
            InitializeComponent();

            CargarEditoriales();
        }

        private void CargarEditoriales()
        {
            dgvEditoriales.DataSource =
                editorialNegocio.Listar();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();

            idEditorialSeleccionada = 0;

            txtNombre.Focus();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Editorial editorial =
                    new Editorial();

                editorial.Nombre =
                    txtNombre.Text;

                editorialNegocio.Guardar(
                    editorial);

                CargarEditoriales();

                LimpiarCampos();

                MessageBox.Show(
                    "Editorial guardada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEditoriales_CellClick(
            object sender,
            DataGridViewCellEventArgs e)

       
        
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvEditoriales.Rows[e.RowIndex];

                idEditorialSeleccionada =
                    Convert.ToInt32(
                    fila.Cells["IdEditorial"].Value);

                txtNombre.Text =
                    fila.Cells["Nombre"]
                    .Value.ToString();
            }
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada == 0)
                {
                    MessageBox.Show(
                        "Seleccione una editorial");

                    return;
                }

                Editorial editorial =
                    new Editorial();

                editorial.IdEditorial =
                    idEditorialSeleccionada;

                editorial.Nombre =
                    txtNombre.Text;

                editorialNegocio.Actualizar(
                    editorial);

                CargarEditoriales();

                LimpiarCampos();

                MessageBox.Show(
                    "Editorial actualizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada == 0)
                {
                    MessageBox.Show(
                        "Seleccione una editorial");

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                    "¿Desea eliminar esta editorial?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    editorialNegocio.Eliminar(
                        idEditorialSeleccionada);

                    CargarEditoriales();

                    LimpiarCampos();

                    MessageBox.Show(
                        "Editorial eliminada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}