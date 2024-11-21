using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Contraseña;
        private string _Rol;

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }
    }
}
