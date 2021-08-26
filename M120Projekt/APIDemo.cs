using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.Gesetz klasseA1 = new Data.Gesetz();
            klasseA1.Titel = "Artikel 1";
            klasseA1.Behandlungsdatum = DateTime.Today;
            klasseA1.Beschreibung = "lorem ipsum";
            klasseA1.Sektor = "Umwelt";
            klasseA1.Links_Rechts = -3;
            klasseA1.istMehrheitsfaehig = true;
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Gesetz klasseA2 = new Data.Gesetz { Titel = "Artikel 2", istMehrheitsfaehig = true, Behandlungsdatum = DateTime.Today, Beschreibung = "Lorem impsum",Sektor = "Umwelt",Links_Rechts = -5  };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);

            Data.Gesetz klasseA3 = new Data.Gesetz { Titel = "Artikel 3", istMehrheitsfaehig = true, Behandlungsdatum = DateTime.Today, Beschreibung = "Lorem impadsdassum", Sektor = "Umwelt", Links_Rechts = 3 };
            Int64 klasseA3Id = klasseA3.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);

            Data.Gesetz klasseA4 = new Data.Gesetz { Titel = "Artikel 4", istMehrheitsfaehig = true, Behandlungsdatum = DateTime.Today, Beschreibung = "Lorem impdaddassum", Sektor = "Umwelt", Links_Rechts = 1 };
            Int64 klasseA4Id = klasseA4.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Gesetz klasseA in Data.Gesetz.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.GesetzID + " Name:" + klasseA.Titel);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Gesetz klasseA1 = Data.Gesetz.LesenID(1);
            klasseA1.Titel = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Gesetz.LesenID(4).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
    }
}
