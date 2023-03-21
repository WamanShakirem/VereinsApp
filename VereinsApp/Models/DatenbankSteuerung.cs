using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
* Alle CRUD Funktionen für die Datenbank
* Create
* Read
* Update
* Delete
*/

namespace VereinsApp.Models
{
    public class DatenbankSteuerung
    {
        private static string datenbankString = @"
            Data Source = (LocalDB)\MSSQLLocalDB; 
            AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;
            Integrated Security = True;
            Connect Timeout = 5";

        public List<Mitglied> mitgliederListe = new List<Mitglied>();
        public List<Rechnung> rechnungsListe = new List<Rechnung>();

        public DatenbankSteuerung()
        {
            LoadMitglieder();
            LoadRechnungen();
        }

        private void LoadMitglieder()
        {
            //context stellt datenbank verbindung automatisch her.
            using VereinsKontext context = new VereinsKontext(datenbankString);
            mitgliederListe = context.Mitglieder.ToList();
        }

        public void AddMitglied(string vorname, string nachname, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {   
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                Mitglied m = new Mitglied(vorname, nachname, geburtsdatum, adresse,
                    plz, ort, tel, email, beitrittsdatum, mitgliedschaftskategorie, bezahlmethode, notiz);
                
                context.Mitglieder.Add(m);

                context.SaveChanges();
            }
            LoadMitglieder();
        }
        
        public void DeleteMitglied(int id)
        {
            Mitglied mitglied = new Mitglied() { Id = id };
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                context.Mitglieder.Attach(mitglied);
                context.Mitglieder.Remove(mitglied);
                context.SaveChanges();
            }
            LoadMitglieder();
        }

        public void UpdateMitglied(Mitglied m)
        {
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                context.Update(m);
                context.SaveChanges();
            }
            LoadMitglieder();
        }


        //----Rechnungen Datenbankoperationen----


        private void LoadRechnungen()
        {
            using VereinsKontext context = new VereinsKontext(datenbankString);
            rechnungsListe = context.Rechnungen.ToList();
        }

        public void AddRechnung(DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                Rechnung r = new Rechnung(Bezahldatum, Betrag, MitgliedId);
                context.Rechnungen.Add(r);
                context.SaveChanges();
            }
            LoadRechnungen();
        }

        public void DeleteRechnung(int id)
        {
            Rechnung rechnung = new Rechnung() { Id = id };
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                context.Rechnungen.Attach(rechnung);
                context.Rechnungen.Remove(rechnung);
                context.SaveChanges();
            }
            LoadRechnungen();
        }

        public void UpdateRechnung(Rechnung r)
        {
            using (VereinsKontext context = new VereinsKontext(datenbankString))
            {
                context.Update(r);
                context.SaveChanges();
            }
            LoadRechnungen();
        }
    }
}
