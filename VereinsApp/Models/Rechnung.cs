using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    public class Rechnung
    {
        public int Id { get; set; }

        [DisplayName("Bezahldatum")]
        public DateTime Bezahldatum { get; set; }

        [DisplayName("Betrag")]
        public double Betrag { get; set; }

        [DisplayName("MitgliedId")]
        public int MitgliedId { get; set; }

        public Rechnung(DateTime Bezahldatum, double Betrag, int MitgliedId)
        {
            this.Bezahldatum = Bezahldatum;
            this.Betrag = Betrag;
            this.MitgliedId = MitgliedId;
        }
        
        //Leerer Konstruktor um "Fake" Objekte zu erstellen. Wird im Datenbankcontroller genutzt um Objekte zu löschen.
        public Rechnung(){}
    }

}
