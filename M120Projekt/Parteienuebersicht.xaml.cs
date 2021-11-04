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
    /// Interaktionslogik für Parteien.xaml
    /// </summary>
    public partial class Partei : UserControl
    {
        public Partei()
        {
            InitializeComponent();
        }
        static Random rnd = new Random();
        public String name;
        public int linksRechts;
        public int abgeordnete;

        public Partei(String name, int linksRechts, int abgeordnete)
        {
            this.name = name;
            this.linksRechts = linksRechts;
            this.abgeordnete = abgeordnete;
        }
    }
}
