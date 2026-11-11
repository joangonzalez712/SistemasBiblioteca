using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemasBiblioteca.Negocio;

namespace SistemasBiblioteca.Formularios
{
    public partial class frmReportes : Form
    {

        LibroNegocio libroNegocio = new LibroNegocio();

        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        
        PrestamoNegocio prestamoNegocio=new PrestamoNegocio();



        public frmReportes()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = libroNegocio.Listar();


            txtCantidad.Text = dgvReportes.Rows.Count.ToString();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = usuarioNegocio.Listar();


            txtCantidad.Text = dgvReportes.Rows.Count.ToString();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource = prestamoNegocio.Listar();


            txtCantidad.Text= dgvReportes.Rows.Count.ToString();
        }

        private void dgvReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

       

     }

 }



