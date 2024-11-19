using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class Empleados_rhDAO
    {
        Conexion objConecta = new Conexion();

        NpgsqlConnection conec;
        NpgsqlDataAdapter adaptador;

        public DataSet ConsultarEmpleados()
        {
            using (var conec = objConecta.ConectaPG()) 
            {
                using (var adaptador = new NpgsqlDataAdapter("SELECT * FROM ConsultaEmpleados();", conec))
                {
                    DataSet data = new DataSet();
                    adaptador.Fill(data, "CONS");
                    return data;  
                }
            }
        }

        public DataSet ConsultarEmpleadoPorId(Empleados_rh empleado)
        {
            using (DataSet data = new DataSet())
            {
                conec = objConecta.ConectaPG();                
                using (NpgsqlCommand comando = new NpgsqlCommand("SELECT * FROM ConsultaEmpleadoPorId(@IdEmpleado);", conec))
                {                    
                    comando.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);                    
                    adaptador = new NpgsqlDataAdapter(comando);
                    
                    adaptador.Fill(data, "CONS");
                }
                
                return data;
            }
        }

    }
}
