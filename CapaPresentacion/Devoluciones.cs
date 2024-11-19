using CapaEntidad;
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
    public partial class Devoluciones : Form
    {
        private DevolucionesCN DevolucionesCN = new DevolucionesCN();
        private Empleados_rhCN Empleados_rhCN = new Empleados_rhCN();
        private GestionPedidosCN GestionPedidosCN = new GestionPedidosCN();
        private ClientesCN ClientesCN = new ClientesCN();
        private DetallePedidosCN DetallePedidosCN = new DetallePedidosCN();

        private bool cargandoDatos;

        public Devoluciones()
        {
            InitializeComponent();
        }

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            cargandoDatos = true;
            CargarCbmEmpleados();
            CargarCbmPedidos();
            cargandoDatos = false;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtIdDevolucion.Text = DevolucionesCN.IDDevoluciones().ToString();

            groupBoxDevolucion.Enabled = true;
            groupBoxEmpleado.Enabled = true;
            groupBoxPedido.Enabled = true;
            nuevoToolStripMenuItem.Enabled = false;
            grabarToolStripMenuItem.Enabled = true;
        }

        private void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos && cmbEmpleados.SelectedValue != null)
            {
                int IDEmpleado = Convert.ToInt32(cmbEmpleados.SelectedValue);
                ActualizarEmpleadoTXT(IDEmpleado);
            }
        }

        private void CargarCbmEmpleados()
        {
            cmbEmpleados.DataSource = Empleados_rhCN.ConsultarEmpleados().Tables["CONS"];
            cmbEmpleados.DisplayMember = "nombre_empleado";
            cmbEmpleados.ValueMember = "IdEmpleado";
            cmbEmpleados.SelectedIndex = -1;
        }

        private void ActualizarEmpleadoTXT(int IDEmpleado)
        {
            Empleados_rh empleado = new Empleados_rh
            {
                IdEmpleado = IDEmpleado
            };

            DataSet ds = Empleados_rhCN.ConsultarEmpleadoPorId(empleado);

            if (ds.Tables["CONS"].Rows.Count > 0)
            {
                txtCargo.Text = ds.Tables["CONS"].Rows[0]["cargo"].ToString();
                txtTurno.Text = ds.Tables["CONS"].Rows[0]["turno"].ToString();
            }
        }

        private void cmbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoDatos && cmbPedidos.SelectedValue != null)
            {
                int IDPedido = Convert.ToInt32(cmbPedidos.SelectedValue);
                ActualizarPedidoTXT(IDPedido);                

                DetallePedidos detallePedido = new DetallePedidos
                {
                    IdPedido = Convert.ToInt32(cmbPedidos.SelectedValue)
                };

                // Consultar detalles de la compra seleccionada y mostrar en DataGridView
                dgvProductosPedido.DataSource = DetallePedidosCN.ConsultaDetallePedido(detallePedido).Tables["CONS"];
                CargarCmbProductosPedido();
                groupBoxDetalleDevolucion.Enabled = true;
                dgvProductosDevueltos.Rows.Clear();
            }
        }

        private void CargarCmbProductosPedido()
        {
            DetallePedidos detallePedido = new DetallePedidos
            {
                IdPedido = Convert.ToInt32(cmbPedidos.SelectedValue)
            };

            cmbProductosPedido.DataSource = DetallePedidosCN.ConsultaDetallePedido(detallePedido).Tables["CONS"];
            cmbProductosPedido.DisplayMember = "codigo";
            cmbProductosPedido.ValueMember = "codigo";
            cmbProductosPedido.SelectedIndex = -1;
        }

        private void CargarCbmPedidos()
        {
            cmbPedidos.DataSource = GestionPedidosCN.ConsultarPedidos().Tables["CONS"];
            cmbPedidos.DisplayMember = "idPedido";
            cmbPedidos.ValueMember = "idPedido";
            cmbPedidos.SelectedIndex = -1;
        }

        private void ActualizarPedidoTXT(int IDPedido)
        {
            GestionPedidos pedido = new GestionPedidos
            {
                IdPedido = IDPedido
            };

            DataSet ds = GestionPedidosCN.ConsultaPedidoPorId(pedido);

            if (ds.Tables["CONS"].Rows.Count > 0)
            {
                txtFecha.Text = ds.Tables["CONS"].Rows[0]["fecha"].ToString();
                ActualizarEmpleadoPedidoTXT(Convert.ToInt32(ds.Tables["CONS"].Rows[0]["idEmpleado"]));
                ActualizarClientePedidoTXT(Convert.ToInt32(ds.Tables["CONS"].Rows[0]["idCliente"]));
                txtEstado.Text = ds.Tables["CONS"].Rows[0]["estado"].ToString();
            }
        }

        private void ActualizarEmpleadoPedidoTXT(int IDEmpleado)
        {
            Empleados_rh empleado = new Empleados_rh
            {
                IdEmpleado = IDEmpleado
            };

            DataSet ds = Empleados_rhCN.ConsultarEmpleadoPorId(empleado);

            if (ds.Tables["CONS"].Rows.Count > 0)
            {
                txtEmpleadoP.Text = ds.Tables["CONS"].Rows[0]["nombre_empleado"].ToString();
                txtCargoP.Text = ds.Tables["CONS"].Rows[0]["cargo"].ToString();
                txtTurnoP.Text = ds.Tables["CONS"].Rows[0]["turno"].ToString();
                txtCorreoP.Text = ds.Tables["CONS"].Rows[0]["correo"].ToString();
                txtTelP.Text = ds.Tables["CONS"].Rows[0]["Tel"].ToString();
            }
        }

        private void ActualizarClientePedidoTXT(int IDCliente)
        {
            Clientes cliente = new Clientes
            {
                IdCliente = IDCliente
            };

            DataSet ds = ClientesCN.ConsultaClientesPorId(cliente);

            if (ds.Tables["CONS"].Rows.Count > 0)
            {
                txtCliente.Text = ds.Tables["CONS"].Rows[0]["Nombre"].ToString();
                txtDomicilio.Text = ds.Tables["CONS"].Rows[0]["Domicilio"].ToString();                
                txtCorreo.Text = ds.Tables["CONS"].Rows[0]["Correo"].ToString();
                txtTel.Text = ds.Tables["CONS"].Rows[0]["Tel"].ToString();
            }
        }

        private void AgregarProducto()
        {
            dgvProductosDevueltos.Rows.Add(txtIdDevolucion.Text, cmbProductosPedido.Text, txtCantidad.Text);
        }
        private bool ActualizarProductoSiExiste(string codigoProducto, int nuevaCantidad)
        {
            foreach (DataGridViewRow fila in dgvProductosDevueltos.Rows)
            {
                if (fila.Cells["codigo"].Value != null && fila.Cells["codigo"].Value.ToString() == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["cantidad"].Value);
                    fila.Cells["cantidad"].Value = cantidadActual + nuevaCantidad;
                    return true;
                }
            }
            return false;
        }


        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (!ActualizarProductoSiExiste(cmbProductosPedido.Text, Convert.ToInt32(txtCantidad.Text))) AgregarProducto();            
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable detallePedido = ObtenerDetallDevolucionDGV();

            DevolucionesE devolucion = new DevolucionesE
            {
                IdEmpleado = (int)cmbEmpleados.SelectedValue,
                IdPedido = (int)cmbPedidos.SelectedValue,
                Fecha = dtpFecha.Value.Date,
                Motivo = txtMotivo.Text,
            };

            try
            {
                string mensaje = DevolucionesCN.InsertarDevolucion(devolucion, detallePedido);
                MessageBox.Show(mensaje, "Resultado de la operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Resultado de la operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtIdDevolucion.Clear();
            txtMotivo.Clear();
            txtCargo.Clear();
            txtTurno.Clear();
            txtFecha.Clear();
            txtEstado.Clear();
            txtCliente.Clear();
            txtDomicilio.Clear();
            txtCorreo.Clear();
            txtTel.Clear();
            txtEmpleadoP.Clear();
            txtCargoP.Clear();
            txtTurnoP.Clear();
            txtCorreoP.Clear();
            txtTelP.Clear();
            cmbPedidos.SelectedIndex = -1;
            cmbEmpleados.SelectedIndex = -1;
            txtCantidad.Clear();
            cmbProductosPedido.SelectedIndex = -1;

            dgvProductosDevueltos.Rows.Clear();
            dgvProductosPedido.DataSource = null;

            groupBoxDevolucion.Enabled = false;
            groupBoxEmpleado.Enabled = false;
            groupBoxPedido.Enabled = false;
            groupBoxDetalleDevolucion.Enabled = false;

            nuevoToolStripMenuItem.Enabled = true;
            grabarToolStripMenuItem.Enabled = false;
        }

        private DataTable ObtenerDetallDevolucionDGV()
        {
            DataTable detalleDevolucion = new DataTable();

            // Crear las columnas con la misma estructura que en SQL Server
            detalleDevolucion.Columns.Add("idDevolucion", typeof(int));
            detalleDevolucion.Columns.Add("codigo", typeof(string));
            detalleDevolucion.Columns.Add("cantidad", typeof(int));            

            // Rellenar el DataTable con los datos del DataGridView
            foreach (DataGridViewRow row in dgvProductosDevueltos.Rows)
            {
                if (!row.IsNewRow)  // Evitar la fila nueva vacía del DGV
                {
                    DataRow dataRow = detalleDevolucion.NewRow();
                    dataRow["idDevolucion"] = Convert.ToInt32(row.Cells["idDevolucion"].Value);
                    dataRow["codigo"] = Convert.ToString(row.Cells["codigo"].Value);
                    dataRow["cantidad"] = Convert.ToInt32(row.Cells["cantidad"].Value);

                    detalleDevolucion.Rows.Add(dataRow);
                }
            }

            return detalleDevolucion;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
