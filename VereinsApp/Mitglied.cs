using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace VereinsApp
{
    public class Mitglied
    {
        public string vorname { get; set; }
        public string nachname { get; set; }
        public DateTime geburtsdatum { get; set; }

        public int alter { get { return DateTime.Today.Year - geburtsdatum.Year; } }

        public int plz { get; set; }
        public string ort { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public DateTime beitrittsdatum { get; set; }

        public string mitgliedschaftskategorie { get; set;}
        public string bezahlmethode { get; set; }
        public string notiz { get; set; }

        public Mitglied(string vorname, string nachname, DateTime geburtsdatum, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;
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
