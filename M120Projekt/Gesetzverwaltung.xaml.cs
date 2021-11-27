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
            btnConfirm.IsEnabled = false;
            maxDesc.Visibility = Visibility.Hidden;
            maxTitel.Visibility = Visibility.Hidden;
            parent.meinZustand = MainWindow.Zustand.gesetzInfo;
        }
        private MainWindow parent;
        private Data.Gesetz gesetz;
        public bool mehrheit;
        public DateTime date;
        private bool neuesGesetz;

        private void changedValue()
        {
            txtTitel.Background = Brushes.White;
            maxTitel.Visibility = Visibility.Hidden;
            minTitel.Visibility = Visibility.Hidden;
            txtBeschreibung.Background = Brushes.White;
            maxDesc.Visibility = Visibility.Hidden;
            minDesc.Visibility = Visibility.Hidden;
            valuesector.Visibility = Visibility.Hidden;
            parent.meinZustand = MainWindow.Zustand.bestaetigungOffen;
            btnConfirm.IsEnabled = true;
            btnErfassen.IsEnabled = false;
               
                if (txtTitel.Text.Length > 30)
                {
                    txtTitel.Background = Brushes.Red;
                    maxTitel.Visibility = Visibility.Visible;
                    btnConfirm.IsEnabled = false;
                    btnErfassen.IsEnabled = false;

                }
                else if (txtTitel.Text.Length < 5)
                {
                    txtTitel.Background = Brushes.Red;
                    minTitel.Visibility = Visibility.Visible;
                    btnConfirm.IsEnabled = false;
                    btnErfassen.IsEnabled = false;

                }
                if (cbSektor.SelectedIndex<0)
                {
                    valuesector.Visibility = Visibility.Visible;
                    btnConfirm.IsEnabled = false;
                    btnErfassen.IsEnabled = false;

                }

                if (txtBeschreibung.Text.Length > 400)
                {
                    txtBeschreibung.Background = Brushes.Red;
                    maxDesc.Visibility = Visibility.Visible;
                    btnConfirm.IsEnabled = false;
                    btnErfassen.IsEnabled = false;
                }
                else if (txtBeschreibung.Text.Length < 10)
                {
                    txtBeschreibung.Background = Brushes.Red;
                    minDesc.Visibility = Visibility.Visible;
                    btnConfirm.IsEnabled = false;
                    btnErfassen.IsEnabled = false;

                

            }
        }

        private void txtTitel_TextChanged(object sender, TextChangedEventArgs e)
        {
            changedValue();
        }



        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            pruefeMehrheitsfaehigkeit();
            if (mehrheit) {
                lblMehrheit.Content = "JA";
            } else {
                lblMehrheit.Content = "NEIN";
            };
            parent.meinZustand = MainWindow.Zustand.speichernOffen;
            btnErfassen.IsEnabled = true;
            btnConfirm.IsEnabled = false;
        }

        private void pruefeMehrheitsfaehigkeit()
        {
            Parlament parlament = new Parlament();
            double gesetzwert = sliLinksRechts.Value;
            int jaStimmen = 0;
            foreach (Partei partei in parlament.parteien)
            {
                if(partei.linksRechts < gesetzwert+3 && partei.linksRechts > gesetzwert-3)
                {
                    jaStimmen+=partei.abgeordnete;
                }
            }
            if (jaStimmen > 100)
            {
                mehrheit = true;
            } else
            {
                mehrheit = false;
            }

        }

        private void txtBeschreibung_TextChanged(object sender, TextChangedEventArgs e)
        {
            changedValue();
            
        }

        private void cbSektor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            changedValue();
        }

        private void sliLinksRechts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changedValue();
        }

        private void btnDeleteContent_Click(object sender, RoutedEventArgs e)
        {
            dpBehandlung.SelectedDate = null;
            sliLinksRechts.Value = 5;
            cbSektor.SelectedIndex = -1;
            txtBeschreibung.Text = "";
            txtTitel.Text = "";
            lblMehrheit.Content = "";
            btnConfirm.IsEnabled = false;
            btnErfassen.IsEnabled = false;
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
            parent.meinZustand = MainWindow.Zustand.speichern;
            parent.WechsleZuListenansicht();
        }

        private void imgZurueck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            parent.WechsleZuListenansicht();
        }

        private void imgLoeschen_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Wollen Sie dieses Gesetz entfernen?", "Gesetz Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Data.Gesetz.LesenID(gesetz.GesetzID).Loeschen();
                    parent.meinZustand = MainWindow.Zustand.loeschVerifizierung;
                    parent.WechsleZuListenansicht();
                    break;
                case MessageBoxResult.No:
                    break;
            }
            
        }

        private void dpBehandlung_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dpBehandlung.SelectedDate.HasValue) {
                date = dpBehandlung.SelectedDate.Value;
            }
            changedValue();
        }
    }
}
