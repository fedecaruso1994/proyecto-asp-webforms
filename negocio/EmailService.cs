using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage _message;
        private SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential("programationiii@gmail.com", "progrmacion3"),
                EnableSsl = true,
                Port = 587,
                Host = "smtp.gmail.com"
            }; 
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            _message = new MailMessage
            {
                From = new MailAddress("programationiii@gmail.com"),
                Subject = asunto,
                IsBodyHtml = true,
                Body = $"<h1>{cuerpo}</h1>"

            };
            _message.To.Add(emailDestino);
        }
        public void enviarEmail()
        {
            try
            {
                _smtpClient.Send(_message);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
           
        }
    }

}
