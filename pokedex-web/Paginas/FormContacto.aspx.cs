using System;
using negocio;

namespace pokedex_web.Paginas
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.armarCorreo(txtMail.Text, txtAsunto.Text, txtMensaje.Text);
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex); //Preguntar a Claude como manejar el error correctamnte aqui. 
            }
        }
    }
}