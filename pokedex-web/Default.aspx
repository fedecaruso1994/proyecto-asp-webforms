<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Llegaste al Pokedex Web, tu lugar Pokemon...</p>
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="d-flex align-items-center mb-3">
                <label for="<%= ddlTipo.ClientID %>" class="form-label mb-0 me-2">
                    Tipo
                </label>

                <asp:DropDownList
                    runat="server"
                    ID="ddlTipo"
                    CssClass="form-select"
                    Style="width: 180px;"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4 justify-content-center">

                <%--  <% foreach (dominio.Pokemon poke in pokemons)
            {%>
        <div class="col d-flex justify-content-center">
            <div class="card" style="max-width: 18rem; width: 100%;">
                <img src="<%: poke.UrlImagen%>" class="card-img-top" alt="<%: poke.Nombre %>">
                <div class="card-body">
                    <h5 class="card-title"><%: poke.Nombre %></h5>
                    <p class="card-text"><%: poke.Descripcion %></p>
                </div>
            </div>
        </div>
        <%}%>--%>
                <asp:Repeater ID="repRepetidor" runat="server">
                    <ItemTemplate>
                        <div class="col d-flex justify-content-center">
                            <div class="card" style="max-width: 18rem; width: 100%;">
                                <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="<%#Eval("Nombre")%>">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <p class="card-text"><%#Eval("Descripcion")%></p>
                                    <a href="DetallePokemon.aspx?Id=<%#Eval("Id")%>">Ver detalle</a>
                                    <asp:Button ID="btnEjemplo" CssClass="btn btn-primary" runat="server" Text="Ejemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemomId" OnClick="btnEjemplo_Click" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
