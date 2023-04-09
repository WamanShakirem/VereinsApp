using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VereinsApp.Commands;
using VereinsApp.Models;

namespace VereinsApp.ViewModel
{
    public class MitgliedDetailsViewModel : BaseViewModel
    {
        private Model model;
        Mitglied _selectedMitglied;

        public Mitglied SelectedMitglied //Dies ist notwendig für Bindings
        {
            get { return _selectedMitglied; }
            set
            {
                _selectedMitglied = value;
                OnPropertyChanged(nameof(SelectedMitglied));
            }
        }

        public Rechnung? SelectedRechnung { get; set; }

        public DateTime? BezahldatumNeu { get; set; } //Die Fragezeichen bedeuten dass sie null sein können.
        public float? BetragNeu { get; set; }

        public ICommand SpeichernClickCommand { get; private set; }
        public ICommand RechnungAddClickCommand { get; private set; }

        public ICommand DeleteRechnungClickCommand { get; private set; }

        public ICommand ExportierenClickCommand { get; private set; }

        public MitgliedDetailsViewModel(Mitglied SelectedMitglied) //Konstuktor
        {
            model = new Model();
            _selectedMitglied = SelectedMitglied;
            Trace.WriteLine("Mitglied Details: " + SelectedMitglied.Vorname);

            SpeichernClickCommand = new RelayCommand(MitgliedSpeichern); //Command eine Zielfunktion zuweisen
            RechnungAddClickCommand = new RelayCommand(RechnungAdd); 
            DeleteRechnungClickCommand = new RelayCommand(DeleteRechnung);
            ExportierenClickCommand = new RelayCommand(MitgliedExportieren);
        }

        private void MitgliedSpeichern(Object obj)
        {
            Trace.WriteLine("Speicherbutton wurde geklickt.");

            model.UpdateMitglied(SelectedMitglied);
        }

        private void RechnungAdd(Object obj) 
        {
            Trace.WriteLine("Rechnung hinzufügen Button wurde geklickt.");
            Trace.WriteLine(BetragNeu);


            if (BetragNeu == null || BezahldatumNeu == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
            }
            else
            {
                //.Value, da sie null sein können, aber das wird durch die if Bedingung geprüft 
                model.AddRechnung(BezahldatumNeu.Value, BetragNeu.Value, SelectedMitglied.Id);
                
                //Mitglied ersetzen gegen aktualisiertes Mitglied.
                SelectedMitglied = model.GetMitglied(SelectedMitglied.Id);
            }

        }

        private void DeleteRechnung(Object obj)
        {
            Trace.WriteLine("DeleteRechnung wurde gedrückt.");
            //Wenn eine Rechnung ausgewählt wird ist es ungleich Null.
            if (SelectedRechnung != null)
            {
                Trace.WriteLine("SelectedRechnung:" + SelectedRechnung?.Id);
                model.DeleteRechnung(SelectedRechnung.Id);
                //Mitglied und somit auch die Rechnungsliste ersetzen gegen aktualisiertes Mitglied.
                SelectedMitglied = model.GetMitglied(SelectedMitglied.Id);
            }
        }

        private void MitgliedExportieren(Object obj)
        {
            Trace.WriteLine("Exportiern wurde geklickt.");

            //Dialog öffnen
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV-Datei (*.csv)|*.csv";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.FileName = SelectedMitglied.Vorname + "_" + SelectedMitglied.Nachname;
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                //Mitglied-Daten abspeichern
                string content = SelectedMitglied.ExportDetails();
                File.WriteAllText(fileName, content);
            }

        }

    }
}
