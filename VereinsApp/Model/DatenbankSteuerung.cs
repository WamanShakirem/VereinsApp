using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Alle CRUD Funktionen für die Datenbank
 * Create
 * Read
 * Update
 * Delete
*/

namespace VereinsApp.Model
{
    public class DatenbankSteuerung
    {
        private static string datenbankString = @"
            Data Source = (LocalDB)\MSSQLLocalDB; 
            AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;
            Integrated Security = True;
            Connect Timeout = 5";

        private SqlConnection Datenbankverbindung = new SqlConnection(datenbankString);
        public List<Mitglied> mitgliederListe = new List<Mitglied>();
        public List<Rechnung> rechnungsListe = new List<Rechnung>();

        public DatenbankSteuerung()
        {
            //Hier ist es notwendig die Methodennamen anzugeben um diese dann auch ausführen zu können. 
            LoadMitglieder();
            LoadRechnungen();
        }

        //------Mitglied CRUD Funktionnen------
        private void LoadMitglieder()
        {
            
            //Datenbankverbindung herstellen
            Datenbankverbindung.Open();

            //Durch das "*" Symbol werden ALLE Mitglieder aus der Tabelle Personendaten geholt.
            string query = "SELECT * FROM Personendaten";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            //Die Mitglieder aus der Tabelle "Personendaten" werden dann in das DataSet gespeichert.
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //Mit dieser Zeile wird eine leere Liste von "Mitgliedern" erstellt die später mit Daten befüllt werden.
            List<Mitglied> neueMitgliederliste = new List<Mitglied>();

            //Hier wird jede Datenbankzeile zu einem Objekt der Klasse Mitglied umwandeln.
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Mitglied m = new Mitglied(row);
                neueMitgliederliste.Add(m);
            }

            mitgliederListe = neueMitgliederliste;
            Datenbankverbindung.Close();
        }

        public bool AddMitglied(string vorname, string nachname, DateTime geburtsdatum, string adresse, int plz, string ort, string tel, string email, DateTime beitrittsdatum, string mitgliedschaftskategorie, string bezahlmethode, string notiz)
        {
            //Mit diesem SQL Code werden Werte in die Datenbanktabelle Personendaten gespeichert.
            
            
            string query = @"
                INSERT INTO Personendaten
                (Vorname, Nachname, Geburtsdatum, Adresse, PLZ, Ort, Telefon, EMail, Beitrittsdatum, Mitgliedschaftskategorie, Bezahlmethode, Notiz)
                VALUES (@Vorname, @Nachname, @Geburtsdatum, @Adresse, @PLZ, @Ort, @Telefon, @EMail, @Beitrittsdatum,
                        @Mitgliedschaftskategorie, @Bezahlmethode, @Notiz
                )
                ";
            SqlCommand command = new SqlCommand(query, Datenbankverbindung);
            command.Parameters.AddWithValue("@Vorname", vorname);
            command.Parameters.AddWithValue("@Nachname", nachname);
            command.Parameters.AddWithValue("@Geburtsdatum", geburtsdatum);
            command.Parameters.AddWithValue("@Adresse", adresse);
            command.Parameters.AddWithValue("@PLZ", plz);
            command.Parameters.AddWithValue("@Ort", ort);
            command.Parameters.AddWithValue("@Telefon", tel);
            command.Parameters.AddWithValue("@EMail", email); 
            command.Parameters.AddWithValue("@Beitrittsdatum", beitrittsdatum);
            command.Parameters.AddWithValue("@Mitgliedschaftskategorie", mitgliedschaftskategorie);
            command.Parameters.AddWithValue("@Bezahlmethode", bezahlmethode);
            command.Parameters.AddWithValue("@Notiz", notiz);
            try
            {
                Datenbankverbindung.Open();
                command.ExecuteNonQuery();
                Datenbankverbindung.Close();

                /*Nachdem ein neues Mitglied erfolgreich hinzugefügt wurde wird die Liste der Personendaten aktualisiert
                 * und ein True wird ausgegeben*/
                LoadMitglieder();

                return true;
            } catch
            {
                return false;
            }
        }

