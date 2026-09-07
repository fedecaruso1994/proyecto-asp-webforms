using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;
            bool logueado = usuario != null;
            bool esAdmin = logueado && usuario.Tipo == UserType.ADMIN;

            lnkHome.Visible = logueado;
            lnkPokemonList.Visible = esAdmin;

            lnkLogin.Visible = !logueado;
            lnkLogout.Visible = logueado;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}