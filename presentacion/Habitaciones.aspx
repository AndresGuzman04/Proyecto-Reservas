<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Habitaciones.aspx.cs" Inherits="presentacion.Habitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Habitaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Dashboard Reservas</a>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div class="navbar-nav">
            <a class="nav-link active"  href="Habitaciones.aspx">Habitaciones</a>
            <a class="nav-link" href="Clientes.aspx">Clientes</a>
              <a class="nav-link " href="Reservas.aspx">Reservas</a>
              <a class="nav-link" href="CheckReserva.aspx">Check Reservas</a>
          </div>
        </div>
      </div>
    </nav>

    <div class="container ">    
        <form id="form1" class="needs-validation" runat="server">
            <div class="row">
                <div class="mb-3 col-md-3" >
                    <h2>Agregar Habitaciones</h2>
                    <label  class="form-label">Número:</label>
                    <asp:TextBox  class="form-control" ID="txtNumero" runat="server"></asp:TextBox><br />
                    <label class="form-label">Descripción:</label>
                    <asp:TextBox class="form-control" ID="txtDescripcion" runat="server"></asp:TextBox><br />
                    <label class="form-label">Huéspedes:</label>
                    <asp:TextBox class="form-control" ID="txtHuespedes" runat="server"></asp:TextBox><br />
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
                        GridLines="None" >
                    <Columns  >
                            <asp:BoundField DataField="id_habitaciones" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="numero" HeaderText="Número" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="huespedes" HeaderText="Huéspedes" />

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script>
        (function () {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        })()
    </script>
</body>
</html>
