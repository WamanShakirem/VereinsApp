using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            Trace.WriteLine("DatenbankSteuerung: load Mitglieder");
            //Context stellt Datenbankverbindung automatisch her.
            using VereinsKontext context = new VereinsKontext();
            return context.Mitglieder.Include(m => m.RechnungListe).ToList(); //Mitglieder zurückgeben
        }

        public void AddMitglied(string vorname, string nachname, string geschlecht, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            Trace.WriteLine("DatenbankSteuerung: add Mitglied: " + vorname);
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
            Trace.WriteLine("DatenbankSteuerung: delete Mitglied: " + id);

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
            Trace.WriteLine("DatenbankSteuerung: UpdateMitglied: " + m.Id + " " + m.Vorname);
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Update(m);
                context.SaveChanges();
            }
        }

        //----Rechnungen Datenbankoperationen----
        public List<Rechnung> LoadRechnungen()
        {
            Trace.WriteLine("DatenbankSteuerung: Load Rechnungen");
            using VereinsKontext context = new VereinsKontext();
            return context.Rechnungen.Include(r => r.Mitglied).ToList();
        }

        public void AddRechnung(DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            Trace.WriteLine("DatenbankSteuerung: Add Rechnung: " + MitgliedId + " " + Betrag);
            using (VereinsKontext context = new VereinsKontext())
            {
                Rechnung r = new Rechnung(Bezahldatum, Betrag, MitgliedId);
                context.Rechnungen.Add(r);
                context.SaveChanges();
            }
        }

        public void DeleteRechnung(int id)
        {
            Trace.WriteLine("DatenbankSteuerung: Delete Rechnung: " + id);
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
            Trace.WriteLine("DatenbankSteuerung: Update Rechnung: " + r.Id);
            using (VereinsKontext context = new VereinsKontext())
            {
                context.Update(r);
                context.SaveChanges();
            }
        }

        //Das Fragezeichen nach dem Mitglied gibt an das es auch NULL sein kann.
        public Mitglied? GetMitglied(int Id)
        {
            
            Trace.WriteLine("DatenbankSteuerung: GetMitglied: " + Id);
            //Sucht das Mitglied anhand der Id und gibt es durch das Return zurück. 
            using (VereinsKontext context = new VereinsKontext())
            {
                return context.Mitglieder.Include(m => m.RechnungListe)
                .SingleOrDefault(m => m.Id == Id);
            }
        }
    }
}
