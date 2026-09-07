<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class=" col-6">
            <div class="mb-3">
                <label for="txtUser" class="form-label">Usuario</label>
                <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control"  TextMode="Password" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
