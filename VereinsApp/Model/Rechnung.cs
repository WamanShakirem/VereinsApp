using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Model
{
    public class Rechnung
    {
        public DataRow row;

        public int Id { get; set; }

        [DisplayName("Bezahldatum")]
        public DateTime Bezahldatum { get; set; }

        [DisplayName("Betrag")]
        public float Betrag { get; set; }

        [DisplayName("MitgliedId")]
        public int MitgliedId { get; set; }

        public Rechnung(int Id, DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            this.Id= Id;
            this.Bezahldatum = Bezahldatum;
            this.Betrag = Betrag;
            this.MitgliedId = MitgliedId;
        }

        public Rechnung(DataRow row)
        {
            Id = (int)row["Id"];
            Bezahldatum = (DateTime)row["Bezahldatum"];
            Betrag = (float)Convert.ToDouble(row["Betrag"]);
            MitgliedId = (int)row["MitgliedId"];
        }

    }

}
