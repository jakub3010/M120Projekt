using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Gesetz
    {
        #region Datenbankschicht
        [Key]
        public Int64 GesetzID { get; set; }
        [Required]
        public String Titel { get; set; }
        [Required]
        public String Beschreibung { get; set; }
        [Required]
        public String Sektor { get; set; }
        [Required]
        public double Links_Rechts { get; set; }
        [Required]
        public DateTime Behandlungsdatum { get; set; }
        [Required]
        public Boolean istMehrheitsfaehig { get; set; }
        #endregion
        #region Applikationsschicht
        public Gesetz() { }

        public static List<Gesetz> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Gesetz select record).ToList();
            }
        }
        public static Gesetz LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.Gesetz where record.GesetzID == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Gesetz> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Gesetz where record.Titel == suchbegriff select record).ToList();
            }
        }
        public static List<Gesetz> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Gesetz where record.Titel.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Titel == null || this.Titel == "") this.Titel = "leer";
            if (this.Behandlungsdatum == null) this.Behandlungsdatum = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Gesetz.Add(this);
                db.SaveChanges();
                return this.GesetzID;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.GesetzID;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return GesetzID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
