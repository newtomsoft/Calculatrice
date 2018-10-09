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
        static string[] reponse = new string[10];
        public decimal nombre;
        public decimal nombreStocke;
        public string strNombre;
        public string strNombreStocke;
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
            strNombre = "";
            strNombreStocke = "";
            operationCourante = plus;
        }

        private void ClearZero()
        {
            zoneResult.Text = "";

        }

        private void Button_0(object sender, RoutedEventArgs e)
        {
            if (strNombre != "0")
            {
                strNombre += "0";
                zoneResult.Text = strNombre;
            }

        }
        private void Button_1(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "1";
            zoneResult.Text = strNombre;


        }
        private void Button_2(object sender, RoutedEventArgs e)
        {

            ClearZero();
            strNombre += "2";
            zoneResult.Text = strNombre;


        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "3";
            zoneResult.Text = strNombre;

        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "4";
            zoneResult.Text = strNombre;


        }
        private void Button_5(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "5";
            zoneResult.Text = strNombre;


        }
        private void Button_6(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "6";
            zoneResult.Text = strNombre;

        }
        private void Button_7(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "7";
            zoneResult.Text = strNombre;

        }
        private void Button_8(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "8";
            zoneResult.Text = strNombre;


        }
        private void Button_9(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "9";
            zoneResult.Text = strNombre;

        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            zoneResult.Text = "0";
            nombre = 0;
            nombreStocke = 0;
            strNombre = "";
            strNombreStocke = "";
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
            int nbtemp;
            if (Int32.TryParse(strNombre, out nbtemp))
                nombre = nbtemp;
            else
                nombre = 0;

            if (operationCourante == plus)
                nombreStocke += nombre;
            else if (operationCourante == moins)
                nombreStocke -= nombre;
            else if (operationCourante == multiplier)
                nombreStocke *= nombre;
            else if (operationCourante == diviser)
                nombreStocke /= nombre;

            nombre = nombreStocke;
            strNombre = nombre.ToString();
            zoneResult.Text = strNombre;
            strNombre = "";
            nombre = 0;
        }
    }
}
