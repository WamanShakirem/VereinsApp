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

namespace VereinsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection Datenbankverbindung = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;Integrated Security = True; Connect Timeout = 5");


        public MainWindow()
        {
            InitializeComponent();

            //Datenbankverbindung herstellen
            Datenbankverbindung.Open();

            string query = "select * from Personendaten";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            PersonenDatenGrid.DataContext = dataSet;
            PersonenDatenGrid.ItemsSource = dataSet.Tables[0].DefaultView;


            Datenbankverbindung.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
