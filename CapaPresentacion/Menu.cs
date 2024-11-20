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
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void consultasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.Show();
        }

        private void gestiónDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Show();
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

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devoluciones devoluciones = new Devoluciones();
            devoluciones.Show();
        }
    }
}
