<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaLoja01.Page.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
    <br />
    <h1>Usuários</h1>

    <div style="width: fit-content;" class="container-fluid" id="divBuscar" runat="server" visible="false">
        <div class="form-group">
            <label class="form-label mt-4">Usuário: </label>
            <input type="text" class="form-control" id="BuscarNome" placeholder="Nome do usuário" runat="server">
        </div>
        <div class="form-group">
            <label class="form-label mt-4">Tipo Usuário: </label>
            <asp:DropDownList ID="ddlBTipoUsuario" runat="server" CssClass="form-select"></asp:DropDownList>
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

    <div style="width: fit-content;" class="container-fluid" id="divRegistros" runat="server" visible="false">
        <asp:GridView ID="GridViewUsuarios" EmptyDataText="Nenhum Registro Localizado" CellPadding="4" AllowPaging="true" PageSize="20" OnRowEditing="GridViewUsuarios_RowEditing"
            CellSpacing="0" AutoGenerateColumns="false" BorderWidth="1" CssClass="d-md-grid" HeaderStyle-BackColor="#D1D2D4"
            RowStyle-BackColor="#FFFFFF" runat="server" DataKeyNames="IdUsuario">
            <Columns>
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
            </Columns>
        </asp:GridView>
        <div class="row" style="justify-content: right; padding: 57px">
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
                    <label class="form-label mt-4">Usuário: </label>
                    <input type="text" class="form-control" id="txtnome" placeholder="Nome do usuário" runat="server">
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
                <div class="form-group">
                    <label class="form-label mt-4">Login: </label>
                    <input type="text" class="form-control" id="txtlogin" placeholder="Login para o usuário" runat="server">
                </div>
            </div>
            <div class="col-md-auto">
                <div class="form-group">
                    <label class="form-label mt-4">Senha: </label>
                    <input type="password" class="form-control" id="txtsenha" placeholder="Digite uma senha" runat="server">
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-auto">
                <div class="form-group" style="padding: 0px 0px 0px 30px">
                    <label class="form-label mt-4">Tipo Usuário: </label>
                    <asp:DropDownList ID="ddlCtipousuario" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-auto">
                <div class="btn-group" role="group" aria-label="Basic radio toggle button group" style="padding: 55px 0px 0px 105px;">
                    <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" runat="server" checked="">
                    <label class="btn btn-outline-primary" for="btnradio1">Inativo</label>
                    <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off" runat="server" checked="">
                    <label class="btn btn-outline-primary" for="btnradio2">Ativo</label>
                </div>
            </div>
        </div>

        <div class="row" style="justify-content: right; padding: 50px 0px 0px 250px">
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

</asp:Content>
