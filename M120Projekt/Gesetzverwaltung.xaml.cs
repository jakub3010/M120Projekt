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
        public Gesetzverwaltung(MainWindow parent, long id)
        {
            this.parent = parent;
            InitializeComponent();
            Console.WriteLine(parent.meinZustand);
            if (parent.meinZustand == MainWindow.Zustand.gesetzInfo)
            {
                gesetz = Data.Gesetz.LesenID(id);
                imgLoeschen.Visibility = Visibility.Visible;
            } else
            {
                gesetz = new Data.Gesetz();
                neuesGesetz = true;
                imgLoeschen.Visibility = Visibility.Hidden;
            }
            dpBehandlung.SelectedDate = gesetz.Behandlungsdatum;
            sliLinksRechts.Value = gesetz.Links_Rechts;
            cbSektor.Text = gesetz.Sektor;
            txtBeschreibung.Text = gesetz.Beschreibung;
            txtTitel.Text = gesetz.Titel;
            lblMehrheit.Content = "";
        }
        private MainWindow parent;
        private Data.Gesetz gesetz;
        private Parlament parlament = new Parlament();
        public bool mehrheit;
        public DateTime date;
        private bool changed;
        private bool neuesGesetz;

        private void changedValue()
        {
            if (changed){
                if (cbSektor.Text != null && txtBeschreibung.Text != null && txtTitel.Text != null && dpBehandlung.SelectedDate != null)
                {
                    parent.meinZustand = MainWindow.Zustand.bestaetigungOffen;
                    btnConfirm.IsEnabled = true;
                }
            }
        }

        private void txtTitel_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
            changedValue();
        }



        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (gesetz.istMehrheitsfaehig) {
                lblMehrheit.Content = "JA";
            } else {
                lblMehrheit.Content = "NEIN";
            };
            parent.meinZustand = MainWindow.Zustand.speichernOffen;
            btnErfassen.IsEnabled = true;
            btnConfirm.IsEnabled = false;
        }

        private void txtBeschreibung_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
            changedValue();
        }

        private void cbSektor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            changed = true;
            changedValue();
        }

        private void sliLinksRechts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changedValue();
            changed = true;
        }

        private void btnDeleteContent_Click(object sender, RoutedEventArgs e)
        {
            dpBehandlung.SelectedDate = null;
            sliLinksRechts.Value = 5;
            cbSektor.Text = "";
            txtBeschreibung.Text = "";
            txtTitel.Text = "";
            lblMehrheit.Content = "";
            btnConfirm.IsEnabled = false;
        }

        private void btnErfassen_Click(object sender, RoutedEventArgs e)
        {
            Gesetzliste gesetzliste = new Gesetzliste(parent);
            gesetz.Titel = txtTitel.Text;
            gesetz.Behandlungsdatum = date;
            gesetz.Beschreibung = txtBeschreibung.Text;
            gesetz.Sektor = cbSektor.Text;
            gesetz.Links_Rechts = sliLinksRechts.Value;
            gesetz.istMehrheitsfaehig = mehrheit;
            if (neuesGesetz)
            {
                gesetz.Erstellen();
                gesetzliste.gesetze.Add(gesetz);
            } else {
                gesetz.Aktualisieren();
            }
            parent.WechsleZuListenansicht();
        }

        private void imgZurueck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            parent.WechsleZuListenansicht();
        }

        private void imgLoeschen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Data.Gesetz.LesenID(gesetz.GesetzID).Loeschen();
            parent.WechsleZuListenansicht();
        }

        private void dpBehandlung_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dpBehandlung.SelectedDate.HasValue) {
                date = dpBehandlung.SelectedDate.Value;
            }
            changed = true;
            changedValue();
        }
    }
}
