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
	public partial class Clientes : System.Web.UI.Page
	{
        NegocioCliente negocioClientes = new NegocioCliente();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }

            if (!IsPostBack)
            {
                CargarClientes();
            }
        }
        protected void CargarClientes()
        {
            gvClientes.DataSource = negocioClientes.ObtenerClientes();
            gvClientes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int dui = Convert.ToInt32(txtDui.Text);
            int telefono = Convert.ToInt32(txtTelefono.Text);
            string correo = txtCorreo.Text;
            string departamento = txtDepartamento.Text;
            DateTime fecha = DateTime.Now;
            int usuario = Convert.ToInt32(Session["Usuario"]);

           bool exito = negocioClientes.AgregarCliente(nombre, dui, telefono, correo, departamento, fecha, usuario);

            if (exito)
            {
                Response.Write("<script>alert('Cliente agregada con exito');</script>");
                CargarClientes();
            }
            else
            {
                Response.Write("<script>alert('Error al agrgar la Cliente');</script>");
            }
        }

        protected void gvClientes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            CargarClientes();
        }

        protected void gvClientes_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvClientes.Rows[e.RowIndex];

            string nombre = (row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            int dui = int.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int telefono = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string correo = (row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string departamento = (row.Cells[5].Controls[0] as System.Web.UI.WebControls.TextBox).Text;

            if (negocioClientes.ModificarCliente(id, nombre, dui, telefono, correo, departamento))
            {
                gvClientes.EditIndex = -1;
                CargarClientes();
            }
        }

        protected void gvClientes_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void gvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);

            if (negocioClientes.EliminarCliente(id))
            {
                CargarClientes();
            }
        }

    }
}