using System;
using System.Windows.Forms;
using SistemasBiblioteca.Entidades;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class FrmLibros : Form
    {
        LibroNegocio libroNegocio =
            new LibroNegocio();

        AutorNegocio autorNegocio =
            new AutorNegocio();

        EditorialNegocio editorialNegocio =
            new EditorialNegocio();

        int idLibroSeleccionado = 0;

        public FrmLibros()
        {
            InitializeComponent();

            CargarCombos();

            CargarLibros();
        }

        private void CargarCombos()
        {
            cbAutor.DataSource =
                autorNegocio.CargarCombo();

            cbAutor.DisplayMember =
                "Nombre";

            cbAutor.ValueMember =
                "IdAutor";


            cbEditorial.DataSource =
                editorialNegocio.CargarCombo();

            cbEditorial.DisplayMember =
                "Nombre";

            cbEditorial.ValueMember =
                "IdEditorial";
        }

        private void CargarLibros()
        {
            dgvLibros.DataSource =
                libroNegocio.Listar();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtISBN.Clear();
            txtTitulo.Clear();
            txtStock.Clear();

            idLibroSeleccionado = 0;

            txtCodigo.Focus();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Libro libro =
                    new Libro();

                libro.Codigo =
                    txtCodigo.Text;

                libro.ISBN =
                    txtISBN.Text;

                libro.Titulo =
                    txtTitulo.Text;

                libro.Stock =
                    Convert.ToInt32(
                        txtStock.Text);

                libro.IdAutor =
                    Convert.ToInt32(
                        cbAutor.SelectedValue);

                libro.IdEditorial =
                    Convert.ToInt32(
                        cbEditorial.SelectedValue);

                libroNegocio.Guardar(
                    libro);

                CargarLibros();

                LimpiarCampos();

                MessageBox.Show(
                    "Libro guardado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void dgvLibros_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvLibros.Rows[e.RowIndex];

                idLibroSeleccionado =
                    Convert.ToInt32(
                    fila.Cells["IdLibro"].Value);

                txtCodigo.Text =
                    fila.Cells["Codigo"]
                    .Value.ToString();

                txtISBN.Text =
                    fila.Cells["ISBN"]
                    .Value.ToString();

                txtTitulo.Text =
                    fila.Cells["Titulo"]
                    .Value.ToString();

                txtStock.Text =
                    fila.Cells["Stock"]
                    .Value.ToString();

                cbAutor.Text =
                    fila.Cells["Autor"]
                    .Value.ToString();

                cbEditorial.Text =
                    fila.Cells["Editorial"]
                    .Value.ToString();
            }
        }

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idLibroSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un libro");

                    return;
                }

                Libro libro =
                    new Libro();

                libro.IdLibro =
                    idLibroSeleccionado;

                libro.Codigo =
                    txtCodigo.Text;

                libro.ISBN =
                    txtISBN.Text;

                libro.Titulo =
                    txtTitulo.Text;

                libro.Stock =
                    Convert.ToInt32(
                        txtStock.Text);

                libro.IdAutor =
                    Convert.ToInt32(
                        cbAutor.SelectedValue);

                libro.IdEditorial =
                    Convert.ToInt32(
                        cbEditorial.SelectedValue);

                libroNegocio.Actualizar(
                    libro);

                CargarLibros();

                LimpiarCampos();

                MessageBox.Show(
                    "Libro actualizado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idLibroSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un libro");

                    return;
                }

                DialogResult respuesta =
                    MessageBox.Show(
                    "¿Desea eliminar este libro?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    libroNegocio.Eliminar(
                        idLibroSeleccionado);

                    CargarLibros();

                    LimpiarCampos();

                    MessageBox.Show(
                        "Libro eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}