using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VereinsApp.Model;

namespace VereinsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection Datenbankverbindung = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;Integrated Security = True; Connect Timeout = 5");
        private List<Mitglied> mitgliederliste = new List<Mitglied>();

        public MainWindow()
        {
            InitializeComponent();

            load_database();
            update_grid(mitgliederliste);
        }

        private void load_database()
        {
            //Datenbankverbindung herstellen
            Datenbankverbindung.Open();

            string query = "select * from Personendaten";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            
            //jede datanbank row zu einem objekt der Klasse Mitglied umwandeln
            foreach(DataRow row in dataSet.Tables[0].Rows) {
                Mitglied m = new Mitglied(row);
                mitgliederliste.Add(m);
            }

            Datenbankverbindung.Close();
        }
        
        private void update_grid(List<Mitglied> mitgliederliste) {
            PersonenDatenGrid.ItemsSource = mitgliederliste;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            string filter_wort = searchBox.Text.Trim().ToLower();
            List<Mitglied> filtered_list = new List<Mitglied>();

            if(filter_wort == "") {
                update_grid(mitgliederliste);
                return;
            }

            //alle mitglieder durchsuchen
            foreach(Mitglied m in mitgliederliste ) {
                //ignoriere Großschreibung
                string name = m.vorname.ToLower() + " " + m.nachname.ToLower();
                if(name.Contains(filter_wort)) {
                    filtered_list.Add(m);
                }
            }
            update_grid(filtered_list);
        }

        //Neues Fenster wird geöffnet um ein neues Mitglied hinzufügen zu können.
        private void btn_add_mitglied_Click(object sender, RoutedEventArgs e)
        {
            Hinzufuegen window = new Hinzufuegen(mitgliederliste);
            window.Show();


        }

        
        private void btn_change_mitglied_Click(object sender, RoutedEventArgs e)
        {
            DataSet dataSet = new DataSet();
            Aendern window = new Aendern(dataSet);
            window.Show();
        }


        private void btn_uebersicht_Click(object sender, RoutedEventArgs e)
        {
            Uebersicht uebersicht = new Uebersicht(mitgliederliste);
            uebersicht.Show();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_email_senden_Click(object sender, RoutedEventArgs e)
        {
            E_Mail window = new E_Mail();
            window.Show();
        }
    }
}
