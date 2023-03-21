using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VereinsApp.Commands;
using VereinsApp.Models;
using VereinsApp.View;

namespace VereinsApp.ViewModel
{
    public class UebersichtViewModel : BaseViewModel
    {
        private ObservableCollection<Mitglied> _mitgliederListe;
        public ObservableCollection<Mitglied> MitgliederListe
        {
            get => _mitgliederListe;
            private set
            {
                _mitgliederListe = value;
                OnPropertyChanged(nameof(MitgliederListe)); //Gui benachrichtigen beim Ersetzen der Variablen
            }
        }

        private Model model = new Model();

        //Commands erstellen
        public ICommand DetailButtonClickCommand { get; private set; }
        public ICommand AddButtonClickCommand { get; private set; }
        public ICommand DeleteButtonClickCommand { get; private set; }
        
        public Mitglied? SelectedMitglied { get; set; }

        private string _searchText;
        public string SearchText
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
            MitgliederListe = new ObservableCollection<Mitglied>(model.GetMitglieder());

            //Commands die Zielfunktion zuweisen
            DetailButtonClickCommand = new RelayCommand(OpenDetailWindow); 
            AddButtonClickCommand = new RelayCommand(OpenAddMitgliedWindow);
            DeleteButtonClickCommand = new RelayCommand(DeleteMitglied);
        }

        private void OpenDetailWindow(Object obj)
        {   
            Trace.WriteLine("OpenDetailWindow clicked");
            MitgliedDetailsWindow window = new MitgliedDetailsWindow();
            window.ShowDialog();

        }

        private void OpenAddMitgliedWindow(Object obj)
        {
            Trace.WriteLine("OpenAddMitgliedWindow clicked");
            HinzufuegenWindow window = new HinzufuegenWindow();
            window.ShowDialog();
        }

        private void DeleteMitglied(Object obj)
        {
            Trace.WriteLine("DeleteMitglied clicked");

            Trace.WriteLine(SelectedMitglied?.Vorname);
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
