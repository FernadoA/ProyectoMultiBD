using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;

namespace CapaDatos
{
    public class Conexion
    {
        // Método para conexión a SQL Server
        public SqlConnection ConnectionSQLSBD()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSQL"].ConnectionString);
            return connection;
        }
        public SqlConnection ConectaSQLSBD()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSQLSBD"].ConnectionString);
            return connection;
        }

        // Método para conexión a MySQL
        public MySqlConnection ConectaMySQL()
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionMYSQL"].ConnectionString);
            return connection;
        }

        // Método para conexión a PostgreSQL
        public NpgsqlConnection ConectaPG()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConnectionPG"].ConnectionString);
            return connection;
        }
    }
}
