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
        public Gesetzliste()
        {
            InitializeComponent();
            //gesetzListe.ItemsSource = neuesGesetz;
        }
        public bool neuesGesetz = true; //true wenn "neues Gesetz" Button geklickt, false wenn auf bestehenden Datensatz gedrückt

        private void gesetzListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
