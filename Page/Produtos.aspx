<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="SistemaLoja01.Page.Produtos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div style="background-image: linear-gradient(#ffc7ab, #ffffff);">
        <br />
        <h1>Produtos</h1>

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
                <label class="form-label mt-4">Produto: </label>
                <input type="text" class="form-control" id="BuscarNome" placeholder="Nome do Produto" runat="server">
            </div>
            <div class="form-group">
                <label class="form-label mt-4">Tipo Produto: </label>
                <asp:DropDownList ID="ddlBTipoProduto" runat="server" CssClass="form-select"></asp:DropDownList>
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
                        <input type="text" class="form-control" id="txtBuscaNome" placeholder="Buscar nome do Produto" runat="server">
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 5px">
                        <asp:ImageButton type="submit" runat="server" ImageUrl="~/Images/procurar.png" Height="25px" Width="25px" OnClick="BuscaNome_Click" />
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="GridViewProdutos" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewProdutos_RowEditing"
                CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="table table-striped" HeaderStyle-BackColor="#fc8128" OnRowDataBound="GridViewProdutos_RowDataBound"
                RowStyle-BackColor="#FFFFFF" AlternatingRowStyle-BackColor="#ded9d9" runat="server" DataKeyNames="IdProduto" GridLines="Vertical" BorderColor="Black">
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
                    <asp:TemplateField>
                        <HeaderTemplate>Tipo Produto</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTipoProduto" runat="server" Text='<%# Eval("TipoProduto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Preco" HeaderText="Preco" SortExpression="preco" />
                    <asp:BoundField DataField="quantidade" HeaderText="Quantidade" SortExpression="quantidade" />
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
                        <label class="form-label mt-4">Produto: </label>
                        <input type="text" class="form-control" id="txtnome" placeholder="Nome do Produto" runat="server">
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group">
                        <label class="form-label mt-4">Preço: </label>
                        <input type="text" class="form-control" id="txtpreco" placeholder="Preço do produto" runat="server">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 0px 0px 0px 50px">
                        <label class="form-label mt-4">Tipo Produto: </label>
                        <asp:DropDownList ID="ddlCTipoProduto" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 0px 0px 0px 45px">
                        <label class="form-label mt-4">Quantidade: </label>
                        <input type="text" oninput="mascaraquantidade(this)" class="form-control" id="txtquantidade" placeholder="Quantidade em estoque" runat="server">
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
            function mascaraquantidade(i) {

                var v = i.value;

                if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
                    i.value = v.substring(0, v.length - 1);
                    return;
                }
            }
        </script>
    </div>
</asp:Content>
