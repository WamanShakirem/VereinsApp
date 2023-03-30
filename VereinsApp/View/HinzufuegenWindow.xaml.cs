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
    /// Interaktionslogik für HinzufuegenWindow.xaml
    /// </summary>
    public partial class HinzufuegenWindow : Window
    {
        public HinzufuegenWindow()
        {
            InitializeComponent();
            DataContext = new HinzufuegenViewModel();
        }

    }
}
