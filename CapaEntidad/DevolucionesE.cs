using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DevolucionesE
    {
        private int _IdDevolucion;
        private int _IdEmpleado;
        private int _IdPedido;
        private DateTime _Fecha;
        private string _Motivo;

        public int IdDevolucion
        {
            get { return _IdDevolucion; }
            set { _IdDevolucion = value; }
        }

        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Motivo
        {
            get { return _Motivo; }
            set { _Motivo = value; }
        }
    }
}
