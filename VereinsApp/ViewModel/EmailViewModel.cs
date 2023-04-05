using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VereinsApp.Commands;
using VereinsApp.Models;
using System.Diagnostics;
using System.Windows;
using System.Security.Cryptography.X509Certificates;

namespace VereinsApp.ViewModel
{
    public class EmailViewModel : BaseViewModel
    {
        Model model = new Model();

        public string? Subject { get; set; }
        public string? Body { get; set; }

        public ICommand SendenClickCommand { get; private set; }
        public EmailViewModel()
        {
            model = new Model();
            SendenClickCommand = new RelayCommand(EmailSenden); //Command eine Zielfunktion zuweisen

        }

        private void EmailSenden(Object obj)
        {
            //Eingabe Prüfen.
            if (Subject == null || Body == null)
            {
                MessageBox.Show("Bitte fülle alle Felder aus!");
                return;
            }
            if (Subject.Trim() == "" || Body.Trim() == "")
            {
                MessageBox.Show("Bitte fülle alle Felder aus!");
                return;
            }

            Trace.WriteLine("EMailSenden wurde geklickt.");
            Trace.WriteLine(Subject.Trim());
            Trace.WriteLine(Body.Trim());
            

            //Überprüfen ob das Senden geklappt hat.
            bool success = model.SendEmailToAll(Subject.Trim(), Body.Trim());
            if (success)
            {
                MessageBox.Show("E-Mail erfolgreich gesendet");
            }else
            {
                MessageBox.Show("Fehler beim senden der E-Mail!");
            }
            
        }

    }
}

