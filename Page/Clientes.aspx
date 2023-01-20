<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SistemaLoja01.Page.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <br />
    <h1>Clientes</h1>

    <div class="alert alert-dismissible alert-success" runat="server" visible="false" id="msgCadastroSucesso">
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        <strong>
            <label runat="server" id="txtsucesso" visible="false"></label>
        </strong>
    </div>

    <div class="alert alert-dismissible alert-warning" runat="server" visible="false" id="msgCadastroErro">
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        <strong>
            <label runat="server" id="txterro" visible="false"></label>
        </strong>
        Revise as informações e tente novamente.
    </div>

    <div style="width: fit-content;" class="container-fluid" id="divBuscar" runat="server" visible="false">
        <div class="form-group">
            <label class="form-label mt-4">Cliente: </label>
            <input type="text" class="form-control" id="BuscarNome" placeholder="Nome do Cliente" runat="server">
            <br />
        </div>
        <div class="row">
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Buscar" OnClick="Busca_Click" />
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Novo Cadastro" OnClick="NovoCadastro_Click" />
                </div>

            </div>
        </div>
    </div>

    <div style="width: fit-content; padding: 20px;" class="container-fluid" id="divRegistros" runat="server" visible="false">

        <div class="row">
            <div class="col-md-auto">
                <div class="form-group">
                    <input type="text" class="form-control" id="txtBuscaNome" placeholder="Buscar nome do Cliente" runat="server">
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:ImageButton type="submit" class="btn btn-primary" runat="server" ImageUrl="~/Images/procurar.png" Width="50px" Height="33px" OnClick="BuscaNome_Click" />
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="GridViewUsuarios" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewUsuarios_RowEditing"
            CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="table table-striped" HeaderStyle-BackColor="#33ccff"
            RowStyle-BackColor="#FFFFFF" AlternatingRowStyle-BackColor="#33ccff" runat="server" DataKeyNames="IdCliente">
            <Columns>
                <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-ForeColor="#4C4C4C" SortExpression="status" />
                <asp:CommandField ShowEditButton="True" ShowHeader="True" EditText="&lt;img src='../Images/edit-icon.png' title='Editar' alt='Editar' border=0&gt;">
                    <ItemStyle CssClass="text-center" />
                </asp:CommandField>
                <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-ForeColor="#4C4C4C" SortExpression="nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" HeaderStyle-ForeColor="#4C4C4C" SortExpression="cpf" />
                <asp:BoundField DataField="Contato" HeaderText="Contato" HeaderStyle-ForeColor="#4C4C4C" SortExpression="contato" />
                <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-ForeColor="#4C4C4C" SortExpression="email" />
            </Columns>
        </asp:GridView>
        <div class="row" style="justify-content: right; padding: 10px 0px 0px 400px">
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Voltar" OnClick="VoltarBuscar_Click" />
                </div>
            </div>
        </div>
    </div>

    <div style="width: fit-content;" class="container-fluid" id="divCadastro" runat="server" visible="false">

        <div class="row">
            <div class="col-md-auto">
                <div class="form-group">
                    <label class="form-label mt-4">Cliente: </label>
                    <input type="text" class="form-control" id="txtnome" placeholder="Nome do Cliente" runat="server">
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <label class="form-label mt-4">CPF: </label>
                    <input type="text" oninput="mascaracpf(this)" class="form-control" id="txtcpf" placeholder="CPF do usuário" runat="server">
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-auto">
                <div class="form-group">
                    <label class="form-label mt-4">Contato: </label>
                    <input type="text" oninput="mascaratelefone(this)" class="form-control" id="txtcontato" placeholder="DDD + Número" runat="server">
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <label class="form-label mt-4">Email: </label>
                    <input type="text" class="form-control" id="txtemail" placeholder="Email do usuário" runat="server">
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-auto">
                <div class="form-check form-switch" style="padding: 50px">
                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" runat="server">
                    <label class="form-check-label" for="flexSwitchCheckDefault">Inativado / Ativado</label>
                </div>
            </div>
            <div class="col-md-auto">
                <div class="row" style="padding: 48px 0px 0px 0px">
                    <div class="col-md-auto">
                        <div class="form-group">
                            <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Salvar" OnClick="Cadastro_Click" ID="btncadastro" />
                        </div>
                    </div>
                    <div class="col-md-auto">
                        <div class="form-group">
                            <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Voltar" OnClick="VoltarBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--        <div class="row" style="justify-content: right; padding: 50px 0px 0px 250px">
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Cadastrar" OnClick="Cadastro_Click" ID="btncadastro" />
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Voltar" OnClick="VoltarBuscar_Click" />
                </div>
            </div>
        </div>--%>
    </div>

    <script>
        function mascaracpf(i) {

            var v = i.value;

            if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
                i.value = v.substring(0, v.length - 1);
                return;
            }
            i.setAttribute("maxlength", "14");
            if (v.length == 3 || v.length == 7) i.value += ".";
            if (v.length == 11) i.value += "-";
        }
        function mascaratelefone(i) {

            var v = i.value;

            if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
                i.value = v.substring(0, v.length - 1);
                return;
            }
            i.setAttribute("maxlength", "12");
        }
    </script>
    <%--    <asp:Table runat="server" ID="TableBusca" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label runat="server">Buscar Pessoas</asp:Label>
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
                <asp:Label runat="server">Tipo Cadastro: </asp:Label>
                <asp:DropDownList ID="ddlBTipoCadastro" runat="server">
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
                    <asp:Label runat="server">Cadastro Pessoas</asp:Label>
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
                <asp:Label runat="server">Tipo Cadastro: </asp:Label>
                <asp:DropDownList ID="ddlTipoCadastro" runat="server">
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
                    <asp:Label runat="server">Alterar Pessoas</asp:Label>
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
                <asp:Label runat="server">Tipo Cadastro: </asp:Label>
                <asp:DropDownList ID="ddlATipoCadastro" runat="server">
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
                <asp:GridView ID="GridViewPessoas" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewPessoas_RowEditing"
                    CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="grid" HeaderStyle-BackColor="#D1D2D4" RowStyle-BackColor="#FFFFFF" runat="server" DataKeyNames="IdPessoa">
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
    <%-- <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-ForeColor="#4C4C4C" SortExpression="status" />

                        <asp:CommandField ShowEditButton="True" ShowHeader="True" EditText="&lt;img src='../Images/edit-icon.png' title='Editar' alt='Editar' border=0&gt;">
                            <ItemStyle CssClass="text-center" />
                        </asp:CommandField>

                        <asp:BoundField DataField="TipoCadastro" HeaderText="Tipo Cadastro" HeaderStyle-ForeColor="#4C4C4C" SortExpression="tipocadastro" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-ForeColor="#4C4C4C" SortExpression="nome" />
                        <asp:BoundField DataField="cpf" HeaderText="CPF" HeaderStyle-ForeColor="#4C4C4C" SortExpression="cpf" />
                        <asp:BoundField DataField="Contato" HeaderText="Contato" HeaderStyle-ForeColor="#4C4C4C" SortExpression="contato" />
                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-ForeColor="#4C4C4C" SortExpression="email" />

                        <%--                        <asp:TemplateField HeaderText="Icone">
                            <ItemStyle Width="18px" CssClass="text-center" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("CaminhoIcone") %>' ID="lblcaminho" Visible="false" />
                                <asp:ImageButton ID="imgcaminho" runat="server" CausesValidation="false" ToolTip="Status" heigth="70px" Width="70px" OnClick="pagenewstatus_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
    <%--</Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>
</asp:Content>
