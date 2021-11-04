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
    /// Interaktionslogik für Parlament.xaml
    /// </summary>
    public partial class Parlament : UserControl
    {
        public Parlament()
        {
            InitializeComponent();
            parteien = erstelleParteien();
        }
        public List<Partei> parteien;
        private List<Partei> erstelleParteien()
        {
            List <Partei> parteiListe = new List<Partei>();
            parteiListe.Add(new Partei("PdA",-5,10));
            parteiListe.Add(new Partei("Grüne", -3, 40));
            parteiListe.Add(new Partei("SP", -2, 45));
            parteiListe.Add(new Partei("EVP", -1, 10));
            parteiListe.Add(new Partei("glp", 0, 15));
            parteiListe.Add(new Partei("Mitte", 1, 20));
            parteiListe.Add(new Partei("FDP", 3, 15));
            parteiListe.Add(new Partei("SVP", 4, 40));
            parteiListe.Add(new Partei("EDU", 5, 5));
            return parteiListe;
        }
    }
}
