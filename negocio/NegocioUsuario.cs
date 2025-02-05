using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;

namespace negocio
{
    public class NegocioUsuario
    {
        Usuarios dataUsuario = new Usuarios();

        public string iniciarSesion(string usuario, string contra) {
            if (dataUsuario.validarUsuario (usuario, contra))
            {
                return "OK";
            }
            else
            {
                return "Usuario o contraseña incorrectos " + usuario + " " + contra;
            }
        }
    }
}
