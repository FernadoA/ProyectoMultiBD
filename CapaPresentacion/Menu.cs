using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        private SesionActualCN SesionActualCN = new SesionActualCN();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            validarSesion();
        }

        private void consultasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.Show();
        }


        private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidosxperiodo pedidosxperiodo = new Pedidosxperiodo();
            pedidosxperiodo.Show();
        }

        private void porPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devolucionesxperiodo devolucionesxperiodo = new Devolucionesxperiodo();
            devolucionesxperiodo.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.Show();
        }

        private void validarSesion()
        {
            lblUsuario.Text = SesionActualCN.UsuarioActual;
            lblRol.Text = SesionActualCN.RolActual;

            if (SesionActualCN.RolActual == "User")
            {
                consultasToolStripMenuItem.Enabled = false;
                consultasToolStripMenuItem1.Enabled = false;
                consultasToolStripMenuItem2.Enabled = false;
            }
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }
    }
}
