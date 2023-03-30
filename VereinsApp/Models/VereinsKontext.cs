using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    public class VereinsKontext : DbContext
    {
        private static string _constring = @"
            Data Source = (LocalDB)\MSSQLLocalDB; 
            AttachDbFilename=C:\Users\schwa\OneDrive\Dokumente\VereinsApp.mdf;
            Integrated Security = True;
            Connect Timeout = 5";

        public virtual DbSet<Mitglied> Mitglieder { get; set; } = null!;
        public virtual DbSet<Rechnung> Rechnungen { get; set; } = null!;

        public VereinsKontext()
        {

        }

       /*Wenn ein Context erstellt wird ruft er automatisch diese Methode OnConfiguring auf.
        * UseSqlServer ist die Verbindung
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Wenn der richtige Konstruktor verwendet wurde
                if (_constring != null)
                    optionsBuilder.UseSqlServer(_constring);
            }
        }

        //Hier wird jetzt die Konfiguration der Datenbank Tabellen(Personendaten) und Spalten festgelegt.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Mitglied>(entity => 

            {
                //entity.ToTable("Personendaten");
            });
            
            //Beziehung zwischen Mitglied on Model definieren.
            modelBuilder.Entity<Mitglied>()
                .HasMany(m => m.RechnungListe) //Ein Mitglied hat 0...n Rechnungen in der Rechungsliste
                .WithOne(r => r.Mitglied) //Eine Rechnung hat ein Mitglied
                .HasForeignKey(r => r.MitgliedId) // Eine Rechnung hat ein Mitgliedid als fremdschlüssel
                .OnDelete(DeleteBehavior.Cascade); // On Delelte alle Rechnungen löschen
            */
            /*
            modelBuilder.Entity<Rechnung>(entity =>
            {
                //entity.ToTable("Rechnung");
                
            });*/
        }

        
    }
}
