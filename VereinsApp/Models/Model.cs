using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    public class Model
    {
        private DatenbankSteuerung dbSteuerung = new DatenbankSteuerung();
        private EmailSender emailSender = new EmailSender();

        public List<Mitglied> MitgliederListe;
        public List<Rechnung> RechnungListe;

        public Model()
        {
            MitgliederListe = dbSteuerung.LoadMitglieder();
            RechnungListe = dbSteuerung.LoadRechnungen();
        }

        public void Reload() //Damit bearbeitete Objekte zurückgesetzt werden können.
        {
            MitgliederListe = dbSteuerung.LoadMitglieder(); //MitgliederListe wird aktualisiert
            RechnungListe = dbSteuerung.LoadRechnungen();   //RechnungsListe wird aktualisiert.
        }

        public List<Mitglied> GetMitglieder()
        {
            return this.MitgliederListe;
        }

        public Mitglied? GetMitglied(int Id)
        {
            return dbSteuerung.GetMitglied(Id);
        }

        public void DeleteMitglied(int id)
        {
            dbSteuerung.DeleteMitglied(id);
            Reload();
        }

        public void DeleteRechnung(int id)
        {
            dbSteuerung.DeleteRechnung(id);
            Reload();
        }

        public void UpdateMitglied(Mitglied m) // Das veränderte Mitglied wird an die dbSteuerung weitergegeben(gespeichert).
        {
            dbSteuerung.UpdateMitglied(m);
            Reload();
        }

        public void AddMitglied(string vorname, string nachname, string geschlecht, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            dbSteuerung.AddMitglied(vorname, nachname, geschlecht, geburtsdatum, adresse, plz, ort, tel, email, beitrittsdatum, mitgliedschaftskategorie, bezahlmethode, notiz);
            Reload();
        }

        public void AddRechnung(DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            dbSteuerung.AddRechnung(Bezahldatum, Betrag, MitgliedId);
            Reload();
        }

        public List<Rechnung> GetRechnung()
        {
            return this.RechnungListe;
        }

        public bool SendEmailToAll(string subject, string body)
        {
            //Hier wird eine neue Liste E-mails erstellt und dieser Liste werden die E-Mails der Mitglieder hinzugefügt.
            List<string> emails = new List<string>();
            foreach(Mitglied mitglied in MitgliederListe)
            {
                emails.Add(mitglied.Email);
                Trace.WriteLine(mitglied.Email);
            }

            //Email senden
            return emailSender.SendMail(emails, subject, body); //Gibt zurück ob es geklappt hat oder nicht.
        }
    }
}
