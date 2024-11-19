using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using Npgsql;

namespace CapaDatos
{
    public class PedidosDAO
    {
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
                using (SqlConnection conec = objConecta.ConectaSQL())
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
                conec = objConecta.ConectaSQL();
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
            int siguienteID = 0;  // Valor por defecto para cuando no se obtenga un ID válido.

            // Conexión a la base de datos Mantenimiento para obtener el siguiente ID
            using (SqlConnection conec = objConecta.ConectaSQL())
            {
                using (SqlCommand command = new SqlCommand("ObtenerSiguienteID", conec))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Tabla", tabla);

                    try
                    {
                        conec.Open();

                        // Ejecutar el procedimiento almacenado y obtener el siguiente ID
                        object result = command.ExecuteScalar();  // Ejecutamos el procedimiento y obtenemos el valor devuelto

                        // Si el resultado no es null, asignamos el siguienteID
                        if (result != null)
                        {
                            siguienteID = Convert.ToInt32(result);  // Convertir el valor a entero
                        }
                        else
                        {
                            // Si no se obtiene un valor, asignamos 0 o el valor adecuado
                            siguienteID = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar el error si ocurre algún problema con la ejecución
                        Console.WriteLine("Error al obtener el siguiente ID: " + ex.Message);
                        siguienteID = 0;  // Asignar valor 0 si ocurre un error
                    }
                }
            }

            return siguienteID;  // Devuelve el siguiente ID
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

    }
}
