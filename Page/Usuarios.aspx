<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaLoja01.Page.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <%--<table style="background-image: url(/Images/MarcaDagua.png); background-repeat: no-repeat; background-position: center; width: 100%;">--%>
        <asp:Table runat="server" ID="TableBusca">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label runat="server">Buscar Usuários</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Nome: </asp:Label>
                <asp:TextBox runat="server" ID="txtBNome"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Perfil: </asp:Label>
                <asp:DropDownList ID="ddlBPerfil" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="Busca_Click" Text="Buscar"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" ID="TableCadastro">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label runat="server">Cadastro Usuários</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Nome: </asp:Label>
                <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">CPF: </asp:Label>
                <asp:TextBox runat="server" ID="TxtCPF"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Contato: </asp:Label>
                <asp:TextBox runat="server" ID="txtContato"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Email: </asp:Label>
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Login: </asp:Label>
                <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Senha: </asp:Label>
                <asp:TextBox runat="server" ID="txtSenha"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Perfil: </asp:Label>
                <asp:DropDownList ID="ddlPerfil" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Status: </asp:Label>
                <asp:RadioButtonList ID="rblStatus" runat="server">
                    <asp:ListItem Text="Ativo" Value="1" />
                    <asp:ListItem Text="Inativo" Value="0" />
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="Cadastro_Click" Text="Cadastrar"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
