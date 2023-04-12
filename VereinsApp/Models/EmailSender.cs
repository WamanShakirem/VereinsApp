using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    public class EmailSender
    {
        // E-Mail-Einstellungen
        private static string senderEmail = "qonix123@gmx.at";
        private static string senderPassword = "ggffncc123";
        private static NetworkCredential credentials = new NetworkCredential(senderEmail, senderPassword);

        public bool SendMail(List<string> receiver_emails, string subject, string msg)
        {
            try
            {
                // Erstelle die E-Mail-Nachricht
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.Subject = subject;
                mail.Body = msg;

                // Empfänger hinzufügen
                foreach(string recipient in receiver_emails)
                {
                    mail.To.Add(recipient);
                }


                // SMTP-Einstellungen für den Gmail-Server
                SmtpClient smtpClient = new SmtpClient("mail.gmx.net", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                // Sende die E-Mail
                smtpClient.Send(mail);

                Trace.WriteLine("Die E-Mail wurde erfolgreich gesendet!");
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Fehler beim Senden der E-Mail: " + ex.Message);
                return false;
            }
        }
    }
}
