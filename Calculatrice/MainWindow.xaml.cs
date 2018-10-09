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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal nombre;
        public decimal nombreStocke;
        string operationCourante;

        static string plus = "+";
        static string moins = "-";
        static string multiplier = "*";
        static string diviser = "/";


        public MainWindow()
        {
            InitializeComponent();

            zoneResult.Text = "0";
            nombre = 0;
            nombreStocke = 0;
            operationCourante = plus;
        }

        private void ClearZero()
        {
            zoneResult.Text = "";

        }

        private void Button_0(object sender, RoutedEventArgs e)
        {
            if (nombre != 0)
            {
                nombre *= 10;
                zoneResult.Text = nombre.ToString();
            }

        }
        private void Button_1(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 1;
            zoneResult.Text = nombre.ToString();


        }
        private void Button_2(object sender, RoutedEventArgs e)
        {

            ClearZero();
            nombre = nombre * 10 + 2;
            zoneResult.Text = nombre.ToString();


        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 3;
            zoneResult.Text = nombre.ToString();

        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 4;
            zoneResult.Text = nombre.ToString();


        }
        private void Button_5(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 5;
            zoneResult.Text = nombre.ToString();


        }
        private void Button_6(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 6;
            zoneResult.Text = nombre.ToString();

        }
        private void Button_7(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 7;
            zoneResult.Text = nombre.ToString();

        }
        private void Button_8(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 8;
            zoneResult.Text = nombre.ToString();


        }
        private void Button_9(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombre = nombre * 10 + 9;
            zoneResult.Text = nombre.ToString();

        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            zoneResult.Text = "0";
            nombre = 0;
            nombreStocke = 0;
            operationCourante = plus;
        }

        private void Button_plus(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = plus;
        }
        private void Button_moins(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = moins;
        }
        private void Button_multiplier(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = multiplier;
        }
        private void Button_diviser(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = diviser;
        }

        private void Button_egal(object sender, RoutedEventArgs e)
        {
            Calcul();
            operationCourante = plus;
        }

        private void Button_virgule(object sender, RoutedEventArgs e) { }

        private void Calcul()
        {
            if (operationCourante == plus)
                nombreStocke += nombre;
            else if (operationCourante == moins)
                nombreStocke -= nombre;
            else if (operationCourante == multiplier)
                nombreStocke *= nombre;
            else if (operationCourante == diviser)
                nombreStocke /= nombre;

            zoneResult.Text = nombreStocke.ToString();
            nombre = 0;
        }
    }
}
