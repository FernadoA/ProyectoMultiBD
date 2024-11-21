using CapaEntidad;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuariosDAO
    {
        Conexion objConecta = new Conexion();
        SqlConnection conec;
        SqlDataAdapter adaptador;
        SqlCommand comando;

        public int ValidarUsuario(Usuarios usuario, out string rol, out int? idUsuario)
        {
            int resultado = 0;
            rol = string.Empty;


            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaSQLSBD();    

                adaptador = new SqlDataAdapter("ValidarUsuario", conec);
                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 45)).Value = usuario.Nombre;
                adaptador.SelectCommand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar, 5)).Value = usuario.Contraseña;

                // Parámetro de salida
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                adaptador.SelectCommand.Parameters.Add(resultadoParam);

                // Parámetro de salida para el rol
                SqlParameter rolParam = new SqlParameter("@Rol", SqlDbType.VarChar, 8);
                rolParam.Direction = ParameterDirection.Output;
                adaptador.SelectCommand.Parameters.Add(rolParam);

                // Parámetro de salida para el rol
                SqlParameter idParam = new SqlParameter("@IdUsuario", SqlDbType.Int);
                idParam.Direction = ParameterDirection.Output;
                adaptador.SelectCommand.Parameters.Add(idParam);

                conec.Open();
                adaptador.SelectCommand.ExecuteNonQuery();

                resultado = (int)adaptador.SelectCommand.Parameters["@Resultado"].Value;
                rol = adaptador.SelectCommand.Parameters["@Rol"].Value as string;
                idUsuario = adaptador.SelectCommand.Parameters["@IdUsuario"].Value as int?;

                // Devolver el mensaje de salida
                return resultado;
            }
        }
    }
}
