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
        protected void Page_Load(object sender, EventArgs e)
        {
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
            int idUsuario = Convert.ToInt32(txtIdUsuario.Text);

            bool exito = negocioHabitaciones.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);

            if (exito)
            {
                Response.Write("<script>alert('Habitacion agregada con exito');</script>");
                CargarHabitaciones();
            }
            else {
                Response.Write("<script>alert('Error al agrgar la habitacion');</script>");
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
            if (e.RowIndex >= 0 && e.RowIndex < gvHabitaciones.DataKeys.Count)
            {
                int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);

                if (negocioHabitaciones.EliminarHabitacion(id))
                {
                    CargarHabitaciones();
                }
            }
            else
            {
                Response.Write("<script>alert('Error: Row index:"+ e.RowIndex + gvHabitaciones.DataKeys.Count + "');</script>");
            }

        }

        protected void gvHabitaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Botón de Editar
                LinkButton btnEdit = e.Row.Cells[0].Controls.OfType<LinkButton>().FirstOrDefault(b => b.CommandName == "Edit");
                if (btnEdit != null)
                {
                    btnEdit.CssClass = "btn btn-primary btn-sm"; // Botón azul pequeño
                    btnEdit.Text = "<i class='bi bi-pencil'></i> Editar"; // Ícono de lápiz
                }

                // Botón de Eliminar
                LinkButton btnDelete = e.Row.Cells[0].Controls.OfType<LinkButton>().FirstOrDefault(b => b.CommandName == "Delete");
                if (btnDelete != null)
                {
                    btnDelete.CssClass = "btn btn-danger btn-sm"; // Botón rojo pequeño
                    btnDelete.Text = "<i class='bi bi-trash'></i> Eliminar"; // Ícono de basura
                    btnDelete.OnClientClick = "return confirm('¿Estás seguro de que deseas eliminar esta habitación?');"; // Confirmación
                }

                // Si la fila está en modo de edición
                if (e.Row.RowState.HasFlag(DataControlRowState.Edit))
                {
                    // Botón de Actualizar
                    LinkButton btnUpdate = e.Row.Cells[0].Controls.OfType<LinkButton>().FirstOrDefault(b => b.CommandName == "Update");
                    if (btnUpdate != null)
                    {
                        btnUpdate.CssClass = "btn btn-success btn-sm"; // Botón verde pequeño
                        btnUpdate.Text = "<i class='bi bi-check-circle'></i> Actualizar"; // Ícono de check
                    }

                    // Botón de Cancelar
                    LinkButton btnCancel = e.Row.Cells[0].Controls.OfType<LinkButton>().FirstOrDefault(b => b.CommandName == "Cancel");
                    if (btnCancel != null)
                    {
                        btnCancel.CssClass = "btn btn-secondary btn-sm"; // Botón gris pequeño
                        btnCancel.Text = "<i class='bi bi-x-circle'></i> Cancelar"; // Ícono de cancelar
                    }
                }
            }
        }


    }
}