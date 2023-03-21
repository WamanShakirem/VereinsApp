using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp.Models
{
    internal class VereinsKontext : DbContext
    {
        public virtual DbSet<Mitglied> Mitglieder { get; set; } = null!;
        public virtual DbSet<Rechnung> Rechnungen { get; set; } = null!;

        string _constring = null!;

        public VereinsKontext(string _constring)
        {
            this._constring = _constring;   
        }

       /*Wenn ein Context erstellt wird ruft er automatisch diese Methode OnConfiguring auf.
        * UseSqlServer ist die Verbindung
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // wenn der richtige Construktor verwendet wurde
                if (_constring != null)
                    optionsBuilder.UseSqlServer(_constring);
            }
        }

        //Hier wird jetzt die Konfiguration der Datenbank Tabellen(Personendaten) und Spalten festgelegt.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitglied>(entity => 
            {
                entity.ToTable("Personendaten");
                //entity.Property(e => e.Telefonnummer).HasColumnName("Telefon");
            });
            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.ToTable("Rechnung");
            });
        }

        
    }
}
