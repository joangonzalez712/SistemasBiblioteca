using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemasBiblioteca.Formularios;

namespace SistemasBiblioteca
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            FrmAutores frm=new FrmAutores();

            frm.ShowDialog();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            FrmEditoriales frm = new FrmEditoriales();

            frm.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();

            frm.ShowDialog();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
          FrmLibros frm = new FrmLibros();

            frm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes();

            frm.ShowDialog();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FrmPrestamos frm = new FrmPrestamos();



            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
