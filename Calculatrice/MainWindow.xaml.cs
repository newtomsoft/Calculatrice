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
            reponse[0] = "Le ciel est bleu";
            reponse[1] = "L'eau ça mouille";
            reponse[2] = "Il n'y a pas de sots métiers, il n'y a que de sottes gens";
            reponse[3] = "Patience surpasse science";
            reponse[4] = "Mieux vaut suer que trembler";
            reponse[5] = "Lorsque les canards et les oies crient et plongent dans l'eau, c'est signe de pluie";
            reponse[6] = "Quand les brebis secouent leurs cloches l'on peut dire que la pluie est proche";
            reponse[7] = "Pie dans la ferme, neige à court terme";
            reponse[8] = "A sotte demande, à folle demande, point de réponse";
            reponse[9] = "Il faut avoir deux cordes à son arc";

            zoneTexte.Text = "0";
            nombre = 0;
            nombreStocke = 0;
            strNombre = "";
            strNombreStocke = "";
            operationCourante = plus;
        }

        private void ClearZero()
        {
            zoneTexte.Text = "";

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int mIndex = rnd.Next(reponse.Length);
            //MessageBox.Show(reponse[mIndex]);
            //letexte.Text = reponse[mIndex];
        }


        private void Button_0(object sender, RoutedEventArgs e)
        {
            if (strNombre != "0")
            {
                strNombre += "0";
                zoneTexte.Text = strNombre;
            }

        }
        private void Button_1(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "1";
            zoneTexte.Text = strNombre;


        }
        private void Button_2(object sender, RoutedEventArgs e)
        {

            ClearZero();
            strNombre += "2";
            zoneTexte.Text = strNombre;


        }
        private void Button_3(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "3";
            zoneTexte.Text = strNombre;

        }
        private void Button_4(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "4";
            zoneTexte.Text = strNombre;


        }
        private void Button_5(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "5";
            zoneTexte.Text = strNombre;


        }
        private void Button_6(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "6";
            zoneTexte.Text = strNombre;

        }
        private void Button_7(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "7";
            zoneTexte.Text = strNombre;

        }
        private void Button_8(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "8";
            zoneTexte.Text = strNombre;


        }
        private void Button_9(object sender, RoutedEventArgs e)
        {
            ClearZero();
            strNombre += "9";
            zoneTexte.Text = strNombre;

        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            zoneTexte.Text = "0";
            nombre = 0;
            nombreStocke = 0;
            strNombre = "";
            strNombreStocke = "";
            operationCourante = plus;
        }

        private void Button_plus(object sender, RoutedEventArgs e)
        {
            Egal();
            operationCourante = plus;
        }

        private void Button_moins(object sender, RoutedEventArgs e)
        {
            Egal();
            operationCourante = moins;
        }
        private void Button_multiplier(object sender, RoutedEventArgs e)
        {
            Egal();
            operationCourante = multiplier;
        }
        private void Button_diviser(object sender, RoutedEventArgs e)
        {
            Egal();
            operationCourante = diviser;
        }


        private void Egal()
        {
            int nbtemp = 0;
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
            zoneTexte.Text = strNombre;
            strNombre = "";
            nombre = 0;
        }

        private void Button_egal(object sender, RoutedEventArgs e)
        {
            Egal();
            operationCourante = plus;
        }

        private void Button_virgule(object sender, RoutedEventArgs e) { }

    }
}
