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
    public class ClientesDAO
    {
        Conexion objConecta = new Conexion();

        SqlConnection conec;
        SqlDataAdapter adaptador;

        public DataSet ConsultaClientesPorId(Clientes cliente)
        {
            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaSQL();
                adaptador = new SqlDataAdapter("ConsultaClientesPorId", conec);
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = cliente.IdCliente;

                adaptador.Fill(data, "CONS");
                return data;
            }
        }
    }
}
