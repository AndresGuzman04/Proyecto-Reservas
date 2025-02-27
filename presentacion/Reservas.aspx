<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="presentacion.Reservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reservas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Dashboard Reservas</a>
    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
      <div class="navbar-nav">
        <a class="nav-link" href="Habitaciones.aspx">Habitaciones</a>
        <a class="nav-link" href="Clientes.aspx">Clientes</a>
        <a class="nav-link active"  href="Reservas.aspx">Reservas</a>
          <a class="nav-link" href="CheckReserva.aspx">Check Reservas</a>
      </div>
    </div>
  </div>
</nav>

<div class="container ">    
    <form id="form1" class="needs-validation" runat="server">
        <div class="row">
            <div class="mb-3 col-md-12 row" >
                <h2>Agregar Reservas</h2>
                
                <div class="mb-3 col-md-4">
                    <label class="form-label">Cliente:</label>
                    <asp:DropDownList class="form-control" ID="ddlCliente" runat="server" ></asp:DropDownList><br />
                </div>

                <div class="mb-3 col-md-4">
                    <label class="form-label">Huespedes cantidad:</label>
                    <asp:DropDownList ID="ddlHuespedesCantidad" runat="server" CssClass="form-control" 
                        AutoPostBack="true" OnSelectedIndexChanged="ddlHuespedesCantidad_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                    <asp:ListItem Text="2 huespedes $80.00 " Value="2"></asp:ListItem>
                    <asp:ListItem Text="4 huespedes $125.00 " Value="4"></asp:ListItem>
                </asp:DropDownList><br />
                    </div>
                
                <div class="mb-3 col-md-4">
                    <label class="form-label">Habitación:</label>
                    <asp:DropDownList class="form-control" ID="ddlHabitacion" runat="server" ></asp:DropDownList><br />
                </div>
               
                <div class="mb-3 col-md-4">
                    <label class="form-label">Descuento:</label>
                    <asp:DropDownList ID="ddlDescuento" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Sin descuento" Value="0"></asp:ListItem>
                    <asp:ListItem Text="10%" Value="0.10"></asp:ListItem>
                    <asp:ListItem Text="20%" Value="0.20"></asp:ListItem>
                </asp:DropDownList><br />
                </div>
                
                <div class="mb-3 col-md-4">
                    <label class="form-label">Checkin:</label>
                    <asp:TextBox class="form-control" ID="txtCheckin" runat="server" TextMode="Date"></asp:TextBox><br />
                </div>
                
                <div class="mb-3 col-md-4">
                    <label class="form-label">Checkout:</label>
                    <asp:TextBox class="form-control" ID="TxtCheckout" runat="server" 
                        TextMode="Date" AutoPostBack="true" OnTextChanged="ddl_SelectedforPrecio"></asp:TextBox>
                    <br />
                </div>

                <asp:Label ID="lblCheckout" runat="server" CssClass="form-label"></asp:Label><br />
   
                <asp:Button class="btn btn-primary" ID="btnAgregarReserva" runat="server" Text="Agregar Reserva" OnClick="btnAgregarReserva_Click" />
            </div>

            <div class="mb-3 col-md-12">
                <h2>Lista de Reservas</h2>
                <asp:GridView class="table table-striped table-bordered" ID="gvReservas" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="id_reserva"
                    OnRowEditing="gvReservas_RowEditing"
                    OnRowUpdating="gvReservas_RowUpdating"
                    OnRowCancelingEdit="gvReservas_RowCancelingEdit"
                    OnRowDeleting="gvReservas_RowDeleting"
                    GridLines="None">
                <Columns  >
                        <asp:BoundField DataField="id_reserva" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="Habitacion_Numero" HeaderText="Habitación Numero" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" />
                        <asp:BoundField DataField="descuento" HeaderText="Descuento" />
                        <asp:BoundField DataField="checkin" HeaderText="CheckIn" />
                        <asp:BoundField DataField="checkout" HeaderText="CheckOut" />

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
