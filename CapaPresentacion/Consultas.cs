using CapaNegocio;
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
    public partial class Consultas : Form
    {
        private ConsultasCN CapaNegocios = new ConsultasCN();
        private bool isLoading = true; // Indicador para cbox
        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            cBoxCliente.DataSource = CapaNegocios.ConsultaClientes().Tables["CONSCL"];
            cBoxCliente.DisplayMember = "Nombre";
            cBoxCliente.ValueMember = "IDCliente";
            cBoxCliente.SelectedIndex = -1;
            isLoading = false;
        }

        private void cBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading && cBoxCliente.SelectedIndex != -1)
            {
                dgvConsulta.DataSource = null; // Limpiamos solo dgvVenta
                int idClienteSeleccionada;

                if (int.TryParse(cBoxCliente.SelectedValue.ToString(), out idClienteSeleccionada))
                {
                    ConsultasCN consultaCN = new ConsultasCN();
                    DataSet ds = consultaCN.ConsultarPorCliente(idClienteSeleccionada);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvConsulta.DataSource = ds.Tables[0]; // Asignamos el DataSource a dgvVenta
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros para la venta seleccionada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El Cliente no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAlmacenCat_Click(object sender, EventArgs e)
        {
            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarCategoriasAlm();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void btnTiendaCat_Click(object sender, EventArgs e)
        {
            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarCategoriasTien();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = null;
            DateTime fechaInicio = dtpFInicio.Value;
            DateTime fechaFin = dtpFFin.Value;

            ConsultasCN consultaCN = new ConsultasCN();
            // Llamar al método para obtener las ventas
            DataSet ds = consultaCN.ConsultarPorFecha(fechaInicio, fechaFin);
            // Verifica que el DataSet contenga datos
            if (ds.Tables.Count > 0 && ds.Tables["Ventas"].Rows.Count > 0)
            {
                // Asignar el DataSet como fuente de datos del DataGridView
                dgvConsulta.DataSource = ds.Tables["Ventas"];
            }
            else
            {
                // Si no hay ventas, mostrar un mensaje
                dgvConsulta.DataSource = null;
                MessageBox.Show("No se encontraron ventas en el periodo especificado.");
            }
        }

        private void btnAlamacenPro_Click(object sender, EventArgs e)
        {
            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarProductosAlm();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void btnTiendaPro_Click(object sender, EventArgs e)
        {

            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarProductosTien();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarAsistencia();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {
            ConsultasCN consultaCN = new ConsultasCN();
            DataSet Data = consultaCN.ConsultarNomina();

            if (Data != null && Data.Tables.Count > 0)
            {

                dgvConsulta.DataSource = Data.Tables[0];
            }
            else
            {

                MessageBox.Show("No se encontraron categorías.");
            }
        }
    }
}
