<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="SistemaLoja01.Page.Produtos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

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
            <input type="text" class="form-control" id="BuscarProduto" placeholder="Nome do Produto" runat="server">
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
                <div class="form-group">
                    <asp:ImageButton type="submit" class="btn btn-primary" runat="server" ImageUrl="~/Images/procurar.png" Width="50px" Height="33px" OnClick="BuscaNome_Click" />
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="GridViewProdutos" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewProdutos_RowEditing"
            CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="table table-striped" HeaderStyle-BackColor="#33ccff"
            RowStyle-BackColor="#FFFFFF" AlternatingRowStyle-BackColor="#33ccff" runat="server" DataKeyNames="IdProduto">
            <Columns>
                <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-ForeColor="#4C4C4C" SortExpression="status" />
                <asp:CommandField ShowEditButton="True" ShowHeader="True" EditText="&lt;img src='../Images/edit-icon.png' title='Editar' alt='Editar' border=0&gt;">
                    <ItemStyle CssClass="text-center" />
                </asp:CommandField>
                <asp:BoundField DataField="TipoProduto" HeaderText="Tipo Produto" HeaderStyle-ForeColor="#4C4C4C" SortExpression="tipoproduto" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" HeaderStyle-ForeColor="#4C4C4C" SortExpression="nome" />
                <asp:BoundField DataField="Preco" HeaderText="Preco" HeaderStyle-ForeColor="#4C4C4C" SortExpression="preco" />
                <asp:BoundField DataField="quantidade" HeaderText="Quantidade" HeaderStyle-ForeColor="#4C4C4C" SortExpression="quantidade" />
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

        <%--        <div class="row">
            <div class="col-md-auto">
                <div class="form-check form-switch" style="padding: 50px">
                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" runat="server">
                    <label class="form-check-label" for="flexSwitchCheckDefault">Inativado / Ativado</label>
                </div>
            </div>
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
        </div>--%>
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

</asp:Content>
