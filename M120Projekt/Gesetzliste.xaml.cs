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
    /// Interaktionslogik für Gesetzliste.xaml
    /// </summary>
    public partial class Gesetzliste : UserControl
    {
        public List<Data.Gesetz> gesetze = new List<Data.Gesetz>();
        private MainWindow parent;
        private long gesetzId;
        private const string _format = "dd-MM-yy";

        public object convert(object value)
        {
            DateTime date = (DateTime)value;

            return date.ToString(_format);
        }


        public Gesetzliste(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            gesetzListe.ItemsSource = Data.Gesetz.LesenAlle();
            // Neu anfügen
            gesetzListe.CanUserAddRows = false;
            // Sortieren
            gesetzListe.CanUserSortColumns = true;
            // Anzeigemodus
            gesetzListe.IsReadOnly = true;
            // Auswahlvarianten
            gesetzListe.SelectionMode = DataGridSelectionMode.Single;
            gesetzListe.SelectionMode = DataGridSelectionMode.Extended;
        }


        private void btnNeuesGesetz_Click(object sender, RoutedEventArgs e)
        {
            parent.meinZustand = MainWindow.Zustand.neuesGesetz;
            parent.WechsleZuEinzelansicht(gesetzId);
        }

        private void gesetzListe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gesetzListe.SelectedItem != null)
            {
                Data.Gesetz artikel = (Data.Gesetz) gesetzListe.SelectedItem;
                gesetzId = artikel.GesetzID;
                parent.meinZustand = MainWindow.Zustand.gesetzInfo;
                parent.WechsleZuEinzelansicht(gesetzId);
            }
  
        }

        private void gesetzliste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                Data.Gesetz artikel = (Data.Gesetz)gesetzListe.SelectedItem;
                gesetzId = artikel.GesetzID;
                parent.meinZustand = MainWindow.Zustand.gesetzInfo;
                parent.WechsleZuEinzelansicht(gesetzId);
            }
        }
    }
}
