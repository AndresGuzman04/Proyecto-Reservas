<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="presentacion.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <section class="vh-100 d-flex justify-content-center align-items-center" 
          style="background-image: url('https://img.freepik.com/free-vector/night-ocean-landscape-full-moon-stars-shine_107791-7397.jpg?t=st=1738125300~exp=1738128900~hmac=f7c9f2ee4364da682d530d6908b8994224b1e3dcd286bba2764e48047b98bead&w=1060'); background-size: cover; background-position: center;">
  
          <div class="card p-5 text-center shadow-2-strong" style="border-radius: 1rem; width: 400px; background: rgba(255, 255, 255, 0.8);">
            <h3 class="mb-4">Sign in</h3>
    
            <div class="form-outline mb-3">
                <asp:TextBox ID="user" placeholder="User" class="form-control form-control-lg" runat="server"></asp:TextBox>
            </div>

            <div class="form-outline mb-3">
                <asp:TextBox ID="password" placeholder="Password" class="form-control  form-control-lg" runat="server"></asp:TextBox>
            </div>
              <asp:Button ID="login" class="btn btn-primary btn-lg w-100" runat="server" Text="Login" OnClick="login_Click" />
              <asp:Label ID="label1" runat="server" Text=""></asp:Label>         
            </div>
          </section>


    </form>
</body>
</html>
