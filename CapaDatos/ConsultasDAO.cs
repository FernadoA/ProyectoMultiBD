using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using Npgsql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConsultasDAO
    {
        Conexion objConecta = new Conexion();
        MySqlConnection conecMySQL;  
        SqlConnection conecSQL;       
        MySqlDataAdapter adaptadorMySQL;
        SqlDataAdapter adaptadorSQL;
        NpgsqlConnection conecPostgreSQL; 
        NpgsqlDataAdapter adaptadorPostgreSQL;
        public DataSet ConsultarClientes()
        {
            using (DataSet data = new DataSet())
            {
                conecSQL = objConecta.ConnectionSQLSBD();
                adaptadorSQL = new SqlDataAdapter("CONSULTACLIENTES", conecSQL);
                adaptadorSQL.Fill(data, "CONSCL");
                return data;
            }
        }
        public DataSet ConsultarCategoriasAlm()
        {
            using (DataSet data = new DataSet())
            {
                conecMySQL = objConecta.ConectaMySQL(); 
                adaptadorMySQL = new MySqlDataAdapter("CALL CONSULTACATEGORIAS", conecMySQL);
                adaptadorMySQL.Fill(data, "CONSCAT");
                return data;
            }
        }

        public DataSet ConsultarCategoriasTien()
        {
            using (DataSet data = new DataSet())
            {
                conecSQL = objConecta.ConnectionSQLSBD();
                adaptadorSQL = new SqlDataAdapter("CONSULTACATEGORIAS", conecSQL);
                adaptadorSQL.Fill(data, "CONSCAT");
                return data;
            }
        }
        public DataSet ConsultarProductosAlm()
        {
            using (DataSet data = new DataSet())
            {
                conecMySQL = objConecta.ConectaMySQL(); 
                adaptadorMySQL = new MySqlDataAdapter("CALL CONSULTAPRODUCTOS", conecMySQL);
                adaptadorMySQL.Fill(data, "CONSPR");
                return data;
            }
        }

        public DataSet ConsultarProductosTien()
        {
            using (DataSet data = new DataSet())
            {
                conecSQL = objConecta.ConnectionSQLSBD();
                adaptadorSQL = new SqlDataAdapter("CONSULTAPRODUCTOS", conecSQL);
                adaptadorSQL.Fill(data, "CONSPR");
                return data;
            }
        }
        public DataSet ConsultarAsistencia()
        {
            using (DataSet data = new DataSet())
            {
                conecPostgreSQL = objConecta.ConectaPG(); 
                adaptadorPostgreSQL = new NpgsqlDataAdapter("SELECT * FROM CONSULTAASISTENCIA();", conecPostgreSQL);
                adaptadorPostgreSQL.Fill(data, "CONSASIS");
                return data;
            }
        }
        public DataSet ConsultarNomina()
        {
            using (DataSet data = new DataSet())
            {
                conecPostgreSQL = objConecta.ConectaPG(); 
                adaptadorPostgreSQL = new NpgsqlDataAdapter("SELECT * FROM CONSULTANOMINA();", conecPostgreSQL);
                adaptadorPostgreSQL.Fill(data, "CONSNOM");
                return data;
            }
        }
        public DataSet ConsultarPorCliente(int idCliente)
        {
            DataSet data = new DataSet();

            using (SqlConnection conec = objConecta.ConnectionSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("MostrarVentaPorCliente", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCliente", idCliente);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(data, "Ventas");
                    }
                }
            }

            return data;
        }
        public DataSet ConsultarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet data = new DataSet();

            using (SqlConnection conec = objConecta.ConnectionSQLSBD())
            {
                using (SqlCommand cmd = new SqlCommand("MostrarVentaPorFecha", conec))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(data, "Ventas");
                    }
                }
            }

            return data;
        }
    }
}
