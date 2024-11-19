using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocios
{
    public class GestionPedidosCN
    {
        private GestionPedidosDAO pedidos = new GestionPedidosDAO();

        public DataSet ConsultarPedidos()
        {
            return pedidos.ConsultarPedidos();
        }

        public DataSet ConsultaPedidoPorId(GestionPedidos pedido)
        {
            return pedidos.ConsultaPedidoPorId(pedido);
        }
    }
}
