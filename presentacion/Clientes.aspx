<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="presentacion.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Dashboard Reservas</a>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div class="navbar-nav">
            <a class="nav-link"  href="Habitaciones.aspx">Habitaciones</a>
            <a class="nav-link active" href="Clientes.aspx">Clientes</a>
              <a class="nav-link"  href="Reservas.aspx">Reservas</a>
              <a class="nav-link" href="CheckReserva.aspx">Check Reservas</a>
          </div>
        </div>
      </div>
    </nav>

    <div class="container ">    
    <form id="form1" class="needs-validation" runat="server">
        <div class="row">
            <div class="mb-3 col-md-3" >
                <h2>Agregar Clientes</h2>
                <label  class="form-label">Nombre:</label>
                <asp:TextBox  class="form-control" ID="txtNombre" runat="server"></asp:TextBox><br />
                <label class="form-label">DUI:</label>
                <asp:TextBox class="form-control" ID="txtDui" runat="server"></asp:TextBox><br />
                <label class="form-label">Telefono:</label>
                <asp:TextBox class="form-control" ID="txtTelefono" runat="server"></asp:TextBox><br />
                <label class="form-label">Correo:</label>
                <asp:TextBox class="form-control" ID="txtCorreo" runat="server"></asp:TextBox><br />
                <label class="form-label">Departamento:</label>
                <asp:TextBox class="form-control" ID="txtDepartamento" runat="server"></asp:TextBox><br />
                <asp:Button class="btn btn-primary" ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click" />
            </div>

            <div class="mb-3 col-md-9">
                <h2>Lista de Clientes</h2>
                <asp:GridView class="table table-striped table-bordered" ID="gvClientes" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="id_cliente"
                    OnRowEditing="gvClientes_RowEditing"
                    OnRowUpdating="gvClientes_RowUpdating"
                    OnRowCancelingEdit="gvClientes_RowCancelingEdit"
                    OnRowDeleting="gvClientes_RowDeleting"
                    GridLines="None">
                <Columns  >
                        <asp:BoundField DataField="id_cliente" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="dui" HeaderText="Dui" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="correo" HeaderText="Correo" />
                    <asp:BoundField DataField="departamento" HeaderText="Departamento" />

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
