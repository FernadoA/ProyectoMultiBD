using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Empleados_rhCN
    {
        private Empleados_rhDAO empleados = new Empleados_rhDAO();

        public DataSet ConsultarEmpleados()
        {
            return empleados.ConsultarEmpleados();
        }

        public DataSet ConsultarEmpleadoPorId(Empleados_rh empleado)
        {
            return empleados.ConsultarEmpleadoPorId(empleado);
        }
    }
}
