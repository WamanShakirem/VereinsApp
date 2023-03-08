using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace VereinsApp
{
    /// <summary>
    /// Interaktionslogik für Aendern.xaml
    /// </summary>
    public partial class Aendern : Window
    {

        private SqlConnection Datenbankverbindung = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;Integrated Security = True; Connect Timeout = 5");
        private DataRowView lastSelectedVermerksliste;
        public Aendern(DataSet dataSet)
        {
            InitializeComponent();


            Datenbankverbindung.Open();

            string query = @"
            SELECT * 
            FROM Rechnung
            WHERE MitgliedId = 1
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            DataSet dataSet1 = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            Vermerksliste.ItemsSource = dataSet.Tables[0].DefaultView;


            Datenbankverbindung.Close();

        }

        private void update_grid()
        {
            Datenbankverbindung.Open();
            string query = "select * from Vermerksliste";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            Vermerksliste.ItemsSource = dataSet.Tables[0].DefaultView;

            Datenbankverbindung.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Bezahldatum_Add_Button_Click(object sender, RoutedEventArgs e)
        {

            if (BezahlDatumTextBox.Text == "")
            {
                MessageBox.Show("Bitte trage das Bezahlsdatum ein!");
                return;
            }
            //Speichern von Datum
            DateTime bezahlDatum = DateTime.Parse(BezahlDatumTextBox.Text);

            string query = string.Format("insert into Vermerksliste (Bezahldatum) values('{0}')", bezahlDatum);
            ExecuteQuery(query);

            update_grid();
        }

        private void Bezahldatum_Bearbeiten_Button_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedVermerksliste == null)
            {
                MessageBox.Show("Bitte wähle zuerst ein Element aus.");
                return;
            }

            DateTime bezahlDatum = DateTime.Parse(BezahlDatumTextBox.Text);
            int id = Convert.ToInt32(lastSelectedVermerksliste["Id"]);

            string query = string.Format("update Vermerksliste set Bezahldatum='{0}' where Id={1}", bezahlDatum, id);
            ExecuteQuery(query);

            update_grid();
        }

        private void Bezahldatum_Loeschen_Button_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelectedVermerksliste == null)
            {
                MessageBox.Show("Bitte wähle zuerst ein Element aus.");
                return;
            }

            int selectedId = (int)lastSelectedVermerksliste["Id"];

            string query = string.Format("delete from Vermerksliste where Id = {0}", selectedId);
            ExecuteQuery(query);

            update_grid();
        }

        private void ExecuteQuery(string query)
        {
            Datenbankverbindung.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Datenbankverbindung);
            sqlCommand.ExecuteNonQuery();
            Datenbankverbindung.Close();
        }

        private void Vermerksliste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vermerksliste.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)Vermerksliste.SelectedItems[0];
                BezahlDatumTextBox.Text = row["Bezahldatum"].ToString();

                lastSelectedVermerksliste = (DataRowView)Vermerksliste.SelectedItems[0];
            }
        }
    }
}