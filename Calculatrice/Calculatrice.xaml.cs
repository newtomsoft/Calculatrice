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
        private string op_plus;
        private string op_moins;
        private string op_multiplier;
        private string op_diviser;
        private string op_rien;

        private double nombreCourant;
        private double nombreStocke;
        string operationCourante;
        private bool virgule;
        private int nb0;
        private int nbChiffre;

        public Calc()
        {
            InitializeComponent();
            op_plus = Additionner.Name;
            op_moins = Soustraire.Name;
            op_multiplier = Multiplier.Name;
            op_diviser = Diviser.Name;
            op_rien = "rien";

            Ecran.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }

        private void ClearZero()
        {
            Ecran.Text = "";

        }

        private void BoutonChiffre(object sender, RoutedEventArgs e)
        {
            int chiffre = Int32.Parse(((Button)sender).Content.ToString());
            Chiffre(chiffre);
        }

        private void Chiffre(int chiffre)
        {

            nbChiffre++;
            int TexteLongueur = Ecran.Text.Length;

            ClearZero();
            if (!virgule)
                nombreCourant = nombreCourant * 10 + chiffre;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + chiffre * Math.Pow(10, -nb0);
            }
            Ecran.Text = nombreCourant.ToString();

            if (chiffre == 0 && nb0 > 0)
            {
                if (!Ecran.Text.Contains(","))
                    Ecran.Text += ",";


                for (int i = 0; i < TexteLongueur - nbChiffre + 1; i++)
                    Ecran.Text += "0";
            }
        }


        private void Button_ce(object sender, RoutedEventArgs e)
        {
            Ecran.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }

        private void Bouton_operation(object sender, RoutedEventArgs e)
        {
            Operation();
            operationCourante = ((Button)sender).Name.ToString();
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }

        private void Button_egal(object sender, RoutedEventArgs e)
        {
            Egal();
        }

        private void Egal()
        {
            Operation();
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;

        }

        private void Button_virgule(object sender, RoutedEventArgs e)
        {
            Virgule();
        }
        private void Virgule()
        {
            if (!virgule)
                Ecran.Text += ",";
            virgule = true;

        }

        private void Button_plusmoins(object sender, RoutedEventArgs e)
        {
            ClearZero();
            nombreCourant = nombreCourant * -1;
            Ecran.Text = nombreCourant.ToString();
        }

        private void Operation()
        {
            if (operationCourante == op_plus)
                nombreStocke += nombreCourant;
            else if (operationCourante == op_moins)
                nombreStocke -= nombreCourant;
            else if (operationCourante == op_multiplier)
                nombreStocke *= nombreCourant;
            else if (operationCourante == op_diviser)
                nombreStocke /= nombreCourant;
            else if (operationCourante == op_rien)
                nombreStocke = nombreCourant;

            Ecran.Text = nombreStocke.ToString();
            nombreCourant = 0;
        }

        private void Button_pourcent(object sender, RoutedEventArgs e)
        {
            Pourcent();
        }
        private void Pourcent()
        {
            nombreCourant *= nombreStocke / 100;
            Ecran.Text = nombreCourant.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key > Key.NumPad0 && e.Key < Key.NumPad9)
            {
                Chiffre(e.Key - Key.NumPad0);
            }
            if (e.Key == Key.Subtract)
            {
                Operation();
                operationCourante = op_moins;
                virgule = false;
                nb0 = 0;
                nbChiffre = 0;
            }
            if (e.Key == Key.Decimal)
            {
                Virgule();
            }
            if (e.Key == Key.Divide)
            {
                Operation();
                operationCourante = op_diviser;
                virgule = false;
                nb0 = 0;
                nbChiffre = 0;
            }
            if (e.Key == Key.Multiply)
            {
                Operation();
                operationCourante = op_multiplier;
                virgule = false;
                nb0 = 0;
                nbChiffre = 0;
            }
            if (e.Key == Key.Add)
            {
                Operation();
                operationCourante = op_plus;
                virgule = false;
                nb0 = 0;
                nbChiffre = 0;
            }
            if (e.Key == Key.Enter)
            {
                Egal();
            }
            //if (e.Key == Key.)
        }

    }
}