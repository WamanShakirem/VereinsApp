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

        //Test
        [DisplayName("Vorname")] //Dies ändert den Namen der im Datagrid angezeigt wird
        public string Vorname { get; set; }

        [DisplayName("Nachname")]
        public string Nachname { get; set; }

        [DisplayName("Geschlecht")]
        public string Geschlecht { get; set; }

        [DisplayName("Geburtsdatum")]
        public DateTime Geburtsdatum { get; set; }

        [DisplayName("Adresse")]
        public string Adresse { get; set; }

        [DisplayName("Alter")]
        public int Alter { get { return DateTime.Today.Year - Geburtsdatum.Year; } }

        [DisplayName("PLZ")]
        public int Plz { get; set; }

        [DisplayName("Ort")]
        public string Ort { get; set; }

        [DisplayName("Telefonnummer")]
        public string Telefonnummer { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DisplayName("Beitrittsdatum")]
        public DateTime Beitrittsdatum { get; set; }

        [DisplayName("Mitgliedschaftskategorie")]
        public string Mitgliedschaftskategorie { get; set; }

        [DisplayName("Bezahlmethode")]
        public string Bezahlmethode { get; set; }

        [DisplayName("Notiz")]
        public string Notiz { get; set; }

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



    }
}
