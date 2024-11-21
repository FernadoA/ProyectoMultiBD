using CapaEntidad;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class inicioSesion : Form
    {
        private UsuariosCN UsuariosCN = new UsuariosCN();

        public inicioSesion()
        {
            InitializeComponent();
        }

        private void iniciarSesion()
        {

            Usuarios usuario = new Usuarios
            {
                Nombre = txtNombre.Text,
                Contraseña = txtContraseña.Text,
            };

            if (UsuariosCN.ValidarUsuario(usuario, out string rol, out int? idusuario) == 1)
            {
                SesionActualCN.UsuarioActual = txtNombre.Text;
                SesionActualCN.RolActual = rol;
                SesionActualCN.IDUsuario = Convert.ToInt32(idusuario);

                MessageBox.Show("¡Bienvenido de nuevo, " + usuario.Nombre + "!",
                "Inicio de sesión exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El nombre de usuario o la contraseña no son correctos. Por favor, verifica e intenta nuevamente.",
                "Error al iniciar sesión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            }
        }

        private void cmdIniciarSesion_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }
    }
}
