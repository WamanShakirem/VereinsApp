using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VereinsApp.Models;

namespace VereinsApp.ViewModel
{
    public class StatistikSeiteViewModel : BaseViewModel
    {
        Model model = new Model();
        public int Mitgliederanzahl { get; set; }
        public int Mitgliederanzahl_w { get; set; }
        public int Mitgliederanzahl_m { get; set; }
        public int MittleresAlter { get; set; }
        public int Mitgliederanzahl_minderj { get; set; }
        public int Mitgliederanzahl_vollj { get; set; }
        public string JüngstesMitglied { get; set; }
        public string ÄltestesMitglied { get; set; }
        public string NeustesMitglied { get; set; }

        public StatistikSeiteViewModel()
        {
            Mitgliederanzahl = model.MitgliederListe.Count;


            //Where filtert die Liste mit einem Lambda ausdruck.
            Mitgliederanzahl_w = model.MitgliederListe.Where(m => m.Geschlecht == "Weiblich").ToList().Count;
            Mitgliederanzahl_m = model.MitgliederListe.Where(m => m.Geschlecht == "Männlich").ToList().Count;

            //OrderBy sortiert die Mitglieder nach Geburtsdatum.
            Mitglied jüngstes = model.MitgliederListe.OrderBy(m => m.Geburtsdatum).LastOrDefault();
            JüngstesMitglied = jüngstes.Vorname + " " + jüngstes.Nachname + " (" + jüngstes.Alter + ")";

            //OrderBy sortiert die Mitglieder nach Geburtsdatum.
            Mitglied ältestes = model.MitgliederListe.OrderBy(m => m.Geburtsdatum).FirstOrDefault();
            ÄltestesMitglied = ältestes.Vorname + " " + ältestes.Nachname + " (" + ältestes.Alter + ")";

            //Mittleres Alter berechnen
            int gesamtAlter = 0;
            foreach(Mitglied m in model.MitgliederListe)
            {
                gesamtAlter = gesamtAlter + m.Alter;
            }
            //Die Summe wird in die Variable gesamtAlter gespeichert und durch die Mitgliederanzahl dividiert. 
            MittleresAlter = gesamtAlter / model.MitgliederListe.Count;


            //Mitgliederanzahl Minderjährig.
            Mitgliederanzahl_minderj = 0;
            foreach (Mitglied m in model.MitgliederListe)
            {
                if(m.Alter < 18)
                {
                    //Die Mitgliederanzahl_minderj wird um 1 erhöht. 
                    Mitgliederanzahl_minderj++;
                }
            }

            //Berechnung der Anzahl von volljährigen Mitgliedern.
            Mitgliederanzahl_vollj = Mitgliederanzahl - Mitgliederanzahl_minderj;

            //Mitglieder sortieren nach Beitrittsdatum und dann das neuestes Mitglied ausgeben.
            Mitglied neustesMitglied = model.MitgliederListe.OrderBy(m => m.Beitrittsdatum).LastOrDefault();
            NeustesMitglied = neustesMitglied.Vorname + " " + neustesMitglied.Nachname;
        }
    }
}
