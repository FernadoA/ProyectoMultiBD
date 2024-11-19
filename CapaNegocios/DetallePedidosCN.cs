using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class DetallePedidosCN
    {
        private DetallePedidosDAO pedidos = new DetallePedidosDAO();

        public DataSet ConsultaDetallePedido(DetallePedidos pedido)
        {
            return pedidos.ConsultaDetallePedido(pedido);
        }
    }
}
