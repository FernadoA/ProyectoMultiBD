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
    public class ClientesCN
    {
        private ClientesDAO clientes = new ClientesDAO();

        public DataSet ConsultaClientesPorId(Clientes cliente)
        {
            return clientes.ConsultaClientesPorId(cliente);
        }
    }
}
