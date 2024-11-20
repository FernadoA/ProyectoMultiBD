using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ReportesDAO
    {
        Conexion objConecta = new Conexion();
        MySqlConnection conecMySQL;
        SqlConnection conecSQL;
        MySqlDataAdapter adaptadorMySQL;
        SqlDataAdapter adaptadorSQL;
        NpgsqlConnection conecPostgreSQL;
        NpgsqlDataAdapter adaptadorPostgreSQL;

     
        public DataSet PedidosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet data = new DataSet();

            // Obtener los pedidos desde SQL Server
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("PedidosEntreFechas", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(data, "Pedidos");
                    }
                }
            }

            // Verificar si hay datos en la tabla "Pedidos"
            if (data.Tables["Pedidos"] != null)
            {
                DataTable pedidos = data.Tables["Pedidos"];

                // Agregar columnas para los nombres
                if (!pedidos.Columns.Contains("NombreEmpleado"))
                {
                    pedidos.Columns.Add("NombreEmpleado", typeof(string));
                }
                if (!pedidos.Columns.Contains("NombreCliente"))
                {
                    pedidos.Columns.Add("NombreCliente", typeof(string));
                }

                // Obtener los nombres de los empleados y clientes
                foreach (DataRow row in pedidos.Rows)
                {
                    // Obtener nombre del empleado desde PostgreSQL
                    int idEmpleado = Convert.ToInt32(row["idempleado"]);
                    string nombreEmpleado = ObtenerNombreEmpleado(idEmpleado);
                    row["NombreEmpleado"] = nombreEmpleado;

                    // Obtener nombre del cliente desde MySQL
                    int idCliente = Convert.ToInt32(row["idcliente"]);
                    string nombreCliente = ObtenerNombreCliente(idCliente);
                    row["NombreCliente"] = nombreCliente;
                }
            }

            return data;
        }
        public DataSet DevolucionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet data = new DataSet();

            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("DevolucionesEntreFechas", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(data, "Devoluciones");
                    }
                }
            }

            if (data.Tables["Devoluciones"] != null)
            {
                DataTable devoluciones = data.Tables["Devoluciones"];

                // Agregar columnas para los nombres
                if (!devoluciones.Columns.Contains("NombreEmpleado"))
                {
                    devoluciones.Columns.Add("NombreEmpleado", typeof(string));
                }
                // Obtener los nombres de los empleados
                foreach (DataRow row in devoluciones.Rows)
                {
                    // Obtener nombre del empleado desde PostgreSQL
                    int idEmpleado = Convert.ToInt32(row["idempleado"]);
                    string nombreEmpleado = ObtenerNombreEmpleado(idEmpleado);
                    row["NombreEmpleado"] = nombreEmpleado;

                }
            }

            return data;
        }

        private string ObtenerNombreEmpleado(int idEmpleado)
        {
            string nombreEmpleado = string.Empty;

            using (NpgsqlConnection conec = objConecta.ConectaPG())
            {
                string query = "SELECT nombre_empleado FROM empleados_rh WHERE idempleado = @Idempleado";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conec))
                {
                    cmd.Parameters.AddWithValue("@Idempleado", idEmpleado);

                    conec.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nombreEmpleado = result.ToString();
                    }
                }
            }

            return nombreEmpleado;
        }

        private string ObtenerNombreCliente(int idCliente)
        {
            string nombreCliente = string.Empty;

            using (SqlConnection conec = objConecta.ConnectionSQLSBD())
            {
                string query = "SELECT Nombre FROM clientes WHERE IDCliente = @IDCliente";
                using (SqlCommand cmd = new SqlCommand(query, conec))
                {
                    cmd.Parameters.AddWithValue("@IDCliente", idCliente);

                    conec.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        nombreCliente = result.ToString();
                    }
                }
            }

            return nombreCliente;
        }
    }
}
