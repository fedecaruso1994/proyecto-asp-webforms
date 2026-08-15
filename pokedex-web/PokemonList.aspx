<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonList.aspx.cs" Inherits="pokedex_web.PokemonList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Pokemons</h1>
    <asp:GridView 

        ID="dgvPokemons"  AllowPaging="true" PageSize="10" 
        PagerStyle-CssClass="table-pager" 
        PagerSettings-Mode="NumericFirstLast"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging" runat="server" DataKeyNames="Id" 
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" 
        CssClass="table table table-bordered" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="" />

        </Columns>
    </asp:GridView>
    <div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
