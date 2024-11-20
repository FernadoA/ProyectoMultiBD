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
    public partial class Devolucionesxperiodo : Form
    {
        public Devolucionesxperiodo()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar el DataGridView antes de cargar nuevos datos
                dgvDevxFecha.DataSource = null;

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
                DataSet ds = reporteCN.DevolucionesPorFecha(fechaInicio, fechaFin);

                // Verificar que el DataSet contenga datos
                if (ds.Tables.Count > 0 && ds.Tables["Devoluciones"].Rows.Count > 0)
                {
                    // Obtener la tabla de pedidos
                    DataTable pedidosTable = ds.Tables["Devoluciones"];

                    // Reordenar las columnas según el orden requerido: IdPedido, nombreEmpleado, nombreCliente, Fecha, Estado
                    pedidosTable.DefaultView.Sort = "IdPedido ASC"; // Opcional: ordena los pedidos por IdPedido

                    // Asignar el DataSet como fuente de datos del DataGridView
                    dgvDevxFecha.DataSource = pedidosTable;

                    // Ocultar las columnas "idEmpleado" y "idCliente"
                    if (dgvDevxFecha.Columns.Contains("idEmpleado"))
                    {
                        dgvDevxFecha.Columns["idEmpleado"].Visible = false;
                    }

                    // Reordenar las columnas para mostrar los datos en el orden requerido
                    dgvDevxFecha.Columns["idDevolucion"].DisplayIndex = 0;
                    dgvDevxFecha.Columns["IdPedido"].DisplayIndex = 1;
                    dgvDevxFecha.Columns["NombreEmpleado"].DisplayIndex = 2;
                    dgvDevxFecha.Columns["Fecha"].DisplayIndex = 3;
                    dgvDevxFecha.Columns["Motivo"].DisplayIndex = 4;
                }
                else
                {
                    // Si no se encontraron pedidos, mostrar un mensaje y limpiar el DataGridView
                    dgvDevxFecha.DataSource = null;
                    MessageBox.Show("No se encontraron devoluciones en el periodo especificado.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
