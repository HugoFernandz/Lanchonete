<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaLoja01.Page.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <%--<table style="background-image: url(/Images/MarcaDagua.png); background-repeat: no-repeat; background-position: center; width: 100%;">--%>

    <asp:Table runat="server" ID="TableBusca" Visible="false">
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
                <asp:Label runat="server">Tipo Usuario: </asp:Label>
                <asp:DropDownList ID="ddlBTipoUsuario" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="Busca_Click" Text="Buscar"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="NovoCadastro_Click" Text="Novo Cadastro"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" ID="TableCadastro" Visible="false">
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
                <asp:Label runat="server">Tipo Usuario: </asp:Label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="Cadastro_Click" Text="Cadastrar"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="VoltarBuscar_Click" Text="Voltar"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" ID="TableAlterar" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label runat="server">Alterar Usuários</asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Nome: </asp:Label>
                <asp:TextBox runat="server" ID="txtANome"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">CPF: </asp:Label>
                <asp:TextBox runat="server" ID="txtACPF"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Contato: </asp:Label>
                <asp:TextBox runat="server" ID="txtAContato"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Email: </asp:Label>
                <asp:TextBox runat="server" ID="txtAEmail"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Tipo Usuario: </asp:Label>
                <asp:DropDownList ID="ddlATipoUsuario" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server">Status: </asp:Label>
                <asp:RadioButtonList ID="rblAStatus" runat="server">
                    <asp:ListItem Text="Inativo" Value="0" />
                    <asp:ListItem Text="Ativo" Value="1" />
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="Alterar_Click" Text="Alterar"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Button runat="server" OnClick="VoltarBuscar_Click" Text="Voltar"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" ID="GridRegistros" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="GridViewUsuarios" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewUsuarios_RowEditing"
                    CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="grid" HeaderStyle-BackColor="#D1D2D4" RowStyle-BackColor="#FFFFFF" runat="server" DataKeyNames="IdUsuario">
                    <Columns>
                        <%--                        <asp:TemplateField>
                            <ItemStyle Width="18px" CssClass="text-center" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("idStatus") %>' ID="labelStatus" Visible="false" />
                                <asp:Label runat="server" Text='<%# Eval("Removido") %>' ID="lblRemovido" Visible="false" />
                                <asp:Label runat="server" Text='<%# Eval("EnumEquivalente") %>' ID="lblenumerador" Visible="false" />
                                <asp:CheckBox ID="CheckBoxStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <%--                        <asp:TemplateField>
                            <ItemStyle CssClass="text-center" Width="18px" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                                <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" ToolTip="Status" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-ForeColor="#4C4C4C" SortExpression="status" />

                        <asp:CommandField ShowEditButton="True" ShowHeader="True" EditText="&lt;img src='../Images/edit-icon.png' title='Editar' alt='Editar' border=0&gt;">
                            <ItemStyle CssClass="text-center" />
                        </asp:CommandField>

                        <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-ForeColor="#4C4C4C" SortExpression="nome" />
                        <asp:BoundField DataField="Perfil" HeaderText="Perfil" HeaderStyle-ForeColor="#4C4C4C" SortExpression="perfil" />
                        <asp:BoundField DataField="CPF" HeaderText="CPF" HeaderStyle-ForeColor="#4C4C4C" SortExpression="cpf" />
                        <asp:BoundField DataField="Contato" HeaderText="Contato" HeaderStyle-ForeColor="#4C4C4C" SortExpression="contato" />
                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-ForeColor="#4C4C4C" SortExpression="email" />
                        <asp:BoundField DataField="Login" HeaderText="Login" HeaderStyle-ForeColor="#4C4C4C" SortExpression="login" />
                        <%--                        <asp:TemplateField HeaderText="Icone">
                            <ItemStyle Width="18px" CssClass="text-center" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("CaminhoIcone") %>' ID="lblcaminho" Visible="false" />
                                <asp:ImageButton ID="imgcaminho" runat="server" CausesValidation="false" ToolTip="Status" heigth="70px" Width="70px" OnClick="pagenewstatus_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
