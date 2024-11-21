using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class UsuariosCN
    {
        private UsuariosDAO usuarios = new UsuariosDAO();

        public int ValidarUsuario(Usuarios usuario, out string rol, out int? idusuario)
        {
            rol = string.Empty;

            return usuarios.ValidarUsuario(usuario, out rol, out idusuario);
        }
    }
}
