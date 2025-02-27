using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using datos;
using negocio;

namespace presentacion
{
	public partial class CheckReserva : System.Web.UI.Page
	{
        NegocioReservas negocioReservas = new NegocioReservas();

        protected void Page_Load(object sender, EventArgs e)
		{
           
		}

        protected void CargarReservas(int codigo)
        {
            gvCheckReservas.DataSource = negocioReservas.ObtenerCheckReservas(codigo);
            gvCheckReservas.DataBind();
        }

        protected void btnCheckReserva_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            CargarReservas(codigo);
        }
    }
}