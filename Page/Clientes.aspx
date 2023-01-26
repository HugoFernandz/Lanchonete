<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SistemaLoja01.Page.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div style="background-image: linear-gradient(#ffc7ab, #ffffff);">

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
            &nbsp Revise as informações e tente novamente.
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
                        <asp:ImageButton type="submit" runat="server" ImageUrl="~/Images/procurar.png" Height="25px" Width="25px" OnClick="BuscaNome_Click" />
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="GridViewClientes" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewClientes_RowEditing"
                CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="table table-striped" HeaderStyle-BackColor="#fc8128" OnRowDataBound="GridViewClientes_RowDataBound"
                RowStyle-BackColor="#FFFFFF" AlternatingRowStyle-BackColor="#ded9d9" runat="server" DataKeyNames="IdCliente" GridLines="Vertical" BorderColor="Black">
                <Columns>

                    <asp:TemplateField>
                        <HeaderTemplate>Status</HeaderTemplate>
                        <ItemStyle CssClass="text-center" Width="20px" />
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                            <asp:Image ID="imgStatus" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowHeader="True" EditText="&lt;img src='../Images/lapis.png' title='Editar' alt='Editar' border=0&gt;" HeaderText="Editar">
                        <ItemStyle CssClass="text-center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="nome" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" SortExpression="cpf" />
                    <asp:BoundField DataField="Contato" HeaderText="Contato" SortExpression="contato" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="email" />
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
                        <input type="text" oninput="mascaracpf(this)" class="form-control" id="txtcpf" placeholder="CPF do Cliente" runat="server">
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
                        <input type="text" class="form-control" id="txtemail" placeholder="Email do Cliente" runat="server">
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
    </div>
</asp:Content>
