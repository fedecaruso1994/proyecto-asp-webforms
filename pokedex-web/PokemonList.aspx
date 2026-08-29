<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonList.aspx.cs" Inherits="pokedex_web.PokemonList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons</h1>
    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control" />

            </div>
        </div>
    </div>
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
