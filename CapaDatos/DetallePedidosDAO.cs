using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class DetallePedidosDAO
    {
        Conexion objConecta = new Conexion();

        SqlConnection conec;
        SqlDataAdapter adaptador;        

        public DataSet ConsultaDetallePedido(DetallePedidos detallePedido)
        {
            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaSQLSBD();
                adaptador = new SqlDataAdapter("ConsultaDetallePedidoPorID", conec);

                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = detallePedido.IdPedido;

                adaptador.Fill(data, "CONS");
                return data;
            }
        }
    }
}
