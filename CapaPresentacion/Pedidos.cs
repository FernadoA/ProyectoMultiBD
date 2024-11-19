using CapaNegocios;
using MySqlX.XDevAPI;
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
    public partial class Pedidos : Form
    {
        private PedidosCN pedidosCN = new PedidosCN();
        
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ConfigurarDataGridView();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable cliente = pedidosCN.ConsultarClientesSQL();


                cmbNombreCliente.SelectedIndexChanged -= cmbNombreCliente_SelectedIndexChanged;

                cmbNombreCliente.DataSource = null;
                cmbNombreCliente.Items.Clear();
                cmbNombreCliente.Items.Add(""); // Opción vacía
                cmbNombreCliente.DataSource = cliente;
                cmbNombreCliente.DisplayMember = "Nombre"; // Propiedad para mostrar
                cmbNombreCliente.ValueMember = "IDCliente"; // Propiedad para el valor

                cmbNombreCliente.SelectedIndexChanged += cmbNombreCliente_SelectedIndexChanged;

                cmbNombreCliente.Enabled = cliente.Rows.Count > 0;

                modificarToolStripMenuItem.Enabled = cliente.Rows.Count > 0;




                DataTable producto = pedidosCN.ConsultarCategorias();


                cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;

                cmbCategoria.DataSource = null;
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add(""); // Opción vacía
                cmbCategoria.DataSource = producto;
                cmbCategoria.DisplayMember = "concepto"; // Propiedad para mostrar
                cmbCategoria.ValueMember = "idCategoria"; // Propiedad para el valor

                cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

                cmbCategoria.Enabled = producto.Rows.Count > 0;




                DataTable empleado = pedidosCN.ConsultarEmpleados();


                cmbEmpleado.SelectedIndexChanged -= cmbEmpleado_SelectedIndexChanged;

                cmbEmpleado.DataSource = null;
                cmbEmpleado.Items.Clear();
                cmbEmpleado.Items.Add(""); // Opción vacía
                cmbEmpleado.DataSource = empleado;
                cmbEmpleado.DisplayMember = "nombre_empleado"; // Propiedad para mostrar
                cmbEmpleado.ValueMember = "IdEmpleado"; // Propiedad para el valor

                cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;

                cmbEmpleado.Enabled = empleado.Rows.Count > 0;



                cmbEstado.Items.Add("Pendiente");
                cmbEstado.Items.Add("Completado");
                cmbEstado.Items.Add("Devuelto");
                cmbEstado.Items.Add("Cancelado");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void cmbNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNombreCliente.SelectedIndex >= 0)
                {
                    // Obtiene el ID de la empresa seleccionado
                    int idCliente = (int)cmbNombreCliente.SelectedValue;

                    // Consulta los datos de la empresa usando el ID
                    DataTable dtViveros = pedidosCN.ConsultarClientePorID(idCliente);

                    if (dtViveros.Rows.Count > 0)
                    {
                        DataRow row = dtViveros.Rows[0];
                        txtIdCliente.Text = row["IDCliente"].ToString();
                        txtDomicilio.Text = row["Domicilio"].ToString();
                        txtCorreo.Text = row["Correo"].ToString();
                        txtTelefono.Text = row["Tel"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtIdPedido.Text = GenerarNuevoId();

            cmbNombreCliente.Enabled = true;
            cmbCategoria.Enabled = true;
            cmbNombre.Enabled = true;
            cmbEstado.Enabled = true;
            cmbEmpleado.Enabled = true;
            txtCantidad.Enabled = true;
        }

        private string GenerarNuevoId()
        {
            int id;
            try
            {
                id = pedidosCN.ObtenerSiguienteID("gestionPedidos");

                if (id == 0)
                {
                    // Si el id es 0, lanzamos una excepción con un mensaje explicativo.
                    return "1";
                }
            }
            catch (Exception e)
            {
                // Aquí puedes registrar el error o mostrar un mensaje.
                // Por ejemplo, mostrar el error en un MessageBox:
                MessageBox.Show("Error al generar el nuevo ID: " + e.Message);

                // O también podrías registrar el error en un archivo de log:
                // Log.Error("Error al generar el ID: " + e.Message);

                return "1"; // O podrías devolver un valor predeterminado si lo prefieres.
            }

            return id.ToString();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategoria.SelectedIndex >= 0)
                {
                    // Obtiene el ID de la empresa seleccionado
                    int idCategoria = (int)cmbCategoria.SelectedValue;

                    // Consulta los datos de la empresa usando el ID
                    DataTable dtProductos = pedidosCN.ConsultarProductosPorCategoria(idCategoria);


                    cmbNombre.SelectedIndexChanged -= cmbNombre_SelectedIndexChanged;

                    cmbNombre.DataSource = null;
                    cmbNombre.Items.Clear();
                    cmbNombre.Items.Add(""); // Opción vacía
                    cmbNombre.DataSource = dtProductos;
                    cmbNombre.DisplayMember = "Nombre"; // Propiedad para mostrar
                    cmbNombre.ValueMember = "codigo"; // Propiedad para el valor

                    cmbNombre.SelectedIndexChanged += cmbNombre_SelectedIndexChanged;

                    cmbNombre.Enabled = dtProductos.Rows.Count > 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbNombre.SelectedIndex >= 0)
                {
                    // Obtiene el ID de la empresa seleccionado
                    String codigo = cmbNombre.SelectedValue.ToString();

                    // Consulta los datos de la empresa usando el ID
                    DataTable dtProducto = pedidosCN.ConsultarProductoPorCodigo(codigo);

                    if (dtProducto.Rows.Count > 0)
                    {
                        DataRow row = dtProducto.Rows[0];
                        txtCodigo.Text = row["codigo"].ToString();
                        txtPrecio.Text = Convert.ToDecimal(row["precio"]).ToString("F2");
                        txtExistencias.Text = row["existencias"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpleado.SelectedIndex >= 0)
                {
                    // Obtiene el ID de la empresa seleccionado
                    int idEmpleado = (int)cmbEmpleado.SelectedValue;

                    // Consulta los datos de la empresa usando el ID
                    DataTable dtEmpleado = pedidosCN.ConsultarEmpleadoPorId(idEmpleado);

                    if (dtEmpleado.Rows.Count > 0)
                    {
                        DataRow row = dtEmpleado.Rows[0];
                        txtIdEmpleado.Text = row["IdEmpleado"].ToString();
                        txtCargo.Text = row["cargo"].ToString();
                        txtCorreoE.Text = row["correo"].ToString();
                        txtTelefonoE.Text = row["Tel"].ToString();
                        txtTurno.Text = row["turno"].ToString();
                        txtEstadoE.Text = row["estado"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            dgvDetallePedido.Rows.Add(txtIdPedido.Text, txtCodigo.Text, cmbCategoria.Text, cmbNombre.Text, txtPrecio.Text, txtExistencias.Text);

            cmbCategoria.SelectedIndex = -1;
            txtCodigo.Clear();
            cmbNombre.SelectedIndex = -1;
            txtPrecio.Clear();
            cmbCategoria.SelectedIndex = -1;
            txtExistencias.Clear();
            txtCantidad.Clear();
        }

        private void ConfigurarDataGridView()
        {
            dgvDetallePedido.Columns.Add("idPedido", "ID Pedido");
            dgvDetallePedido.Columns.Add("codigo", "Código");
            dgvDetallePedido.Columns.Add("concepto", "Concepto");
            dgvDetallePedido.Columns.Add("nombre", "Nombre");
            dgvDetallePedido.Columns.Add("precio", "Precio");
            dgvDetallePedido.Columns.Add("existencias", "Existencias");
        }



        // Método para rellenar el DataTable a partir del DataGridView  
        private DataTable ObtenerDetallePedidoDGV()
        {
            DataTable detallePedido = new DataTable();

            // Crear las columnas con la misma estructura que en SQL Server  
            detallePedido.Columns.Add("idPedido", typeof(int));
            detallePedido.Columns.Add("codigo", typeof(string));
            detallePedido.Columns.Add("concepto", typeof(string));
            detallePedido.Columns.Add("nombre", typeof(string));
            detallePedido.Columns.Add("precio", typeof(decimal));
            detallePedido.Columns.Add("existencias", typeof(int));


            // Rellenar el DataTable con los datos del DataGridView  
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                if (!row.IsNewRow)  // Evitar la fila nueva vacía del DGV  
                {
                    DataRow dataRow = detallePedido.NewRow();
                    dataRow["idPedido"] = Convert.ToInt32(row.Cells["idPedido"].Value);
                    dataRow["codigo"] = row.Cells["codigo"].Value;
                    dataRow["cantidad"] = Convert.ToInt32(row.Cells["cantidad"].Value);

                    detallePedido.Rows.Add(dataRow);
                }
            }

            return detallePedido;
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos del formulario de pedido estén completos
                if (!string.IsNullOrWhiteSpace(txtIdEmpleado.Text) &&
                    !string.IsNullOrWhiteSpace(txtIdCliente.Text) &&
                    !string.IsNullOrWhiteSpace(cmbEstado.Text) &&
                    dgvDetallePedido.Rows.Count > 0)
                {
                    // Crear el objeto del pedido principal
                    Pedido pedido = new Pedido
                    {
                        IdEmpleado = int.Parse(txtIdEmpleado.Text),
                        IdCliente = int.Parse(txtIdCliente.Text),
                        Fecha = DateTime.Now, // Puedes usar un DateTimePicker para elegir la fecha
                        Estado = cmbEstado.Text
                    };

                    // Insertar el pedido principal y obtener el ID generado
                    int idPedido = pedidosCN.InsertarPedido(pedido);


                    // Obtener el detalle del pedido desde el DataGridView
                    DataTable detallePedido = ObtenerDetallePedidoDGV();

                    // Insertar el detalle del pedido
                    pedidosCN.InsertarDetallePedido(detallePedido);

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Pedido y detalle del pedido guardados con éxito.");

                    // Limpiar formulario
                    LimpiarFormulario();

                }
                else
                {
                    MessageBox.Show("Asegúrate de completar todos los campos del pedido y agregar al menos un producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
    }
}
