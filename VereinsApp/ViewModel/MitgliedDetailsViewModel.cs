using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                OnPropertyChanged(nameof(Mitglied));
            }
        }

        public ICommand SpeichernClickCommand { get; private set; }


        public MitgliedDetailsViewModel(Mitglied SelectedMitglied) 
        {
            model = new Model();
            _selectedMitglied = SelectedMitglied;
            Trace.WriteLine("Mitglied Details: " + SelectedMitglied.Vorname);

            SpeichernClickCommand = new RelayCommand(MitgliedSpeichern); //Command eine Zielfunktion zuweisen
        }

        private void MitgliedSpeichern(Object obj)
        {
            Trace.WriteLine("Speicherbutton wurde geklickt.");

            model.UpdateMitglied(SelectedMitglied);
        }
    }
}
