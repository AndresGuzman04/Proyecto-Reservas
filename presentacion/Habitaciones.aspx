<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Habitaciones.aspx.cs" Inherits="presentacion.Habitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Habitaciones</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" />
</head>
<body>
    <nav class="navbar navbar-light bg-light">
      <div class="container-fluid">
        <span class="navbar-brand mb-0 h1">Dashboard Reservas</span>
      </div>
    </nav>
    <div class="container ">    
        <form id="form1" runat="server">
            <div class="row">
                <div class="mb-3 col-md-3" >
                    <h2>Agregar Habitaciones</h2>
                    <label class="form-label">Número:</label>
                    <asp:TextBox class="form-control" ID="txtNumero" runat="server"></asp:TextBox><br />
                    <label class="form-label">Descripción:</label>
                    <asp:TextBox class="form-control" ID="txtDescripcion" runat="server"></asp:TextBox><br />
                    <label class="form-label">Huéspedes:</label>
                    <asp:TextBox class="form-control" ID="txtHuespedes" runat="server"></asp:TextBox><br />
                    <label class="form-label">Descripción:</label>
                    <asp:TextBox class="form-control" ID="txtIdUsuario" runat="server"></asp:TextBox><br />
                    <asp:Button class="btn btn-primary" ID="btnAgregar" runat="server" Text="Agregar Habitación" OnClick="btnAgregar_Click" />
                </div>

                <div class="mb-3 col-md-9">
                    <h2>Lista de Habitaciones</h2>
                    <asp:GridView class="table table-striped table-bordered" ID="gvHabitaciones" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="id_habitaciones"
                        OnRowEditing="gvHabitaciones_RowEditing"
                        OnRowUpdating="gvHabitaciones_RowUpdating"
                        OnRowCancelingEdit="gvHabitaciones_RowCancelingEdit"
                        OnRowDeleting="gvHabitaciones_RowDeleting"
                        OnRowDataBound="gvHabitaciones_RowDataBound"
                        GridLines="None">
                    <Columns  >
                            <asp:BoundField DataField="id_habitaciones" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="numero" HeaderText="Número" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="huespedes" HeaderText="Huéspedes" />
                            <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" />

                        <asp:CommandField ShowEditButton="True">
                            <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True">
                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                        </asp:CommandField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </form>
    </div>
</body>
</html>
