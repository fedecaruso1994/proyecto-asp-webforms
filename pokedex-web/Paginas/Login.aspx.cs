using dominio;
using System;
using negocio;

namespace pokedex_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            string destino;

            Session.Remove("usuario");

            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    destino = "Default.aspx";
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    destino = "Error.aspx";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                destino = "Error.aspx";
            }

            Response.Redirect(destino);
        }
    }
}