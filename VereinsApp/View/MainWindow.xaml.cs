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
using VereinsApp.ViewModel;

namespace VereinsApp.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        // Dem Fenster sein View Model übergeben.
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel(); //viewmodel in dem Window speichern
            DataContext = this.viewModel; //hiermit ermöglicht man die Bindings
        }
    }
}
