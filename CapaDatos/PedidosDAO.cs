using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using Npgsql;

namespace CapaDatos
{
    public class PedidosDAO
    {
        // SQL Server 
        private Conexion objConecta = new Conexion();
        private SqlConnection conec;
        private SqlDataAdapter adaptador;
        private SqlCommand comando;

        // MYSQL
        private Conexion objConectaMYSQL = new Conexion();
        private MySqlConnection conecMYSQL;
        private MySqlDataAdapter adaptadorMYSQL;
        private MySqlCommand comandoMYSQL;

        // PostgreSQL
        private Conexion objConectaPG = new Conexion();
        private NpgsqlConnection conecPG;
        private NpgsqlDataAdapter adaptadorPG;
        private NpgsqlCommand comandoPG;

        public DataTable ConsultarClientesSQL()
        {
            using (DataTable dtClientes = new DataTable())
            {
                using (SqlConnection conec = objConecta.ConnectionSQLSBD())
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter("ConsultarClientes", conec))
                    {
                        adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adaptador.Fill(dtClientes);
                        return dtClientes;
                    }
                }
            }
        }

        public DataTable ConsultarClientePorID(int idCliente)
        {
            using (DataTable dtClientes = new DataTable())
            {
                conec = objConecta.ConnectionSQLSBD();
                adaptador = new SqlDataAdapter("ConsultarClientePorID", conec);
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros @IdVivero y @Usuario
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@IDCliente", SqlDbType.Int)).Value = idCliente;

                adaptador.Fill(dtClientes);
                return dtClientes;
            }
        }




        public int ObtenerSiguienteID(string tabla)
        {
            int siguienteID = 0;  // Valor predeterminado.

            // Conexión a la base de datos
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand command = new SqlCommand("ObtenerSiguienteID", conec))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Tabla", tabla);

                    try
                    {
                        conec.Open();

                        // Ejecutar el procedimiento almacenado y obtener el siguiente ID
                        object result = command.ExecuteScalar();

                        // Convertir el resultado solo si no es nulo
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            siguienteID = id;
                        }
                        else
                        {
                            siguienteID = 1; // En caso de que no haya resultado, iniciar en 1.
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar el error
                        Console.WriteLine("Error al obtener el siguiente ID: " + ex.Message);
                        siguienteID = 1; // Valor predeterminado en caso de error
                    }
                }
            }

            return siguienteID;
        }



        public DataTable ConsultarCategorias()
        {
            using (DataTable dtProductos = new DataTable())
            {
                using (MySqlConnection conecMYSQL = objConectaMYSQL.ConectaMySQL())
                {
                    using (MySqlDataAdapter adaptadorMYSQL = new MySqlDataAdapter("ConsultarCategorias", conecMYSQL))
                    {
                        adaptadorMYSQL.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adaptadorMYSQL.Fill(dtProductos);
                        return dtProductos;
                    }
                }
            }
        }


        public DataTable ConsultarProductosPorCategoria(int idCategoria)
        {
            using (DataTable dtProductos = new DataTable())
            {
                // Conectar a la base de datos MySQL
                conecMYSQL = objConectaMYSQL.ConectaMySQL();

                // Usar MySqlDataAdapter para MySQL
                MySqlDataAdapter adaptadorMYSQL = new MySqlDataAdapter("ConsultarProductosPorCategoria", conecMYSQL);
                adaptadorMYSQL.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro @idCategoria
                adaptadorMYSQL.SelectCommand.Parameters.Add(new MySqlParameter("@p_idCategoria", MySqlDbType.Int32)).Value = idCategoria;

                // Llenar el DataTable con los resultados
                adaptadorMYSQL.Fill(dtProductos);

                return dtProductos;
            }
        }


        public DataTable ConsultarProductoPorCodigo(String codigo)
        {
            using (DataTable dtProductos = new DataTable())
            {
                // Conectar a la base de datos MySQL
                conecMYSQL = objConectaMYSQL.ConectaMySQL();

                // Usar MySqlDataAdapter para MySQL
                MySqlDataAdapter adaptadorMYSQL = new MySqlDataAdapter("ConsultarProductoPorCodigo", conecMYSQL);
                adaptadorMYSQL.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro @idCategoria
                adaptadorMYSQL.SelectCommand.Parameters.Add(new MySqlParameter("@p_codigo", MySqlDbType.VarChar, 100)).Value = codigo;

                // Llenar el DataTable con los resultados
                adaptadorMYSQL.Fill(dtProductos);

                return dtProductos;
            }
        }



        public DataTable ConsultarProductosConCategoriaMySQL()
        {
            using (DataTable dtProductos = new DataTable())
            {
                using (MySqlConnection conecMYSQL = objConectaMYSQL.ConectaMySQL())
                {
                    using (MySqlDataAdapter adaptadorMYSQL = new MySqlDataAdapter("ConsultarProductosConCategoria", conecMYSQL))
                    {
                        adaptadorMYSQL.SelectCommand.CommandType = CommandType.StoredProcedure;

                        adaptadorMYSQL.Fill(dtProductos);
                        return dtProductos;
                    }
                }
            }
        }




        public DataTable ConsultarEmpleadosConAsistenciaPG()
        {
            using (DataTable dtEmpleados = new DataTable())
            {
                using (NpgsqlConnection conec = objConecta.ConectaPG())
                {
                    using (NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM ConsultarEmpleadosConAsistencia()", conec))
                    {
                        conec.Open();

                        using (NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando))
                        {
                            adaptador.Fill(dtEmpleados);
                            return dtEmpleados;
                        }
                    }
                }
            }
        }




        public DataTable ConsultarEmpleados()
        {
            using (DataTable dtEmpleados = new DataTable())
            {
                // Conectar a la base de datos PostgreSQL
                using (NpgsqlConnection conecPG = objConectaPG.ConectaPG()) // Usar PostgreSQL
                {
                    // Crear una consulta para llamar a la función ConsultarEmpleados
                    string query = "SELECT * FROM ConsultaEmpleados();"; // Llamada a la función ConsultarEmpleados

                    using (NpgsqlDataAdapter adaptadorPG = new NpgsqlDataAdapter(query, conecPG))
                    {
                        adaptadorPG.Fill(dtEmpleados); // Llenar el DataTable con los resultados
                        return dtEmpleados;
                    }
                }
            }
        }





        public DataTable ConsultarEmpleadoPorId(int idEmpleado)
        {
            using (DataTable dtEmpleado = new DataTable())
            {
                // Conectar a la base de datos PostgreSQL
                using (NpgsqlConnection conecPG = objConectaPG.ConectaPG()) // Usar PostgreSQL
                {
                    // Crear una consulta para llamar a la función ConsultarEmpleadoPorId, pasando el parámetro
                    string query = "SELECT * FROM ConsultaEmpleadoPorId(@p_IdEmpleado);";

                    using (NpgsqlDataAdapter adaptadorPG = new NpgsqlDataAdapter(query, conecPG))
                    {
                        // Agregar el parámetro @p_IdEmpleado
                        adaptadorPG.SelectCommand.Parameters.Add(new NpgsqlParameter("@p_IdEmpleado", NpgsqlTypes.NpgsqlDbType.Integer)).Value = idEmpleado;

                        adaptadorPG.Fill(dtEmpleado); // Llenar el DataTable con los resultados
                        return dtEmpleado;
                    }
                }
            }
        }



        public void InsertarPedido(int idEmpleado, int idCliente, DateTime fecha, string estado)
        {
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand comando = new SqlCommand("InsertarPedido", conec))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    comando.Parameters.Add(new SqlParameter("@idEmpleado", SqlDbType.Int)).Value = idEmpleado;
                    comando.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int)).Value = idCliente;
                    comando.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                    comando.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar, 50)).Value = estado;

                    // Abrir conexión y ejecutar
                    conec.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }



        public void InsertarDetallePedido(int idPedido, DataTable detallePedido)
        {
            // Primero, insertamos el detalle del pedido en SQL Server
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand comando = new SqlCommand("InsertarDetallePedido", conec))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetros predefinidos para la inserción del detalle
                    comando.Parameters.Add(new SqlParameter("@idPedido", SqlDbType.Int));
                    comando.Parameters.Add(new SqlParameter("@codigo", SqlDbType.VarChar, 16));
                    comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

                    // Abrir la conexión a SQL Server
                    conec.Open();

                    // Insertar cada fila del detalle
                    foreach (DataRow row in detallePedido.Rows)
                    {
                        comando.Parameters["@idPedido"].Value = idPedido;
                        comando.Parameters["@codigo"].Value = row["codigo"];
                        comando.Parameters["@cantidad"].Value = row["cantidad"];

                        comando.ExecuteNonQuery();
                    }
                }
            }

            // Ahora, actualizamos las existencias en MySQL
            using (MySqlConnection conecMYSQL = objConectaMYSQL.ConectaMySQL())
            {
                string query = "UPDATE productos SET existencias = existencias - @cantidad WHERE codigo = @codigo";

                using (MySqlCommand comandoMYSQL = new MySqlCommand(query, conecMYSQL))
                {
                    comandoMYSQL.Parameters.AddWithValue("@codigo", "");
                    comandoMYSQL.Parameters.AddWithValue("@cantidad", 0);

                    // Abrir la conexión a MySQL
                    conecMYSQL.Open();

                    // Actualizar las existencias en MySQL para cada fila del detalle
                    foreach (DataRow row in detallePedido.Rows)
                    {
                        comandoMYSQL.Parameters["@codigo"].Value = row["codigo"];
                        comandoMYSQL.Parameters["@cantidad"].Value = row["cantidad"];

                        comandoMYSQL.ExecuteNonQuery();
                    }
                }
            }
        }






        public (int, string) ObtenerEstadoPedido(int idPedido)
        {
            int idEmpleado = 0;
            string estadoPedido = "";

            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand comando = new SqlCommand("ObtenerEstadoPedido", conec))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idPedido", idPedido);

                    // Parámetros de salida
                    var paramIdEmpleado = new SqlParameter("@idEmpleado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var paramEstadoPedido = new SqlParameter("@estadoPedido", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    comando.Parameters.Add(paramIdEmpleado);
                    comando.Parameters.Add(paramEstadoPedido);

                    conec.Open();
                    comando.ExecuteNonQuery();

                    // Recuperar valores de salida
                    idEmpleado = paramIdEmpleado.Value != DBNull.Value ? Convert.ToInt32(paramIdEmpleado.Value) : 0;
                    estadoPedido = paramEstadoPedido.Value != DBNull.Value ? paramEstadoPedido.Value.ToString() : "";
                }
            }

            return (idEmpleado, estadoPedido);
        }




        public void ActualizarEstadoEmpleado(int idEmpleado, string estadoPedido)
        {
            using (NpgsqlConnection conecPG = objConectaPG.ConectaPG())
            {
                string query = "SELECT ActualizarEstadoEmpleado(@p_IdEmpleado, @p_EstadoPedido);";

                using (NpgsqlCommand comandoPG = new NpgsqlCommand(query, conecPG))
                {
                    comandoPG.Parameters.AddWithValue("@p_IdEmpleado", idEmpleado);
                    comandoPG.Parameters.AddWithValue("@p_EstadoPedido", estadoPedido);

                    conecPG.Open();
                    comandoPG.ExecuteNonQuery();
                }
            }
        }



        public void ActualizarEstadoPedido(int idPedido, string nuevoEstado)
        {
            using (SqlConnection conec = objConecta.ConectaSQLSBD())
            {
                using (SqlCommand comando = new SqlCommand("ActualizarEstadoPedido", conec))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    comando.Parameters.AddWithValue("@idPedido", idPedido);
                    comando.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);

                    conec.Open();
                    comando.ExecuteNonQuery(); // Ejecutar el procedimiento
                }
            }
        }



        public DataTable ConsultarPedidosPorCliente(int idCliente)
        {
            using (DataTable dtPedidos = new DataTable())
            {
                using (SqlConnection conec = objConecta.ConectaSQLSBD())
                {
                    using (SqlCommand comando = new SqlCommand("ConsultarPedidosPorCliente", conec))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Agregar el parámetro del procedimiento almacenado
                        comando.Parameters.AddWithValue("@idCliente", idCliente);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dtPedidos); // Llenar el DataTable con los resultados
                        }
                    }
                }
                return dtPedidos;
            }
        }


    }
}
