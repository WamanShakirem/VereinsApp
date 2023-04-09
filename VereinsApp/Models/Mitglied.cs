using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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


    }
}
