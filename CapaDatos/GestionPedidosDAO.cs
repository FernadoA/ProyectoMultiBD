using CapaEntidad;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GestionPedidosDAO
    {
        Conexion objConecta = new Conexion();

        SqlConnection conec;
        SqlDataAdapter adaptador;

        public DataSet ConsultarPedidos()
        {
            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaSQLSBD();
                adaptador = new SqlDataAdapter("ConsultarPedidos", conec);
                adaptador.Fill(data, "CONS");
                return data;
            }
        }

        public DataSet ConsultaPedidoPorId(GestionPedidos pedido)
        {
            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaSQLSBD();
                adaptador = new SqlDataAdapter("ConsultaPedidoPorId", conec);
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = pedido.IdPedido;

                adaptador.Fill(data, "CONS");
                return data;
            }
        }
    }
}
