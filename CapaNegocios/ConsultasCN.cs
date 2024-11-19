using System;
using CapaDatos;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ConsultasCN
    {
        private ConsultasDAO consultas = new ConsultasDAO();
        public DataSet ConsultaClientes()
        {
            return consultas.ConsultarClientes();
        }
        public DataSet ConsultarCategoriasAlm()
        {
            return consultas.ConsultarCategoriasAlm();
        }
        public DataSet ConsultarCategoriasTien()
        {
            return consultas.ConsultarCategoriasTien();
        }
        public DataSet ConsultarProductosAlm()
        {
            return consultas.ConsultarProductosAlm();
        }
        public DataSet ConsultarProductosTien()
        {
            return consultas.ConsultarProductosTien();
        }
        public DataSet ConsultarAsistencia()
        {
            return consultas.ConsultarAsistencia();
        }
        public DataSet ConsultarNomina()
        {
            return consultas.ConsultarNomina();
        }


        public DataSet ConsultarPorCliente(int idCliente)
        {
            return consultas.ConsultarPorCliente(idCliente);
        }
        public DataSet ConsultarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return consultas.ConsultarPorFecha(fechaInicio, fechaFin);
        }
    }
}
