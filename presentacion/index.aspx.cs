﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace presentacion
{
    public partial class index : System.Web.UI.Page
    {
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {

            string usuario = user.Text.Trim();
            string contra = password.Text.Trim();

            int resultado = negocioUsuario.iniciarSesion(usuario, contra);

            if (resultado == -1)
            {
                label1.Text = "Usuario o Contraseña incorrectos";
            }
            else
            {
                Session["Usuario"] = resultado;
                Response.Redirect("Habitaciones.aspx");
            }


        }
    }
}