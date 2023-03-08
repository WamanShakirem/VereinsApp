using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Reihenfolge der Abläufe
// 1) View registriert sich mit einer Methode beim ViewModel
// 2) Ein Benutzer gibt Zahlen ein und druckt einen Button für die Berechnung
// 3) Der Code hinter dem Button berechnet das Ergebnis 
// 4) Durch die Änderung des Ergebnis Properties wird die Methode OnPropertyChanged() aufgerufen
// 5) OnPropertyChanged() löst den Event aus => alle registrierten Methoden werden aufgerufen
// 6) View wird das entsprechende Element mit den neuen Wert gezeichnet

namespace VereinsApp.ViewModel
{
    // INotifyPropertyChanged ist ein Interface dass Benachrichtigungen auslößt wenn sich Propertys ändern
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Code Aus Beispiel Projekt
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            
            if (PropertyChanged != null)
            {
                // this ist eine Referenz auf unser Objekt
                // this zeigt auf das ViewModel
                // PropertyChangedEventArgs => damit wird der Name des geänderten Properties 
                // als Parameter mitgegeben
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
