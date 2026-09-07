<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormContacto.aspx.cs" Inherits="pokedex_web.Paginas.Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class=" col-6">
            <div class="mb-3">
                <label for="txtMail" class="form-label">Correo</label>
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtAsunto" class="form-label">Asunto</label>
                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtMensaje" class="form-label">Mensaje</label>
                <asp:TextBox runat="server" ID="txtMensaje" CssClass="form-control" TextMode="MultiLine"/>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click"  />
            </div>
        </div>
    </div>
</asp:Content>
