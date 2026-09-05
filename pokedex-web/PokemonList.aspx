<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonList.aspx.cs" Inherits="pokedex_web.PokemonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroSimple" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control" />
            </div>
        </div>
        <div class="col-md-6 d-flex align-items-end">
            <div class="mb-3">
                <asp:CheckBox
                    ID="checkBoxFiltroAvanzado"
                    runat="server"
                    Text="   Filtro Avanzado"
                    AutoPostBack="true"
                    OnCheckedChanged="checkBoxFiltroAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>

    <% if (checkBoxFiltroAvanzado.Checked)
        { %>

    <div class="row">
        <div class="col-md-3 mb-3">
            <asp:Label Text="Campo" runat="server" />
            <asp:DropDownList
                ID="ddlCampo"
                runat="server"
                CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Text="Nombre" Value="Nombre" />
                <asp:ListItem Text="Tipo" Value="Tipo" />
                <asp:ListItem Text="Número" Value="Número" />
            </asp:DropDownList>
        </div>

        <div class="col-md-3 mb-3">
            <asp:Label Text="Criterio" runat="server" />
            <asp:DropDownList
                ID="ddlCriterio"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>
        </div>

        <div class="col-md-3 mb-3">
            <asp:Label Text="Filtro" runat="server" />
            <asp:TextBox
                ID="txbFiltro"
                runat="server"
                CssClass="form-control">
            </asp:TextBox>
        </div>

        <div class="col-md-3 mb-3">
            <asp:Label Text="Estado" runat="server" />
            <asp:DropDownList
                ID="ddlEstado"
                runat="server"
                CssClass="form-control">
                <asp:ListItem Text="Todos" Value="Todos" />
                <asp:ListItem Text="Activo" Value="Activo" />
                <asp:ListItem Text="Inactivo" Value="Inactivo" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscarFiltro" OnClick="btnBuscarFiltro_Click" />
            </div>
        </div>
    </div>
    <% } %>
    <asp:GridView
        ID="dgvPokemons" AllowPaging="true" PageSize="10"
        PagerStyle-CssClass="table-pager"
        PagerSettings-Mode="NumericFirstLast"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging" runat="server" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        CssClass="table table table-bordered" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"></asp:CheckBoxField>
            <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="" />

        </Columns>
    </asp:GridView>
    <div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
