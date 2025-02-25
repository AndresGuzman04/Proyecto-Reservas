using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;

namespace negocio
{
    public class NegocioUsuario
    {
        Usuarios dataUsuario = new Usuarios();

        public int iniciarSesion(string usuario, string contra) {
            if (dataUsuario.validarUsuario(usuario, contra))
            {
                int id = dataUsuario.ObtenerId(usuario, contra);
                return id;
            }
            else
            {
                return -1;
            }
        }

        public DataTable ObtenerUsuario() {
            return dataUsuario.ObtenerUsuarios();
        }
    }
}
