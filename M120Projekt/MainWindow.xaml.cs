using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public enum Zustand
        {
            neuesGesetz,
            gesetzInfo,
            bestaetigungOffen,
            loeschVerifizierung,
            speichernOderMenu,
            speichernOffen,
            speichernOderZurueck,
            zurueckZuGesetzliste
        }
        public Zustand meinZustand = Zustand.neuesGesetz;
        private void Gesetzverwaltung_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnGesetzliste_Click(object sender, RoutedEventArgs e)
        {
            Platzhalter.Content = new Gesetzliste(this);
        }

        private void btnParteien_Click(object sender, RoutedEventArgs e)
        {

        }
        public void WechsleZuListenansicht()
        {
            Platzhalter.Content = new Gesetzliste(this);
        }
        public void WechsleZuEinzelansicht(long artikelId)
        {
            Platzhalter.Content = new Gesetzverwaltung(this, artikelId);
        }
    }
}
