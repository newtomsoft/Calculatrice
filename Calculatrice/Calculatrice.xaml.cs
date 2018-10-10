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

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Calc : Window
    {
        private static string plus = "+";
        private static string moins = "-";
        private static string multiplier = "*";
        private static string diviser = "/";
        private static string rien = "";

        private double nombreCourant;
        private double nombreStocke;
        string operationCourante;
        private bool virgule;
        private int nb0;


        public Calc()
        {
            InitializeComponent();

            zoneResult.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = rien;
            virgule = false;
            nb0 = 0;
        }

        private void ClearZero()
        {
            zoneResult.Text = "";

        }

        private void BoutonChiffre(object sender, RoutedEventArgs e)
        {
            var t = (Button)sender;
            int chiffre = Int32.Parse(t.Content.ToString());

            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + chiffre;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + chiffre * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            zoneResult.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = rien;
            virgule = false;
            nb0 = 0;
        }

        private void Button_plus(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = plus;
            virgule = false;
            nb0 = 0;
        }

        private void Button_moins(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = moins;
            virgule = false;
            nb0 = 0;
        }

        private void Button_multiplier(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = multiplier;
            virgule = false;
            nb0 = 0;
        }

        private void Button_diviser(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = diviser;
            virgule = false;
            nb0 = 0;
        }

        private void Button_egal(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = rien;
            virgule = false;
            nb0 = 0;
        }

        private void Button_virgule(object sender, RoutedEventArgs e)
        {
            virgule = true;
        }

        private void Button_plusmoins(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombreCourant = nombreCourant * -1;
            zoneResult.Text = nombreCourant.ToString();
        }

        private void Calcul()
        {
            if (operationCourante == plus)
                nombreStocke += nombreCourant;
            else if (operationCourante == moins)
                nombreStocke -= nombreCourant;
            else if (operationCourante == multiplier)
                nombreStocke *= nombreCourant;
            else if (operationCourante == diviser)
                nombreStocke /= nombreCourant;
            else if (operationCourante == rien)
                nombreStocke = nombreCourant;

            zoneResult.Text = nombreStocke.ToString();
            nombreCourant = 0;
        }



        private void Button_pourcent(object sender, RoutedEventArgs e)
        {
            nombreCourant = nombreStocke * nombreCourant / 100;
            zoneResult.Text = nombreCourant.ToString();
        }

    }
}
