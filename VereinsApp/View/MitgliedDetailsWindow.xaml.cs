using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VereinsApp.Models;
using VereinsApp.ViewModel;

namespace VereinsApp.View
{
    /// <summary>
    /// Interaktionslogik für MitgliedDetailsWindow.xaml
    /// </summary>
    public partial class MitgliedDetailsWindow : Window
    {
        MitgliedDetailsViewModel viewModel;

        public MitgliedDetailsWindow(Mitglied SelectedMitglied)
        {
            InitializeComponent();
            this.viewModel = new MitgliedDetailsViewModel(SelectedMitglied); //viewmodel erstellen
            DataContext = this.viewModel; //hiermit ermöglicht man die Bindings
        }


    }
}
