﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace datos
{
    public class Usuarios
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool validarUsuario(string usuario, string contra) { 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand consulta = new SqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña", con)) {
                    consulta.Parameters.AddWithValue("@usuario", usuario);
                    consulta.Parameters.AddWithValue("@contraseña", contra);

                    object result = consulta.ExecuteScalar();
                    int cont = (result != null ) ? Convert.ToInt32(result) : 0;
                    return cont > 0;
                }
            }
        }

        public DataTable ObtenerUsuarios() {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, usuario FROM usuarios", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}
