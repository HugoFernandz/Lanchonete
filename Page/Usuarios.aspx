<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SistemaLoja01.Page.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="container-fluid">
        <br />
        <h1>Usuários</h1>

        <fieldset style="width:fit-content;" class="container-fluid">
            <br />
            <legend>Localizar Usuários</legend>
            <div class="form-group">
                <label class="form-label mt-4">Usuário: </label>
                <input type="text" class="form-control" id="BuscarNome" placeholder="Nome do usuário" runat="server">
            </div>
            <div class="form-group">
                <label class="form-label mt-4">Tipo Usuário: </label>
                <asp:DropDownList ID="ddlBTipoUsuario" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="form-group">
                <br />
                <button type="submit" class="btn btn-primary" onclick="Busca_Click">Buscar</button>
            </div>
        </fieldset>
    </div>

    <%-- Example select --%>



    <%--            <div class="form-group">
                <label for="exampleInputPassword1" class="form-label mt-4">Password</label>
                <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" runat="server">
            </div>
            <div class="form-group">
                <label for="exampleSelect1" class="form-label mt-4">Example select</label>
                <select class="form-select" id="exampleSelect1">
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleSelect2" class="form-label mt-4">Example multiple select</label>
                <select multiple="" class="form-select" id="exampleSelect2">
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </div>
            <div class="form-group">
                <label for="exampleTextarea" class="form-label mt-4">Example textarea</label>
                <textarea class="form-control" id="exampleTextarea" rows="3"></textarea>
            </div>
            <div class="form-group">
                <label for="formFile" class="form-label mt-4">Default file input example</label>
                <input class="form-control" type="file" id="formFile">
            </div>
            <fieldset class="form-group">
                <legend class="mt-4">Radio buttons</legend>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked="">
                    <label class="form-check-label" for="optionsRadios1">
                        Option one is this and that—be sure to include why it's great
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                    <label class="form-check-label" for="optionsRadios2">
                        Option two can be something else and selecting it will deselect option one
                    </label>
                </div>
                <div class="form-check disabled">
                    <input class="form-check-input" type="radio" name="optionsRadios" id="optionsRadios3" value="option3" disabled="">
                    <label class="form-check-label" for="optionsRadios3">
                        Option three is disabled
                    </label>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend class="mt-4">Checkboxes</legend>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                    <label class="form-check-label" for="flexCheckDefault">
                        Default checkbox
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" checked="">
                    <label class="form-check-label" for="flexCheckChecked">
                        Checked checkbox
                    </label>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend class="mt-4">Switches</legend>
                <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault">
                    <label class="form-check-label" for="flexSwitchCheckDefault">Default switch checkbox input</label>
                </div>
                <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked" checked="">
                    <label class="form-check-label" for="flexSwitchCheckChecked">Checked switch checkbox input</label>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend class="mt-4">Ranges</legend>
                <label for="customRange1" class="form-label">Example range</label>
                <input type="range" class="form-range" id="customRange1">
                <label for="disabledRange" class="form-label">Disabled range</label>
                <input type="range" class="form-range" id="disabledRange" disabled="">
                <label for="customRange3" class="form-label">Example range</label>
                <input type="range" class="form-range" min="0" max="5" step="0.5" id="customRange3">
            </fieldset>
            <button type="submit" class="btn btn-primary">Submit</button>--%>
    <%--    <asp:Table runat="server" ID="TableBusca" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label runat="server" CssClass="Cabecalho">Buscar Usuários</asp:Label>
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
    </asp:Table>--%>

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
