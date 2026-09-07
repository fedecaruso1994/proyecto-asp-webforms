using System;
using System.Web.UI;
using dominio;

namespace pokedex_web
{
    public class PaginaSegura : Page
    {
        protected virtual bool RequiereAdmin
        {
            get { return false; }
        }

        protected override void OnInit(EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (RequiereAdmin && usuario.Tipo != UserType.ADMIN)
            {
                Session["error"] = "No tenés permisos para acceder a esta página";
                Response.Redirect("Error.aspx");
            }

            base.OnInit(e);
        }
    }
}
