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

        public DateTime Bezahldatum { get; set; }

        public double Betrag { get; set; }

        public int MitgliedId { get; set; }
        public Mitglied Mitglied { get; set; }

        public Rechnung(DateTime Bezahldatum, double Betrag, int MitgliedId)
        {
            this.Bezahldatum = Bezahldatum;
            this.Betrag = Betrag;
            this.MitgliedId = MitgliedId;
        }
        
        public Rechnung(){}
    }

}
