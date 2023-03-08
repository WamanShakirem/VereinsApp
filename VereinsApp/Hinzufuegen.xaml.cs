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
using VereinsApp.Model;

namespace VereinsApp
{
    /// <summary>
    /// Interaktionslogik für Hinzufuegen.xaml
    /// </summary>
    public partial class Hinzufuegen : Window
    {
        private List<Mitglied> mitgliederliste = new List<Mitglied>();

        public Hinzufuegen(List<Mitglied> mitgliederliste)
        {
            InitializeComponent();
            this.mitgliederliste = mitgliederliste;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_hinzufuegen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
