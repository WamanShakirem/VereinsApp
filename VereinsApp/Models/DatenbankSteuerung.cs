using Microsoft.EntityFrameworkCore;
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
        
        public List<Mitglied> LoadMitglieder()
        {
            //Context stellt Datenbankverbindung automatisch her.
            using VereinsKontext context = new VereinsKontext();
            return context.Mitglieder.Include(m => m.RechnungListe).ToList(); //Mitglieder zurückgeben
        }

        public void AddMitglied(string vorname, string nachname, string geschlecht, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {   
            using (VereinsKontext context = new VereinsKontext())
            {
                Mitglied m = new Mitglied(vorname, nachname, geschlecht, geburtsdatum, adresse,
                    plz, ort, tel, email, beitrittsdatum, mitgliedschaftskategorie, bezahlmethode, notiz);
                
                context.Mitglieder.Add(m);

                context.SaveChanges();
            }
        }
        
        public void DeleteMitglied(int id)
        {
            Mitglied mitglied = new Mitglied() { Id = id };
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Mitglieder.Attach(mitglied);
                context.Mitglieder.Remove(mitglied);
                context.SaveChanges();
            }
        }

        public void UpdateMitglied(Mitglied m)
        {
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Update(m);
                context.SaveChanges();
            }
        }

        //----Rechnungen Datenbankoperationen----
        public List<Rechnung> LoadRechnungen()
        {
            using VereinsKontext context = new VereinsKontext();
            return context.Rechnungen.Include(r => r.Mitglied).ToList();
        }

        public void AddRechnung(DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            using (VereinsKontext context = new VereinsKontext())
            {
                Rechnung r = new Rechnung(Bezahldatum, Betrag, MitgliedId);
                context.Rechnungen.Add(r);
                context.SaveChanges();
            }
        }

        public void DeleteRechnung(int id)
        {
            Rechnung rechnung = new Rechnung() { Id = id };
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Rechnungen.Attach(rechnung);
                context.Rechnungen.Remove(rechnung);
                context.SaveChanges();
            }
        }

        public void UpdateRechnung(Rechnung r)
        {
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Update(r);
                context.SaveChanges();
            }
        }
    }
}
