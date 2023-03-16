using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VereinsApp.Commands;
using VereinsApp.View;

namespace VereinsApp.ViewModel
{
    
    public class MainWindowViewModel : BaseViewModel
    {
        private List<Page> pages; //Liste mit allen Pages
        private Page _currentPage;
        
        //Das hier ermöglicht Bindings durch OnPropertyChanged call wird GUI aktualisiert
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage)); // gui wird benachrichtigt
            }
        }

        //Command erstellen für binding, gui bindet sich an dieses Command
        public ICommand SideMenuClickCommand { get; private set; }

        public MainWindowViewModel()
        {
            SideMenuClickCommand = new RelayCommand(SideMenuClick); //Command eine Zielfunktion zuweisen

            //Hier werden die Seiten für die GUI erstellt
            pages = new List<Page>
            {
                new UebersichtSeite(),
                new EmailSeite(),
                new StatistikSeite(),
            };
            CurrentPage = pages[0];
        }

        //wird durch command aufgerufen
        //object obj ist der CommandParamter aus der view.xaml
        private void SideMenuClick(object obj)
        {
            string s = (string)obj; //object zu string umwandeln
            int index = int.Parse(s);

            //Wird in Ausgabe angezeigt weil es keine Konsole gibt geht Console.WriteLine nicht
            Trace.WriteLine("Menu clicked");
            
            Trace.WriteLine(index);

            //Die GUI hat sich an die CurrentPage gebindet und der weisen wir eine neue Page zu.
            CurrentPage = pages[index];
        }
    }
}
