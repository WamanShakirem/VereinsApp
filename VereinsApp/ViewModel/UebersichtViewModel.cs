using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using VereinsApp.Commands;
using VereinsApp.Models;
using VereinsApp.View;

namespace VereinsApp.ViewModel
{
    public class UebersichtViewModel : BaseViewModel
    {
        //ObservableCollection zum automatischen aktualisieren der Liste wenn sich Daten ändern.  
        private ObservableCollection<Mitglied> _mitgliederListe;
        public ObservableCollection<Mitglied> MitgliederListe // Für Binding notwendig
        {
            get => _mitgliederListe;
            private set
            {
                _mitgliederListe = value;
                OnPropertyChanged(nameof(MitgliederListe)); //Gui benachrichtigen beim Ersetzen der Liste
            }
        }

        private Model model = new Model();

        //Commands erstellen
        public ICommand DetailButtonClickCommand { get; private set; }
        public ICommand AddButtonClickCommand { get; private set; }
        public ICommand DeleteButtonClickCommand { get; private set; }
        
        public Mitglied? SelectedMitglied { get; set; }

        private string _searchText;
        public string SearchText // Für Binding notwendig
        {
            get => _searchText;
            set
            {
                _searchText = value;
                FilterMembers();
                OnPropertyChanged(nameof(SearchText));
            }
        }


        public UebersichtViewModel()
        {
            //model.AddMitglied("Hans", "Wurst", new DateTime(2005, 10, 10), "Straße 1", 123456, "Berlin", "87654667890", "jkdsfjfls@mail.de", new DateTime(2020, 10, 10), "basic", "kredit", "LOL");

            //model.AddRechnung(new DateTime(2023, 03, 30), 18, 1);
            

            _mitgliederListe = new ObservableCollection<Mitglied>(model.GetMitglieder());
            _searchText = "";
            foreach(Mitglied m in MitgliederListe)
            {
                Trace.WriteLine(m.Vorname);
                Trace.WriteLine("Rechnugen:");
                if(m.RechnungListe == null)
                {
                    Trace.WriteLine("Keine Rechnungen vorhanden");
                }
                else
                {
                    foreach (Rechnung r in m.RechnungListe)
                    {
                        Trace.WriteLine(r.Betrag);
                    }
                }
                
            }
            //Commands die Zielfunktion zuweisen
            DetailButtonClickCommand = new RelayCommand(OpenDetailWindow); 
            AddButtonClickCommand = new RelayCommand(OpenAddMitgliedWindow);
            DeleteButtonClickCommand = new RelayCommand(DeleteMitglied);
        }
 
        private void OpenDetailWindow(Object obj)
        {   
            Trace.WriteLine("OpenDetailWindow clicked");
            if (SelectedMitglied == null)
            {
                Trace.WriteLine("Kein Mitglied ausgewählt");
                return;
            }

            // Um zu wissen welches Mitglied ausgewählt ist, Mitglied an DetailWindow übergeben
            MitgliedDetailsWindow window = new MitgliedDetailsWindow(SelectedMitglied);

            //Detail Window close Event ruft Window_Closing Funktion auf
            window.Closing += Window_Closing;

            window.ShowDialog(); //Wenn sich ShowDialog schließt wird der drrauf folgende untere Code aufgerufen.
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            //Wenn Details Windows geschlossen wurde -> Mitglieder neu Laden
            Trace.WriteLine("Window closed");
            model.Reload(); // Daten aus der Datenbank neu laden, wenn mitglied gespeichert wurde dann ist es jetzt aktualisiert.
            MitgliederListe = new ObservableCollection<Mitglied>(model.GetMitglieder()); //Hiermit werden die aktualisierten Daten angezeigt. 
        }

        private void OpenAddMitgliedWindow(Object obj)
        {
            Trace.WriteLine("OpenAddMitgliedWindow clicked");
            HinzufuegenWindow window = new HinzufuegenWindow();
            window.Closing += Window_Closing;
            window.ShowDialog();
        }

        private void DeleteMitglied(Object obj)
        {
            
            Trace.WriteLine("DeleteMitglied clicked");
            if(SelectedMitglied == null) 
            {
                Trace.WriteLine("Kein Mitglied ausgewählt");
                return;
            }
            //Fragen ob auch wirklich gelöscht werden soll?
            MessageBoxResult result = MessageBox.Show(SelectedMitglied.Vorname + " und alle seine Rechnungen löschen?", "Bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                model.DeleteMitglied(SelectedMitglied.Id);
                MitgliederListe = new ObservableCollection<Mitglied>(model.GetMitglieder());
            }

        }

        private void FilterMembers()
        {
            //Searchtext über binding
            string Suchwort = this.SearchText.Trim().ToLower();

            Trace.WriteLine("Suchtext geändert: " + Suchwort);
            if (string.IsNullOrEmpty(Suchwort))
            {
                MitgliederListe = new ObservableCollection<Mitglied>(this.model.GetMitglieder());
                return;
            }

            ObservableCollection<Mitglied> filteredList = new();

            foreach (Mitglied m in this.model.GetMitglieder())
            {
                //Ignoriert Großbuchstaben
                string name = m.Vorname.ToLower() + " " + m.Nachname.ToLower();
                if (name.Contains(Suchwort))
                {
                    filteredList.Add(m);
                }
            }
            this.MitgliederListe = filteredList;
        }
    }
}
