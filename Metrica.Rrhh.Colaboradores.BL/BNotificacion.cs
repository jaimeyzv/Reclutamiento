using Metrica.Rrhh.Colaboradores.BL.Common;
using Metrica.Rrhh.Colaboradores.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Metrica.Rrhh.Colaboradores.BL
{
    public class BNotificacion: BClientQueue, IDisposable
    {
        #region "Variables locales"
        SmtpClient client = null;
        MailAddress address = null;
        #endregion

        public BNotificacion()
        {
            client = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings.Get("servidorMail"),
                Port = int.Parse(ConfigurationManager.AppSettings.Get("PuertoMail")),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("UserMail"), ConfigurationManager.AppSettings.Get("PassMail")),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            address = new MailAddress(ConfigurationManager.AppSettings.Get("UserMail"), ConfigurationManager.AppSettings.Get("NombreUserMail"));
        }

        public string RegistrarEmail(EmailDTO entity)
        {
            return RegistrarEmailQueue(entity);
        }
        public void EnviarEmailPendientesQueue()
        {
            ListarEmailQueue().ForEach(x =>
            {
                EnviarEmail(x);
            });
        }

        #region "Metodos Privados"
        private string ObtenerFormatoEmail()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Plantillas/Email.html")))
                body = reader.ReadToEnd();
            return body;
        }

        private void EnviarEmail(EmailDTO entity)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = address;
                message.Subject = entity.Asunto;
                message.IsBodyHtml = true;
                message.Body = ObtenerFormatoEmail().Replace("#reqMensaje", entity.Mensaje);
                message.To.Add(entity.Destinatario);
                if (!string.IsNullOrEmpty(entity.RutaAdjunto))
                    message.Attachments.Add(new Attachment(entity.RutaAdjunto));
                client.Send(message);
            }
        }
        #endregion

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
