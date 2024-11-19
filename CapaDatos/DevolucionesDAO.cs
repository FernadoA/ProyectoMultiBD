using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class DevolucionesDAO
    {
        Conexion objConecta = new Conexion();

        SqlConnection conec;
        SqlDataAdapter adaptador;

        public int IDDevoluciones()
        {
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("ContarDevoluciones", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idParameter);

                    conec.Open();
                    cmd.ExecuteNonQuery();
                    
                    return Convert.ToInt32(idParameter.Value);
                }
            }
        }

        public string InsertarDevolucion(DevolucionesE devolucion, DataTable detalleDevolucion)
        {
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarDevolucion", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada              
                    cmd.Parameters.Add(new SqlParameter("@idEmpleado", SqlDbType.Int)).Value = devolucion.IdEmpleado;
                    cmd.Parameters.Add(new SqlParameter("@idPedido", SqlDbType.Int)).Value = devolucion.IdPedido;                    
                    cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date)).Value = devolucion.Fecha;
                    cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar,255)).Value = devolucion.Motivo;


                    // Añadir el parámetro para el DataTable
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@DDV", detalleDevolucion);
                    tvpParam.SqlDbType = SqlDbType.Structured; // Especificar que es un parámetro de tipo tabla
                    tvpParam.TypeName = "DetalleDevolucion";

                    // Parámetro de salida
                    SqlParameter mensajeParam = new SqlParameter("@Message", SqlDbType.VarChar, 100);
                    mensajeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParam);

                    conec.Open();
                    cmd.ExecuteNonQuery();

                    // Devolver el mensaje de salida
                    return mensajeParam.Value.ToString();
                }
            }
        }

    }
}
