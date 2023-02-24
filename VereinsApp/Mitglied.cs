using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VereinsApp
{
    public class Mitglied
    {
        private string test = "Test";

        [DisplayName("Vorname")] //dies ändert den Namen der im datagrid angezeigt wird
        public string vorname { get; set; }

        [DisplayName("Nachname")]
        public string nachname { get; set; }

        [DisplayName("Geburtsdatum")]
        public DateTime geburtsdatum { get; set; }

        [DisplayName("Adresse")]
        public string adresse { get; set; }

        [DisplayName("Alter")]
        public int alter { get { return DateTime.Today.Year - geburtsdatum.Year; } }

        [DisplayName("PLZ")]
        public int plz { get; set; }

        [DisplayName("Ort")]
        public string ort { get; set; }

        [DisplayName("Telefonnummer")]
        public string tel { get; set; }

        [DisplayName("E-Mail")]
        public string email { get; set; }

        [DisplayName("Beitrittsdatum")]
        public DateTime beitrittsdatum { get; set; }

        [DisplayName("Mitgliedschaftskategorie")]
        public string mitgliedschaftskategorie { get; set;}

        [DisplayName("Bezahlmethode")]
        public string bezahlmethode { get; set; }

        [DisplayName("Notiz")]
        public string notiz { get; set; }

        public Mitglied(string vorname, string nachname, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;
            this.adresse = adresse;
            this.plz = plz;
            this.ort = ort;
            this.tel = tel;
            this.email = email;
            this.beitrittsdatum = beitrittsdatum;
            this.mitgliedschaftskategorie = mitgliedschaftskategorie;
            this.bezahlmethode = bezahlmethode;
            this.notiz = notiz;
        }

        public Mitglied(DataRow row)
        {
            this.vorname = (string)row["Vorname"];
            this.nachname = (string)row["Nachname"];
            this.geburtsdatum = (DateTime)row["Geburtsdatum"];
            this.adresse = (string)row["Adresse"];
            this.plz = (int)row["PLZ"];
            this.ort = (string)row["Ort"];
            this.tel = (string)row["Telefon"];
            this.email = (string)row["E-Mail"];
            this.beitrittsdatum = (DateTime)row["Beitrittsdatum"];
            this.mitgliedschaftskategorie =  (string)row["Mitgliedsschaftskategorie"];
            this.bezahlmethode = (string)row["Bezahlmethode"];
            this.notiz = (string)row["Notiz"];
        }
        
    }
}
