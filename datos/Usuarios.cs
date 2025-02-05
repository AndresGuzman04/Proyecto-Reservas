using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class Usuarios
    {
        private string conexion = "Data Source=ANDRES;Initial Catalog=db_reservas;Integrated Security=True;";

        public bool validarUsuario(string usuario, string contra) { 
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                using (SqlCommand consulta = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña", con)) {
                    consulta.Parameters.AddWithValue("@usuario", usuario);
                    consulta.Parameters.AddWithValue("@contraseña", contra);

                    int cont = (int)consulta.ExecuteScalar();
                    return cont > 0;
                }
            }
        }
    }
}
