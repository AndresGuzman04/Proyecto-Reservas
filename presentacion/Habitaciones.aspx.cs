using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace presentacion
{
    public partial class Habitaciones : System.Web.UI.Page
    {
        NegocioHabitaciones negocioHabitaciones = new NegocioHabitaciones();
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) //si no hay sesion
            {
                Response.Redirect("index.aspx"); //lo mandamos al login
            }

            if (!IsPostBack) {
                CargarHabitaciones();
            }

        }


        protected void CargarHabitaciones() {
            gvHabitaciones.DataSource = negocioHabitaciones.ObtenerHabitaciones();
            gvHabitaciones.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtNumero.Text);
            string descripcion = txtDescripcion.Text;
            int huespedes = Convert.ToInt32(txtHuespedes.Text);
            int Usuario = Convert.ToInt32(Session["Usuario"]);

            bool exito = negocioHabitaciones.AgregarHabitacion(numero, descripcion, huespedes, Usuario);

            if (exito)
            {
                Response.Write("<script>alert('Cliente agregada con exito');</script>");
                CargarHabitaciones();
            }
            else {
                Response.Write("<script>alert('Error al agrgar la Cliente');</script>");
            }
        }

        protected void gvHabitaciones_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e) {
            gvHabitaciones.EditIndex = e.NewEditIndex;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e) {

            int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvHabitaciones.Rows[e.RowIndex];

            int numero = int.Parse((row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string descripcion = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            int huespedes = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int idUsuario = int.Parse((row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text);

            if (negocioHabitaciones.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario))
            {
                gvHabitaciones.EditIndex = -1;
                CargarHabitaciones();
            }
        }

        protected void gvHabitaciones_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e) {
            gvHabitaciones.EditIndex = -1;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) {
            int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);

            if (negocioHabitaciones.EliminarHabitacion(id))
            {
                CargarHabitaciones();
            }
        }


    }
}