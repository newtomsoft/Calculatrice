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
            operationCourante = plus;
            virgule = false;
            nb0 = 0;
        }

        private void ClearZero()
        {
            zoneResult.Text = "";

        }

        private void Button_0(object sender, RoutedEventArgs e)
        {
            if (!virgule)
                nombreCourant *= 10;
            else
            {
                nb0++;
                //TODO
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_1(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 1;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 1*Math.Pow(10,-nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_2(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 2;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 2 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 3;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 3 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 4;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 4 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_5(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 5;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 5 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_6(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 6;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 6 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_7(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 7;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 7 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_8(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 8;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 8 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }
        private void Button_9(object sender, RoutedEventArgs e)
        {
            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + 9;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + 9 * Math.Pow(10, -nb0);
            }
            zoneResult.Text = nombreCourant.ToString();
        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            zoneResult.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = plus;
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
            operationCourante = plus;
            virgule = false;
            nb0 = 0;
        }

        private void Button_virgule(object sender, RoutedEventArgs e)
        {
            virgule = true;
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

            zoneResult.Text = nombreStocke.ToString();
            nombreCourant = 0;
        }
    }
}
