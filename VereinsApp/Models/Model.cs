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

        public Model()
        {
            dbSteuerung = new DatenbankSteuerung();
        }

        public List<Mitglied> GetMitglieder()
        {
            return dbSteuerung.mitgliederListe;
        }

    }
}
