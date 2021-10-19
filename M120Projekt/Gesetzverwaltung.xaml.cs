using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Gesetzverwaltung.xaml
    /// </summary>
    public partial class Gesetzverwaltung : UserControl
    {
        public Gesetzverwaltung()
        {
            InitializeComponent();
            istNeu();
            
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
        }
        public Zustand meinZustand = Zustand.neuesGesetz;
        private Gesetzliste gesetzliste = new Gesetzliste();
        private Parlament parlament = new Parlament();
        private void istNeu()
        {
            if (!gesetzliste.neuesGesetz)
            {
                meinZustand = Zustand.gesetzInfo;
            }
        }
        private List<string> textFelder = new List<string>();
        private void txtTitel_TextChanged(object sender, TextChangedEventArgs e)
        {
            meinZustand = Zustand.bestaetigungOffen;
        }



        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (parlament.mehrheit) {
                lblMehrheit.Content = "JA";
            } else {
                lblMehrheit.Content = "NEIN";
            };
            meinZustand = Zustand.speichernOffen;
        }

        private void txtBeschreibung_TextChanged(object sender, TextChangedEventArgs e)
        {
            meinZustand = Zustand.bestaetigungOffen;

        }

        private void cbSektor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            meinZustand = Zustand.bestaetigungOffen;
        }

        private void sliLinksRechts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            meinZustand = Zustand.bestaetigungOffen;
        }

        private void btnDeleteContent_Click(object sender, RoutedEventArgs e)
        {
            dpBehandlung.Text = "";
            sliLinksRechts.Value = 5;
            cbSektor.Text = "";
            txtBeschreibung.Text = "";
            txtTitel.Text = "";
            lblMehrheit.Content = "";
        }

        private void btnErfassen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void imgZurueck_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgLoeschen_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void dpBehandlung_CalendarClosed(object sender, RoutedEventArgs e)
        {
            meinZustand = Zustand.bestaetigungOffen;
        }
    }
}
