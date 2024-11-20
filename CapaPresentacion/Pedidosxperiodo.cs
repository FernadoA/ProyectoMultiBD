using CapaNegocio;
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
    public partial class Pedidosxperiodo : Form
    {
        public Pedidosxperiodo()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar el DataGridView antes de cargar nuevos datos
                dgvPedidoxFecha.DataSource = null;

                // Obtener las fechas seleccionadas en los DateTimePicker
                DateTime fechaInicio = dtpFInicio.Value;
                DateTime fechaFin = dtpFFin.Value;

                // Validar que la fecha de inicio no sea mayor a la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Instanciar la capa de negocios para obtener los pedidos
                ReportesCN reporteCN = new ReportesCN();

                // Llamar al método de la capa de negocios para obtener los pedidos
                DataSet ds = reporteCN.PedidosPorFecha(fechaInicio, fechaFin);

                // Verificar que el DataSet contenga datos
                if (ds.Tables.Count > 0 && ds.Tables["Pedidos"].Rows.Count > 0)
                {
                    // Obtener la tabla de pedidos
                    DataTable pedidosTable = ds.Tables["Pedidos"];

                    // Reordenar las columnas según el orden requerido: IdPedido, nombreEmpleado, nombreCliente, Fecha, Estado
                    pedidosTable.DefaultView.Sort = "IdPedido ASC"; // Opcional: ordena los pedidos por IdPedido

                    // Asignar el DataSet como fuente de datos del DataGridView
                    dgvPedidoxFecha.DataSource = pedidosTable;

                    // Ocultar las columnas "idEmpleado" y "idCliente"
                    if (dgvPedidoxFecha.Columns.Contains("idEmpleado"))
                    {
                        dgvPedidoxFecha.Columns["idEmpleado"].Visible = false;
                    }
                    if (dgvPedidoxFecha.Columns.Contains("idCliente"))
                    {
                        dgvPedidoxFecha.Columns["idCliente"].Visible = false;
                    }

                    // Reordenar las columnas para mostrar los datos en el orden requerido
                    dgvPedidoxFecha.Columns["IdPedido"].DisplayIndex = 0;
                    dgvPedidoxFecha.Columns["NombreEmpleado"].DisplayIndex = 1;
                    dgvPedidoxFecha.Columns["NombreCliente"].DisplayIndex = 2;
                    dgvPedidoxFecha.Columns["Fecha"].DisplayIndex = 3;
                    dgvPedidoxFecha.Columns["Estado"].DisplayIndex = 4;
                }
                else
                {
                    // Si no se encontraron pedidos, mostrar un mensaje y limpiar el DataGridView
                    dgvPedidoxFecha.DataSource = null;
                    MessageBox.Show("No se encontraron pedidos en el periodo especificado.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                MessageBox.Show($"Ocurrió un error al procesar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
