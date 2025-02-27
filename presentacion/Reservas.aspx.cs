using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using datos;
using negocio;

namespace presentacion
{
	public partial class Reservas : System.Web.UI.Page
	{
        NegocioReservas negocioReservas = new NegocioReservas();

		protected void Page_Load(object sender, EventArgs e)
		{

            if (!IsPostBack)
            {
                CargarReservas();
                CargarClientes();
                CargarHabitaciones(tipoHabitacion());
            }
        }

        protected int tipoHabitacion()
        {
            int cliente = 0;
            if (int.TryParse(ddlHuespedesCantidad.SelectedValue, out cliente) && cliente > 0)
            {
                return cliente;
            }
            return 2; // Valor predeterminado en caso de error
        }

        protected void CargarHabitaciones(int cantidad)
        {
            ddlHabitacion.DataSource = negocioReservas.ObtenerHabitacionPorHuespedes(cantidad);
            ddlHabitacion.DataTextField = "numero";
            ddlHabitacion.DataValueField = "id_habitaciones";
            ddlHabitacion.DataBind();
        }

        protected void ddlHuespedesCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHabitaciones(tipoHabitacion());
        }

        protected void ddl_SelectedforPrecio(object sender, EventArgs e) {
            double descuento = Convert.ToDouble(ddlDescuento.SelectedValue);
            DateTime checkIn = Convert.ToDateTime(txtCheckin.Text);
            DateTime checkOut = Convert.ToDateTime(TxtCheckout.Text);

            double precio = CalcularPrecio(checkOut, checkIn, descuento);

            lblCheckout.Text = "Total: $" + precio.ToString("N2");
        }

        protected void CargarClientes() { 
            ddlCliente.DataSource = negocioReservas.ObtenerClientes();
            ddlCliente.DataTextField = "nombre";
            ddlCliente.DataValueField = "id_cliente";
            ddlCliente.DataBind();
        }

     
        protected void CargarReservas()
        {
            gvReservas.DataSource = negocioReservas.ObtenerReservas();
            gvReservas.DataBind();
        }

        protected double CalcularPrecio(DateTime checkOut, DateTime checkIn, double descuento) {

            // Calcular la diferencia en días
            int diasEstadia = (checkOut - checkIn).Days;

            // Verificar que la fecha de salida no sea menor a la de entrada
            if (diasEstadia < 1)
            {
                diasEstadia = 1; // Mínimo 1 día de estadía
            }

            int tipoEstadia = Convert.ToInt32(ddlHuespedesCantidad.SelectedValue);
            double precio = 0;

            if (tipoEstadia == 2)
            {
                precio = diasEstadia * (80 - (80 * descuento));
            }
            if (tipoEstadia == 4)
            {
                precio = diasEstadia * (125 - (125 * descuento));
            }

            return precio;

        }
        protected void btnAgregarReserva_Click(object sender, EventArgs e)
        {
            int idReserva = Convert.ToInt32(DateTime.Now.ToString("MMddHHmmss"));

            int cliente = Convert.ToInt32(ddlCliente.SelectedValue);
            int habitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
            double descuento = Convert.ToDouble(ddlDescuento.SelectedValue);
            DateTime checkIn = Convert.ToDateTime(txtCheckin.Text);
            DateTime checkOut = Convert.ToDateTime(TxtCheckout.Text);
            DateTime fecha_registro = DateTime.Now;
            int usuario = Convert.ToInt32(Session["Usuario"]);

            double precio = CalcularPrecio(checkOut, checkIn, descuento);

            bool exito = negocioReservas.AgregarReserva(idReserva, cliente, habitacion, precio, descuento, checkIn, checkOut, fecha_registro, usuario);

            if (exito)
            {
                Response.Write("<script>alert('Reserva agregada con exito');</script>");
                CargarReservas();
            }
            else
            {
                Response.Write("<script>alert('Error al agrgar la Reserva');</script>");
            }
        }

        protected void gvReservas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvReservas.EditIndex = e.NewEditIndex;
            CargarReservas();
        }

        protected void gvReservas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            int id = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvReservas.Rows[e.RowIndex];

            int cliente = int.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int habitacion = int.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            double precio = int.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            double descuento = double.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            DateTime checkIn = DateTime.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            DateTime checkOut = DateTime.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);


            if (negocioReservas.ModificarReserva(id, cliente, habitacion, precio, descuento, checkIn, checkOut))
            {
                gvReservas.EditIndex = -1;
                CargarReservas();
            }
        }

        protected void gvReservas_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvReservas.EditIndex = -1;
            CargarReservas();
        }

        protected void gvReservas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Value);

            if (negocioReservas.EliminarReserva(id))
            {
                CargarReservas();
            }
        }
    }
}