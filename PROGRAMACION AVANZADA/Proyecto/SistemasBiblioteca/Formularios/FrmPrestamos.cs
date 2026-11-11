using System;
using System.Windows.Forms;
using SistemasBiblioteca.Entidades;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class FrmPrestamos : Form
    {
        PrestamoNegocio prestamoNegocio =
            new PrestamoNegocio();

        int idPrestamoSeleccionado = 0;

        public FrmPrestamos()
        {
            InitializeComponent();

            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();

            txtEstado.Text = "Prestado";

            txtEstado.ReadOnly = true;
        }

        private void CargarUsuarios()
        {
            cbUsuario.DataSource =
                prestamoNegocio.CargarUsuarios();

            cbUsuario.DisplayMember =
                "Nombre";

            cbUsuario.ValueMember =
                "IdUsuario";
        }

        private void CargarLibros()
        {
            cbLibro.DataSource =
                prestamoNegocio.CargarLibros();

            cbLibro.DisplayMember =
                "Titulo";

            cbLibro.ValueMember =
                "IdLibro";
        }

        private void CargarPrestamos()
        {
            dgvPrestamos.DataSource =
                prestamoNegocio.Listar();
        }

        private void Limpiar()
        {
            txtEstado.Text = "Prestado";

            idPrestamoSeleccionado = 0;

            cbUsuario.SelectedIndex = 0;

            cbLibro.SelectedIndex = 0;
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Prestamo prestamo =
                    new Prestamo();

                prestamo.IdUsuario =
                    Convert.ToInt32(
                        cbUsuario.SelectedValue);

                prestamo.IdLibro =
                    Convert.ToInt32(
                        cbLibro.SelectedValue);

                prestamo.FechaPrestamo =
                    dtpFechaPrestamo.Value;

                prestamo.Estado =
                    "Prestado";

                prestamoNegocio.Guardar(
                    prestamo);

                CargarPrestamos();
                CargarLibros();

                Limpiar();

                MessageBox.Show(
                    "Préstamo registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void dgvPrestamos_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvPrestamos.Rows[e.RowIndex];

                idPrestamoSeleccionado =
                    Convert.ToInt32(
                        fila.Cells[0].Value);

                txtEstado.Text =
                    fila.Cells[5].Value.ToString();

                cbUsuario.Text =
                    fila.Cells[1].Value.ToString();

                cbLibro.Text =
                    fila.Cells[2].Value.ToString();
            }
        }

        private void btnDevolver_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                if (idPrestamoSeleccionado == 0)
                {
                    MessageBox.Show(
                        "Seleccione un préstamo");

                    return;
                }

                if (txtEstado.Text == "Devuelto")
                {
                    MessageBox.Show(
                        "Este préstamo ya fue devuelto");

                    return;
                }

                prestamoNegocio.Devolver(
                    idPrestamoSeleccionado);


                CargarPrestamos();

                CargarLibros();

                cbLibro.DataSource =
                    prestamoNegocio.CargarLibros();

                Limpiar();

                MessageBox.Show(
                    "Devolución registrada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }

    }