        public bool DeleteMitglied(int Id)
        {
            string query = @"
                DELETE FROM Personendaten
                WHERE Id = @Id
            ";
            SqlCommand command = new SqlCommand(query, Datenbankverbindung);
            command.Parameters.AddWithValue("@Id", Id);
            
            try
            {
                Datenbankverbindung.Open();
                //Hier wird ausgegeben wieviele Zeilen aus der Datenbank gelöscht wurden.
                int anzahl_deleted = command.ExecuteNonQuery();
                Datenbankverbindung.Close();

                /*Wenn die Anzahl der gelöschten Zeilen größer als 0 ist wird die LoadMitglieder(); Methode aufgerufen.
                Wenn die Anzahl der gelöschten Zeilen gleich 0 ist wird ein False zurückgegeben.*/
                Console.WriteLine(anzahl_deleted + " Zeilen wurden gelöscht.");
                if( anzahl_deleted == 0 ) { 
                    return false; 
                }

                LoadMitglieder();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveMitglied(Mitglied m)
        {
            string query = @"
                UPDATE Personendaten SET 
                    Vorname = @Vorname,
                    Nachname = @Nachname,
                    Geburtsdatum = @Geburtsdatum,
                    Adresse = @Adresse,
                    PLZ = @PLZ,
                    Ort = @Ort,
                    Telefon = @Telefon,
                    EMail = @Email,
                    Beitrittsdatum = @Beitrittsdatum,
                    Mitgliedschaftskategorie = @Mitgliedschaftskategorie,
                    Bezahlmethode = @Bezahlmethode,
                    Notiz = @Notiz
                WHERE Id = @Id
            ";
            SqlCommand command = new SqlCommand(query, Datenbankverbindung);

            
            command.Parameters.AddWithValue("@Id", m.Id);
            command.Parameters.AddWithValue("@Vorname", m.Vorname);
            command.Parameters.AddWithValue("@Nachname", m.Nachname);
            command.Parameters.AddWithValue("@Geburtsdatum", m.Geburtsdatum);
            command.Parameters.AddWithValue("@Adresse", m.Adresse);
            command.Parameters.AddWithValue("@PLZ", m.Plz);
            command.Parameters.AddWithValue("@Ort", m.Ort);
            command.Parameters.AddWithValue("@Telefon", m.Tel);
            command.Parameters.AddWithValue("@EMail", m.Email);
            command.Parameters.AddWithValue("@Beitrittsdatum", m.Beitrittsdatum);
            command.Parameters.AddWithValue("@Mitgliedschaftskategorie", m.Mitgliedschaftskategorie);
            command.Parameters.AddWithValue("@Bezahlmethode", m.Bezahlmethode);
            command.Parameters.AddWithValue("@Notiz", m.Notiz);

            try
            {
                Datenbankverbindung.Open();
                command.ExecuteNonQuery();
                Datenbankverbindung.Close();

                LoadMitglieder();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveMitglieder()
        {
            //Jedes einzelne Mitglied in die Datenbank Speichern
            foreach(Mitglied m in mitgliederListe)
            {
                SaveMitglied(m);
            }
            return true;
        }

        //------Rechnung CRUD Funktionnen------

        private void LoadRechnungen()
        {
            // Datenbankverbindung herstellen
            Datenbankverbindung.Open();

            string query = "SELECT * FROM Rechnung";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Datenbankverbindung);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            List<Rechnung> neueRechnungsliste = new List<Rechnung>();
            //Hier soll jede Datenbank Zeile zu einem Objekt der Klasse Rechnung umgewandelt werden.
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Rechnung r = new Rechnung(row);
                neueRechnungsliste.Add(r);
            }

            rechnungsListe = neueRechnungsliste;
            Datenbankverbindung.Close();
        }

        public bool AddRechnung(int Id, DateTime Bezahldatum, float Betrag, int MitgliedId)
        {
            string query = @"
        INSERT INTO Rechnung
        (Id, Bezahldatum, Betrag, MitgliedId)
        VALUES (@Id, @Bezahldatum, @Betrag, @MitgliedId)
        ";
            SqlCommand command = new SqlCommand(query, Datenbankverbindung);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Bezahldatum", Bezahldatum);
            command.Parameters.AddWithValue("@Betrag", Betrag);
            command.Parameters.AddWithValue("@MitgliedId", MitgliedId);

            try
            {
                Datenbankverbindung.Open();
                command.ExecuteNonQuery();
                Datenbankverbindung.Close();

                LoadRechnungen();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRechnung(int Id)
        {
            {
                string query = @"
        DELETE FROM Rechnung
        WHERE Id = @Id
    ";
                SqlCommand command = new SqlCommand(query, Datenbankverbindung);
                command.Parameters.AddWithValue("@Id", Id);

                try
                {
                    Datenbankverbindung.Open();
                    int anzahl_deleted = command.ExecuteNonQuery();
                    Datenbankverbindung.Close();

                    Console.WriteLine(anzahl_deleted + " Zeilen wurden gelöscht.");
                    if (anzahl_deleted == 0)
                    {
                        return false;
                    }

                    LoadRechnungen();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveRechnung(Rechnung r)
        {
            string query = @"
                UPDATE Rechnung SET 
                    Bezahldatum = @Bezahldatum,
                    Betrag = @Betrag,
                    MitgliedId = @MitgliedId,
                WHERE Id = @Id
            ";
            SqlCommand command = new SqlCommand(query, Datenbankverbindung);


            command.Parameters.AddWithValue("@Id", r.Id);
            command.Parameters.AddWithValue("@Bezahldatum", r.Bezahldatum);
            command.Parameters.AddWithValue("@Betrag", r.Betrag);
            command.Parameters.AddWithValue("@MitgliedId", r.MitgliedId);
            try
            {
                Datenbankverbindung.Open();
                command.ExecuteNonQuery();
                Datenbankverbindung.Close();

                LoadRechnungen();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool SaveRechnungen()
        {
            //Jede einzelne Rechnung in die Datenbank Speichern
            //Für jedes einzelne Objekt in der Rechnungsliste wird die SaveRechnung aufgerufen. 
            foreach (Rechnung r in rechnungsListe)
            {
                SaveRechnung(r);
            }
            return true;
        }
    
    }

}
