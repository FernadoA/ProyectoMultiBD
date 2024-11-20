using System;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class ReportesCN
    {
        private ReportesDAO reportes = new ReportesDAO();

        public DataSet PedidosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {

            // Llama al método de la capa de datos
            DataSet pedidos = reportes.PedidosPorFecha(fechaInicio, fechaFin);

            // Aplicar lógica adicional si se requiere
            if (pedidos != null && pedidos.Tables.Contains("Pedidos"))
            {
                DataTable pedidosTable = pedidos.Tables["Pedidos"];

                // Ejemplo: Validar que existan columnas para nombres
                if (!pedidosTable.Columns.Contains("NombreEmpleado") || !pedidosTable.Columns.Contains("NombreCliente"))
                {
                    throw new InvalidOperationException("Faltan columnas necesarias en los datos devueltos.");
                }
            }

            return pedidos;
        }
        public DataSet DevolucionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {

            // Llama al método de la capa de datos
            DataSet devoluciones = reportes.DevolucionesPorFecha(fechaInicio, fechaFin);

            // Aplicar lógica adicional si se requiere
            if (devoluciones != null && devoluciones.Tables.Contains("Devoluciones"))
            {
                DataTable pedidosTable = devoluciones.Tables["Devoluciones"];

                // Ejemplo: Validar que existan columnas para nombres
                if (!pedidosTable.Columns.Contains("NombreEmpleado"))
                {
                    throw new InvalidOperationException("Faltan columnas necesarias en los datos devueltos.");
                }
            }

            return devoluciones;
        }
    }
}
