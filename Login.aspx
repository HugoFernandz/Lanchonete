<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaLoja01.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/bootstrap.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="width: fit-content; padding: 200px" class="container-fluid">
            <div class="card border-secondary mb-3" style="max-width: 20rem;">
                <div class="card-header">LOGIN</div>
                <div class="card-body">
                    <div class="form-group">
                        <label class="form-label mt-4">Usuário: </label>
                        <input type="text" class="form-control" id="txtlogin" placeholder="Login Usuário" runat="server" />
                    </div>
                    <div class="form-group">
                        <label class="form-label mt-4">Senha: </label>
                        <input type="password" class="form-control" id="txtsenha" placeholder="Senha Usuário" runat="server" />
                    </div>
                    <div class="form-group">
                        <br />
                        <asp:Button runat="server" ID="Button1" Text="Entrar" OnClick="btnlogin_Click" />
                    </div>
                </div>
            </div>
        </div>

        <%--        <div style="margin-top: 200px; margin-left: 100px">
            <p>Login</p>
            <br />
            <div>
                <asp:Label runat="server" ID="lblusuario"> Usuario: </asp:Label><br />
                <asp:TextBox runat="server" ID="txtusuario"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="lblsenha">Senha: </asp:Label><br />
                <asp:TextBox runat="server" ID="TextBox1" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <br />
                
            </div>
            <div>
                <asp:Label runat="server" ID="lblmensagem"></asp:Label>
            </div>
        </div>--%>
    </form>

    <%--    <div style="width: fit-content; padding: 200px" class="container-fluid">
        <div class="card border-secondary mb-3" style="max-width: 20rem;">
            <div class="card-header">LOGIN</div>
            <div class="card-body">
                <div class="form-group">
                    <label class="form-label mt-4">Usuário: </label>
                    <input type="text" class="form-control" id="txtlogin" placeholder="Login Usuário" runat="server" />
                </div>
                <div class="form-group">
                    <label class="form-label mt-4">Senha: </label>
                    <input type="password" class="form-control" id="txtsenha" placeholder="Senha Usuário" runat="server" />
                </div>
                <div class="form-group">
    <asp:Button runat="server" ID="Button1" Text="ENTRAR" OnClick="btnlogin_Click"/>
                </div>
            </div>
        </div>
    </div>
    <asp:Button runat="server" ID="btnlogin" Text="Entrar" OnClick="btnlogin_Click" />--%>
</body>
</html>
