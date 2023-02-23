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

namespace VereinsApp
{
    /// <summary>
    /// Interaktionslogik für Uebersicht.xaml
    /// </summary>
    public partial class Uebersicht : Window
    {
        private List<Mitglied> mitgliederliste = new List<Mitglied>();

        public Uebersicht(List<Mitglied> mitglieder_liste)
        {
            InitializeComponent();
            this.mitgliederliste = mitglieder_liste;
            update_grid(mitgliederliste);
        }

        private void update_grid(List<Mitglied> mitgliederliste)
        {
            PersonenDatenGrid.ItemsSource = mitgliederliste;
        }

        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            string filter_wort = searchBox.Text.Trim().ToLower();
            List<Mitglied> filtered_list = new List<Mitglied>();

            if (filter_wort == "")
            {
                update_grid(mitgliederliste);
                return;
            }

            //alle mitglieder durchsuchen
            foreach (Mitglied m in mitgliederliste)
            {
                //ignoriere Großschreibung
                string name = m.vorname.ToLower() + " " + m.nachname.ToLower();
                if (name.Contains(filter_wort))
                {
                    filtered_list.Add(m);
                }
            }
            update_grid(filtered_list);
        }
    }
}
