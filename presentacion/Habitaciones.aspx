<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Habitaciones.aspx.cs" Inherits="presentacion.Habitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Agregar Habitaciones</h2>
            Número:<asp:TextBox ID="txtNumero" runat="server"></asp:TextBox><br />
            Descripción:<asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox><br />
            Huéspedes:<asp:TextBox ID="txtHespedes" runat="server"></asp:TextBox><br />
            ID Usuario:<asp:TextBox ID="txtIdUsuario" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Habitación" OnClick="btnAgregar_Click" />
        </div>
        <div>
            <h2>Lista de Habitaciones</h2>
            <asp:GridView ID="gvHabitaciones" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id_habitaciones" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="numero" HeaderText="Numero"></asp:BoundField>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripci&#243;n"></asp:BoundField>
                    <asp:BoundField DataField="huespedes" HeaderText="Huespedes"></asp:BoundField>
                    <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario"></asp:BoundField>
                    <asp:CommandField ShowEditButton="True"></asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
