<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicos.aspx.cs" Inherits="SistemaLoja01.Page.Servicos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div style="background-image: linear-gradient(#ffc7ab, #ffffff);">
        <br />
        <h1>Serviços</h1>

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
            <br />
            <asp:GridView ID="GridViewServicos" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20"
                CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="table table-striped"  HeaderStyle-BackColor="#fc8128"
                 RowStyle-BackColor="#FFFFFF" AlternatingRowStyle-BackColor="#ded9d9" runat="server" DataKeyNames="IdServico" GridLines="Vertical" BorderColor="Black">
                <Columns>
                    <asp:BoundField DataField="Cliente" HeaderText="Nome Cliente" SortExpression="nomecliente" />
                    <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                    <asp:BoundField DataField="FormaPagamento" HeaderText="Forma de Pagamento" SortExpression="formapagamento" />
                    <asp:BoundField DataField="Produto" HeaderText="Nome Produto"  SortExpression="produto"/>
                    <asp:BoundField DataField="PrecoProduto" HeaderText="Preço Produto" SortExpression="precoproduto" />
                    <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" SortExpression="quantidade" />
                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="total" />
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
                        <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group">
                        <label class="form-label mt-4">Produto: </label>
                        <asp:DropDownList ID="ddlCTipoProduto" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 0px 0px 0px 5px">
                        <label class="form-label mt-4">Quantidade: </label>
                        <input type="text" oninput="mascaraquantidade(this)" class="form-control" id="txtQuantidade" runat="server" style="width: 100px">
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 55px 0px 0px 10px">
                        <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Registrar" OnClick="Cadastro_Click" ID="btnCadastrar" />
                    </div>
                </div>
            </div>
            <div class="row" runat="server" id="rowfinaliza" visible="false">
                <div class="col-md-auto">
                    <div class="form-group">
                        <label class="form-label mt-4">Valor UN: </label>
                        <input runat="server" type="text" class="form-control" style="width: 80px" id="txtunidade" />
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group">
                        <label class="form-label mt-4">Total: </label>
                        <input runat="server" type="text" class="form-control" style="width: 80px" id="txttotal" />
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group">
                        <label class="form-label mt-4">Forma de Pagamento: </label>
                        <asp:DropDownList ID="ddlTipoPagamento" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-auto">
                    <div class="form-group" style="padding: 55px 0px 0px 65px">
                        <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Finalizar" OnClick="btnfinalizar_Click" ID="btnfinalizar" />
                    </div>
                </div>
            </div>
            <div class="row" style="justify-content: right; padding: 10px 10px 0px 400px">
                <div class="col-md-auto">
                    <div class="form-group">
                        <asp:Button type="submit" class="btn btn-primary" runat="server" Text="Voltar" OnClick="VoltarBuscar_Click" />
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
