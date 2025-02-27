<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckReserva.aspx.cs" Inherits="presentacion.CheckReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CheckReserva</title>
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
          <a class="nav-link" href="Reservas.aspx">Reservas</a>
        <a class="nav-link active" href="CheckReserva.aspx">Check Reservas</a>
      </div>
    </div>
  </div>
</nav>

<div class="container ">    
    <form id="form1" class="needs-validation" runat="server">
        <div class="row">
            <div class="mb-3 col-md-12 row" >
                <h2>Check Reserva</h2>
                
                    <label class="form-label">Codigo Reserva:</label>
                    <asp:TextBox  class="form-control" ID="txtCodigo" runat="server"></asp:TextBox><br />

                <asp:Button class="btn btn-primary" ID="btnCheckReserva" runat="server" Text="Check Reserva" OnClick="btnCheckReserva_Click" />
            </div>

            <div class="mb-3 col-md-12">
                <h2>Lista de Reservas</h2>
                <asp:GridView class="table table-striped table-bordered" ID="gvCheckReservas" runat="server" AutoGenerateColumns="False"
                    GridLines="None">
                <Columns  >
                        <asp:BoundField DataField="id_reserva" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="Habitacion_Numero" HeaderText="Habitación Numero" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" />
                        <asp:BoundField DataField="descuento" HeaderText="Descuento" />
                        <asp:BoundField DataField="checkin" HeaderText="CheckIn" />
                        <asp:BoundField DataField="checkout" HeaderText="CheckOut" />

                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </form>
</div>
</body>
</html>
