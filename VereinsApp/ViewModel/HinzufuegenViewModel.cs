using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VereinsApp.Commands;
using VereinsApp.Models;

namespace VereinsApp.ViewModel
{
    public class HinzufuegenViewModel : BaseViewModel
    {
        public string? Vorname { get; set; }

        public string? Nachname { get; set; }

        public string? Geschlecht { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public string? Adresse { get; set; }

        public int? Plz { get; set; }

        public string? Ort { get; set; }

        public string? Telefonnummer { get; set; }

        public string? Email { get; set; }

        public DateTime? Beitrittsdatum { get; set; }

        public string? Mitgliedschaftskategorie { get; set; }

        public string? Bezahlmethode { get; set; }

        public string? Notiz { get; set; }

        public ICommand AddClickCommand { get; private set; }

        Model model;
        public HinzufuegenViewModel()
        {
            AddClickCommand = new RelayCommand(MitgliedHinzufugen); //Command eine Zielfunktion zuweisen
            model = new Model();
        }

        private void MitgliedHinzufugen(Object obj)
        {
            Trace.WriteLine("Hinzufügen wurde geklickt.");

            //Testen ob jedes Feld ausgefüllt wurde! 

            if (Vorname == null || Nachname == null || Geschlecht == null || Geburtsdatum == null ||
                Adresse == null || Plz == null || Ort == null || Telefonnummer == null ||
                Email == null || Beitrittsdatum == null || Mitgliedschaftskategorie == null ||
                Bezahlmethode == null || Notiz == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
            }
            else
            {
                model.AddMitglied(Vorname, Nachname, Geschlecht, Geburtsdatum.Value, Adresse, Plz.Value, Ort, Telefonnummer, Email, Beitrittsdatum.Value, Mitgliedschaftskategorie, Bezahlmethode, Notiz);
                
            }

        }
    }
}
