using System;
using System.Windows.Forms;
using SistemasBiblioteca.Entidades;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class FrmUsuarios : Form
    {
        UsuarioNegocio usuarioNegocio =
            new UsuarioNegocio();

        int idUsuarioSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource =
                usuarioNegocio.Listar();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            idUsuarioSeleccionado = 0;

            txtNombre.Focus();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Usuario usuario =
                    new Usuario();

                usuario.Nombre =
                    txtNombre.Text;

                usuario.Apellido =
                    txtApellido.Text;

                usuario.Documento =
                    txtDocumento.Text;

                usuario.Telefono =
                    txtTelefono.Text;

                usuario.Correo =
                    txtCorreo.Text;

                usuarioNegocio.Guardar(
                    usuario);

                CargarUsuarios();

                LimpiarCampos();

                MessageBox.Show(
                    "Usuario guardado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvUsuarios.Rows[e.RowIndex];

                idUsuarioSeleccionado =
                    Convert.ToInt32(
                    fila.Cells["IdUsuario"].Value);

                txtNombre.Text =
                    fila.Cells["Nombre"]
                    .Value.ToString();

                txtApellido.Text =
                    fila.Cells["Apellido"]
                    .Value.ToString();

                txtDocumento.Text =
                    fila.Cells["Documento"]
                    .Value.ToString();

                txtTelefono.Text =
                    fila.Cells["Telefono"]
                    .Value.ToString();

                txtCorreo.Text =
                    fila.Cells["Correo"]
                    .Value.ToString();
            }
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idUsuarioSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                Usuario usuario =
                    new Usuario();

                usuario.IdUsuario =
                    idUsuarioSeleccionado;

                usuario.Nombre =
                    txtNombre.Text;

                usuario.Apellido =
                    txtApellido.Text;

                usuario.Documento =
                    txtDocumento.Text;

                usuario.Telefono =
                    txtTelefono.Text;

                usuario.Correo =
                    txtCorreo.Text;

                usuarioNegocio.Actualizar(
                    usuario);

                CargarUsuarios();

                LimpiarCampos();

                MessageBox.Show(
                    "Usuario actualizado correctamente");
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
                if (idUsuarioSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                    "¿Desea eliminar este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    usuarioNegocio.Eliminar(
                        idUsuarioSeleccionado);

                    CargarUsuarios();

                    LimpiarCampos();

                    MessageBox.Show(
                        "Usuario eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}