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

        private string symbole_plus;
        private string symbole_moins;
        private string symbole_multiplier;
        private string symbole_diviser;
        private string symbole_egal;

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
            symbole_plus = "+";
            symbole_moins = "-";
            symbole_multiplier = "x";
            symbole_diviser = "/";
            symbole_egal = "=";

            EcranChiffres.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }

        private void BoutonChiffre(object sender, RoutedEventArgs e)
        {
            int chiffre = Int32.Parse(((Button)sender).Content.ToString());
            Chiffre(chiffre);
        }

        private void Chiffre(int chiffre)
        {
            nbChiffre++;
            int TexteLongueur = EcranChiffres.Text.Length;

            if (!virgule)
                nombreCourant = nombreCourant * 10 + chiffre;
            else
            {
                nb0++;
                nombreCourant = nombreCourant + chiffre * Math.Pow(10, -nb0);
            }
            EcranChiffres.Text = nombreCourant.ToString();

            if (chiffre == 0 && nb0 > 0)
            {
                if (!EcranChiffres.Text.Contains(","))
                    EcranChiffres.Text += ",";


                for (int i = 0; i < TexteLongueur - nbChiffre + 1; i++)
                    EcranChiffres.Text += "0";
            }
        }

        private void Button_ce(object sender, RoutedEventArgs e)
        {
            AfficheEcranChiffres("0");
            AfficheEcranOperation("");
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

            string op = ((Button)sender).Name.ToString();  
            string symbole="";
            if (op == op_plus) symbole = symbole_plus;
            if (op == op_moins) symbole = symbole_moins;
            if (op == op_multiplier) symbole = symbole_multiplier;
            if (op == op_diviser) symbole = symbole_diviser;

            GestionOperationCourante(op, symbole);
        }

        private void Button_egal(object sender, RoutedEventArgs e)
        {
            Operation();
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
            EcranOperation.Text = symbole_egal;
        }

        private void Button_virgule(object sender, RoutedEventArgs e)
        {
            if (!virgule)
                EcranChiffres.Text += ",";
            virgule = true;
        }
        private void Button_plusmoins(object sender, RoutedEventArgs e)
        {
            nombreCourant = nombreCourant * -1;
            EcranChiffres.Text = nombreCourant.ToString();
        }
        private void Button_pourcent(object sender, RoutedEventArgs e)
        {
            nombreCourant *= nombreStocke / 100;
            EcranChiffres.Text = nombreCourant.ToString();
        }

        private void Operation()
        {
            if (operationCourante == op_plus)  nombreStocke += nombreCourant;
            else if (operationCourante == op_moins)  nombreStocke -= nombreCourant;
            else if (operationCourante == op_multiplier)  nombreStocke *= nombreCourant;
            else if (operationCourante == op_diviser)  nombreStocke /= nombreCourant;
            else if (operationCourante == op_rien)  nombreStocke = nombreCourant;

            EcranChiffres.Text = nombreStocke.ToString();
            nombreCourant = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                Chiffre(e.Key - Key.NumPad0);
            }

            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                Chiffre(e.Key - Key.D0);
            }

            else if (e.Key == Key.Oem3)
            {
                Button_pourcent(null, null);
            }
            else if (e.Key == Key.Home)
            {
                Button_ce(null, null);
            }

            else if (e.Key == Key.Add)
            {
                Operation();
                operationCourante = op_plus;
                AfficheEcranOperation(nombreStocke + " " + symbole_plus);
                AfficheEcranChiffres("0");
                virgule = false;
                nb0 = 0;
                nbChiffre = 0;
            }
            else if (e.Key == Key.Subtract)
            {
                Operation();
                GestionOperationCourante(op_moins, symbole_moins);
            }
            else if (e.Key == Key.Divide)
            {
                Operation();
                GestionOperationCourante(op_diviser, symbole_diviser);
            }
            else if (e.Key == Key.Multiply)
            {
                Operation();
                GestionOperationCourante(op_multiplier, symbole_multiplier);
            }
            else if (e.Key == Key.Decimal)
            {
                Button_virgule(null, null);
            }
            else if (e.Key == Key.Enter)
            {
                Button_egal(null, null);
            }
        }

        void AfficheEcranOperation(string s)
        {
            EcranOperation.Text = s;
        }
        void AfficheEcranChiffres(string s)
        {
            EcranChiffres.Text = s;
        }

        void GestionOperationCourante(string op, string symbole)
        {
            operationCourante = op;
            AfficheEcranOperation(nombreStocke + " " + symbole);
            AfficheEcranChiffres("0");
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }
    }
}