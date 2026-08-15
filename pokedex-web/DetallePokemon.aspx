<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallePokemon.aspx.cs" Inherits="pokedex_web.DetallePokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <!-- COLUMNA IZQUIERDA -->
        <div class="col-md-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>

        </div>

        <!-- COLUMNA DERECHA -->
        <div class="col-md-6">

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox
                    runat="server"
                    TextMode="MultiLine"
                    ID="txtDescripcion"
                    CssClass="form-control" />
            </div>

            <asp:ScriptManager
                runat="server"
                ID="ScriptManager1">
            </asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox
                            runat="server"
                            ID="txtUrl"
                            CssClass="form-control"
                            AutoPostBack="true"
                            OnTextChanged="txtUrl_TextChanged" />
                    </div>

                    <!-- Contenedor que ocupa todo el espacio restante -->
                    <div class="flex-grow-1">
                        <asp:Image
                            ImageUrl="https://img.magnific.com/psd-gratis/imagen-fondo-transparente-vacia_191095-80808.jpg?semt=ais_hybrid&w=740&q=80"
                            ID="imgDetalle"
                            runat="server"
                            Width="50%" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <!-- BOTONES -->
        <div class="col-12 mb-3 mt-3">
            <asp:Button
                Text="Aceptar"
                ID="btnAceptar"
                OnClick="btnAceptar_Click"
                CssClass="btn btn-primary"
                runat="server" />

            <a href="Default.aspx" class="btn btn-secondary ms-2">Cancelar</a>
        </div>
    </div>
</asp:Content>
