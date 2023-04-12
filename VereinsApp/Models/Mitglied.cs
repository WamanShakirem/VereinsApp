using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Navigation;

namespace VereinsApp.Models
{
    public class Mitglied
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geschlecht { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string Adresse { get; set; }
        public int Alter { get { return DateTime.Today.Year - Geburtsdatum.Year; } }
        public int Plz { get; set; }
        public string Ort { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public DateTime Beitrittsdatum { get; set; }
        public string Mitgliedschaftskategorie { get; set; }
        public string Bezahlmethode { get; set; }
        public string? Notiz { get; set; }
        public List<Rechnung> RechnungListe { get; set; }

        public bool Bezahlt { 
            get { return HasPayed(); }
        }

        public Mitglied(string vorname, string nachname, string geschlecht, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geschlecht = geschlecht;
            this.Geburtsdatum = geburtsdatum;
            this.Adresse = adresse;
            this.Plz = plz;
            this.Ort = ort;
            this.Telefonnummer = tel;
            this.Email = email;
            this.Beitrittsdatum = beitrittsdatum;
            this.Mitgliedschaftskategorie = mitgliedschaftskategorie;
            this.Bezahlmethode = bezahlmethode;
            this.Notiz = notiz;
        }
        
        public Mitglied(){}

        public string ExportDetails()
        {
            return $"{this.Vorname}, {this.Nachname}, {this.Geschlecht}, {this.Geburtsdatum}," +
                   $" {this.Adresse}, {this.Plz}, {this.Ort}, {this.Telefonnummer}," +
                   $" {this.Email}, {this.Mitgliedschaftskategorie}, {this.Bezahlmethode}, {this.Notiz}";
        }

        private bool HasPayed() //Bezahlt oder nicht
        {
            //Wenn keine Rechnungen vorhanden sind dann ist die Rechnung nicht bezahlt
            if(this.RechnungListe.Count == 0) return false;

            //Rechnung sortieren nach Bezahltdatum und dann die erste Rechnung auswählen
            Rechnung lastRechnung = RechnungListe.OrderByDescending(r => r.Bezahldatum).First();

            if (this.Mitgliedschaftskategorie == "Monatlich")
            {
                // Wenn die letzte Rechnung maximal ein Monat alt ist dann ist die Rechnung bezahlt sonst nein
                DateTime heuteVorEinemMonat = DateTime.Now.AddMonths(-1);

                return lastRechnung.Bezahldatum >= heuteVorEinemMonat;
            }
            else if (this.Mitgliedschaftskategorie == "Halbjährlich")
            {
                // wenn letzte rechnung maximal ein halbes jahr alt ist dann bezahlt sont nein
                DateTime heuteVor6Monaten = DateTime.Now.AddMonths(-6);

                return lastRechnung.Bezahldatum >= heuteVor6Monaten;

            }
            else if(this.Mitgliedschaftskategorie == "Jährlich")
            {
                // wenn letzte rechnung maximal ein jahr alt ist dann bezahlt sont nein
                DateTime heuteVorEinemJahr = DateTime.Now.AddYears(-1);

                return lastRechnung.Bezahldatum >= heuteVorEinemJahr;
            }
            else
            {
                return false;
            }
            
        }

    }
}
