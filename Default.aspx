<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaLoja01.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <body>
        <nav>
            <ul class="menu">
                <li><a href="#">Administrativo</a>
                    <ul>
                        <li><a href="../Page/Usuarios.aspx">Usuarios Sistema</a></li>
                        <li><a href="../Page/Pessoas.aspx">Cadastro Pessoas</a></li>
                        <li><a href="../Page/Produtos.aspx">Cadastro Produtos</a></li>
                    </ul>
                </li>
                <li><a href="../Page/Servicos.aspx">Servicos</a></li>
                <li><a href="../Page/Historico.aspx">Historico</a></li>
                <li><a href="../Page/Financeiro.aspx">Financeiro</a></li>
            </ul>
        </nav>
    </body>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p class="testecss">teste default</p>
</asp:Content>
