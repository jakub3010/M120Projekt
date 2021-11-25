using System.Windows;
using System.ComponentModel;

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
            speichern,
            speichernOffen,
            zurueckZuGesetzliste
        }
        public Zustand meinZustand = Zustand.neuesGesetz;
        private void Gesetzverwaltung_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnGesetzliste_Click(object sender, RoutedEventArgs e)
        {
            if (meinZustand == Zustand.bestaetigungOffen || meinZustand == Zustand.speichernOffen)
            {
                MessageBoxResult result = MessageBox.Show("Wollen Sie die Änderungen verwerfen?", "Zu Gesetzliste", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Platzhalter.Content = new Gesetzliste(this);
                        meinZustand = Zustand.zurueckZuGesetzliste;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            } else
            {
                Platzhalter.Content = new Gesetzliste(this);
            }
            
        }

        private void btnParteien_Click(object sender, RoutedEventArgs e)
        {

        }
        public void WechsleZuListenansicht()
        {
            if (meinZustand == Zustand.bestaetigungOffen || meinZustand == Zustand.speichernOffen)
            {
                MessageBoxResult result = MessageBox.Show("Wollen Sie die Änderungen verwerfen?", "Zu Gesetzliste", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Platzhalter.Content = new Gesetzliste(this);
                        meinZustand = Zustand.zurueckZuGesetzliste;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                Platzhalter.Content = new Gesetzliste(this);
            }
        }
        public void WechsleZuEinzelansicht(long artikelId)
        {
            Platzhalter.Content = new Gesetzverwaltung(this, artikelId);
        }

        private void btnBeenden_Click(object sender, RoutedEventArgs eventArgs)
        {
            Close();
        }
 

        private void OnClosing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie das Programm beenden", "Programm beenden", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            } else
            {
                e.Cancel = false;
            }
        }
    }
}
