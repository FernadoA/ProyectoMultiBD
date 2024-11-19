using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class DevolucionesCN
    {
        private DevolucionesDAO devoluciones = new DevolucionesDAO();

        public int IDDevoluciones()
        {
            return devoluciones.IDDevoluciones();
        }

        public string InsertarDevolucion(DevolucionesE devolucion, DataTable detalleDevolucion)
        {
            return devoluciones.InsertarDevolucion(devolucion, detalleDevolucion);
        }
    }
}
