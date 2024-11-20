using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class PedidosCN
    {
        private PedidosDAO pedidosDAO = new PedidosDAO();

        public DataTable ConsultarClientesSQL()
        {
            return pedidosDAO.ConsultarClientesSQL();
        }

        public DataTable ConsultarClientePorID(int idCliente)
        {
            return pedidosDAO.ConsultarClientePorID(idCliente);
        }


        public int ObtenerSiguienteID(string tabla)
        {
            return pedidosDAO.ObtenerSiguienteID(tabla);
        }



        public DataTable ConsultarCategorias()
        {
            return pedidosDAO.ConsultarCategorias();
        }

        public DataTable ConsultarProductosConCategoriaMySQL()
        {
            return pedidosDAO.ConsultarProductosConCategoriaMySQL();
        }

        public DataTable ConsultarProductosPorCategoria(int idCategoria)
        {
            return pedidosDAO.ConsultarProductosPorCategoria(idCategoria);
        }

        public DataTable ConsultarProductoPorCodigo(String codigo)
        {
            return pedidosDAO.ConsultarProductoPorCodigo(codigo);
        }

        public DataTable ConsultarEmpleadosConAsistenciaPG()
        {
            return pedidosDAO.ConsultarEmpleadosConAsistenciaPG();
        }

        public DataTable ConsultarEmpleados()
        {
            return pedidosDAO.ConsultarEmpleados();
        }

        public DataTable ConsultarEmpleadoPorId(int idEmpleado)
        {
            return pedidosDAO.ConsultarEmpleadoPorId(idEmpleado);
        }


        public void InsertarPedido(int idEmpleado, int idCliente, DateTime fecha, string estado)
        {
            // Llama al método en la capa de datos
            pedidosDAO.InsertarPedido(idEmpleado, idCliente, fecha, estado);
        }


        public void InsertarDetallePedido(int idPedido, DataTable detallePedido)
        {
            // Llama al método en la capa de datos
            pedidosDAO.InsertarDetallePedido(idPedido, detallePedido);
        }



        public void ActualizarEstadoPorPedido(int idPedido)
        {
            // Paso 1: Obtener estado del pedido desde SQL Server
            var (idEmpleado, estadoPedido) = pedidosDAO.ObtenerEstadoPedido(idPedido);

            if (idEmpleado > 0 && !string.IsNullOrEmpty(estadoPedido))
            {
                // Paso 2: Actualizar estado del empleado en PostgreSQL
                pedidosDAO.ActualizarEstadoEmpleado(idEmpleado, estadoPedido);
            }
            else
            {
                throw new Exception("No se encontró información válida del pedido.");
            }
        }



        public void CambiarEstadoPedido(int idPedido, string nuevoEstado)
        {
            pedidosDAO.ActualizarEstadoPedido(idPedido, nuevoEstado);
        }



        public DataTable ObtenerPedidosPorCliente(int idCliente)
        {
            return pedidosDAO.ConsultarPedidosPorCliente(idCliente);
        }


    }
}
