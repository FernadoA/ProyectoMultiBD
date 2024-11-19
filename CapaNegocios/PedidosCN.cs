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

    }
}
