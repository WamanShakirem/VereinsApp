using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    public class Model
    {
        private DatenbankSteuerung dbSteuerung;

        public List<Mitglied> MitgliederListe;
        public List<Rechnung> RechnungListe;

        public Model()
        {
            dbSteuerung = new DatenbankSteuerung();
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

        public void DeleteMitglied(int id)
        {
            dbSteuerung.DeleteMitglied(id);
            MitgliederListe = dbSteuerung.LoadMitglieder();
        }

        public void UpdateMitglied(Mitglied m) // Das veränderte Mitglied wird an die dbSteuerung weitergegeben(gespeichert).
        {
            dbSteuerung.UpdateMitglied(m);
            MitgliederListe = dbSteuerung.LoadMitglieder();
        }

        public void AddMitglied(string vorname, string nachname, string geschlecht, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            dbSteuerung.AddMitglied(vorname, nachname, geschlecht, geburtsdatum, adresse, plz, ort, tel, email, beitrittsdatum, mitgliedschaftskategorie, bezahlmethode, notiz);
            MitgliederListe = dbSteuerung.LoadMitglieder();
        }

        public void AddRechnung(DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            dbSteuerung.AddRechnung(Bezahldatum, Betrag, MitgliedId);
            RechnungListe = dbSteuerung.LoadRechnungen();
        }

        public List<Rechnung> GetRechnung()
        {
            return this.RechnungListe;
        }
    }
}
