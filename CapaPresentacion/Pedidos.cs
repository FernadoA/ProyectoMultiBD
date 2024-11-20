using CapaEntidad;
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
        
        public bool modFlag = false;

        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            limpiarCampos();
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




                DataTable empleado = pedidosCN.ConsultarEmpleados();


                cmbEmpleado.SelectedIndexChanged -= cmbEmpleado_SelectedIndexChanged;

                cmbEmpleado.DataSource = null;
                cmbEmpleado.Items.Clear();
                cmbEmpleado.Items.Add(""); // Opción vacía
                cmbEmpleado.DataSource = empleado;
                cmbEmpleado.DisplayMember = "nombre_empleado"; // Propiedad para mostrar
                cmbEmpleado.ValueMember = "IdEmpleado"; // Propiedad para el valor

                cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;


                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("Pendiente");
                cmbEstado.Items.Add("Completado");
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
                    DataTable dtClientes = pedidosCN.ConsultarClientePorID(idCliente);

                    if (dtClientes.Rows.Count > 0)
                    {
                        DataRow row = dtClientes.Rows[0];
                        txtIdCliente.Text = row["IDCliente"].ToString();
                        txtDomicilio.Text = row["Domicilio"].ToString();
                        txtCorreo.Text = row["Correo"].ToString();
                        txtTelefono.Text = row["Tel"].ToString();

                    }

                    if (modFlag)
                    {
                        DataTable pedidos = pedidosCN.ObtenerPedidosPorCliente(idCliente);

                        if (pedidos.Rows.Count > 0)
                        {
                            // Mostrar los pedidos en un control como DataGridView
                            dgvPedidos.DataSource = pedidos;


                            cmbSelectPedido.SelectedIndexChanged -= cmbSelectPedido_SelectedIndexChanged;

                            cmbSelectPedido.DataSource = null;
                            cmbSelectPedido.Items.Clear();
                            cmbSelectPedido.Items.Add(""); // Opción vacía
                            cmbSelectPedido.DataSource = pedidos;
                            cmbSelectPedido.DisplayMember = "idPedido"; // Propiedad para mostrar
                            cmbSelectPedido.ValueMember = "idPedido"; // Propiedad para el valor

                            cmbSelectPedido.SelectedIndexChanged += cmbSelectPedido_SelectedIndexChanged;


                        }
                        else
                        {
                            MessageBox.Show("No se encontraron pedidos para este cliente.");
                        }

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
            cmbEstado.Enabled = true;
            cmbEmpleado.Enabled = true;
            txtCantidad.Enabled = true;

            cmdAgregar.Enabled = true;

            grabarToolStripMenuItem.Enabled = true;
            modificarToolStripMenuItem.Enabled = false;
            nuevoToolStripMenuItem.Enabled = false;
        }

        private string GenerarNuevoId()
        {
            try
            {
                int id = pedidosCN.ObtenerSiguienteID("gestionPedidos");
                return id.ToString();
            }
            catch (Exception e)
            {
                // Manejo de error
                MessageBox.Show("Error al generar el nuevo ID: " + e.Message);
                return "1"; // Valor predeterminado
            }
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


                    cmbProducto.SelectedIndexChanged -= cmbNombre_SelectedIndexChanged;

                    cmbProducto.DataSource = null;
                    cmbProducto.Items.Clear();
                    cmbProducto.Items.Add(""); // Opción vacía
                    cmbProducto.DataSource = dtProductos;
                    cmbProducto.DisplayMember = "Nombre"; // Propiedad para mostrar
                    cmbProducto.ValueMember = "codigo"; // Propiedad para el valor

                    cmbProducto.SelectedIndexChanged += cmbNombre_SelectedIndexChanged;

                    cmbProducto.Enabled = dtProductos.Rows.Count > 0;

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
                if (cmbProducto.SelectedIndex >= 0)
                {
                    // Obtiene el ID de la empresa seleccionado
                    String codigo = cmbProducto.SelectedValue.ToString();

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
            dgvDetallePedido.Rows.Add(txtIdPedido.Text, txtCodigo.Text, cmbCategoria.Text, cmbProducto.Text, txtPrecio.Text, txtCantidad.Text, txtExistencias.Text);

            cmbCategoria.SelectedIndex = -1;
            txtCodigo.Clear();
            cmbProducto.SelectedIndex = -1;
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
            dgvDetallePedido.Columns.Add("cantidad", "Cantidad");
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
            detallePedido.Columns.Add("cantidad", typeof(int));
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
                if (!modFlag)
                {
                    // Validar que los campos del formulario de pedido estén completos
                    if (!string.IsNullOrWhiteSpace(txtIdEmpleado.Text) &&
                        !string.IsNullOrWhiteSpace(txtIdCliente.Text) &&
                        !string.IsNullOrWhiteSpace(cmbEstado.Text) &&
                        dgvDetallePedido.Rows.Count > 0)
                    {

                        // Crear el pedido principal
                        int idEmpleado = int.Parse(txtIdEmpleado.Text);
                        int idCliente = int.Parse(txtIdCliente.Text);
                        string estado = cmbEstado.Text;
                        DateTime fecha = DateTime.Now;

                        // Insertar el pedido principal
                        pedidosCN.InsertarPedido(idEmpleado, idCliente, fecha, estado);

                        // Crear un DataTable con el detalle del pedido desde el DataGridView
                        DataTable detallePedido = ObtenerDetallePedidoDGV();

                        // Insertar el detalle del pedido
                        int idPedido = int.Parse(txtIdPedido.Text); // Si tienes lógica para recuperar el último ID
                        pedidosCN.InsertarDetallePedido(idPedido, detallePedido);

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Pedido y detalle del pedido guardados con éxito.");


                        pedidosCN.ActualizarEstadoPorPedido(idPedido);

                        CargarDatos();

                        // Limpiar formulario
                        limpiarCampos();
                        dgvDetallePedido.Rows.Clear();
                        
                        deshabilita();
                        cmbEstado.Enabled = false;

                        nuevoToolStripMenuItem.Enabled = true;
                        modificarToolStripMenuItem.Enabled = true;
                        grabarToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Asegúrate de completar todos los campos del pedido y agregar al menos un producto.");
                    }


                }
                else
                {
                    pedidosCN.CambiarEstadoPedido(int.Parse(cmbSelectPedido.Text), cmbEstado.Text);

                    pedidosCN.ActualizarEstadoPorPedido(int.Parse(cmbSelectPedido.Text));

                    CargarDatos();

                    limpiarCampos();
                    dgvPedidos.DataSource = null;

                    deshabilita();

                    lblSelec.Visible = false;
                    cmbSelectPedido.Visible = false;

                    cmbEstado.Enabled = false;
                    cmbSelectPedido.SelectedIndex = -1;

                    nuevoToolStripMenuItem.Enabled = true;
                    modificarToolStripMenuItem.Enabled = true;
                    grabarToolStripMenuItem.Enabled = false;


                    modFlag = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }

        public void limpiarCampos()
        {
            txtIdCliente.Text = string.Empty;
            cmbNombreCliente.SelectedIndex = -1;
            txtDomicilio.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;

            txtIdPedido.Text = string.Empty;
            cmbCategoria.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            txtCodigo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;

            txtIdEmpleado.Text = string.Empty;
            cmbEmpleado.SelectedIndex = -1;
            txtCargo.Text = string.Empty;
            txtCorreoE.Text = string.Empty;
            txtTelefonoE.Text = string.Empty;
            txtTurno.Text = string.Empty;
            txtEstadoE.Text = string.Empty;
        }

        public void deshabilita()
        {
            cmbNombreCliente.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbProducto.Enabled = false;
            cmbEmpleado.Enabled = false;
            cmbSelectPedido.Enabled = false;

            txtCantidad.Enabled = false;

            cmdAgregar.Enabled = false;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modFlag = true;
            
            lblSelec.Visible = true;
            cmbSelectPedido.Visible = true;

            deshabilita();

            cmbNombreCliente.Enabled = true;

            cmbSelectPedido.Enabled = true;
            cmbEstado.Enabled = true;

            grabarToolStripMenuItem.Enabled = true;
            nuevoToolStripMenuItem.Enabled = false;
            modificarToolStripMenuItem.Enabled = false;

        }

        private void cmbSelectPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
