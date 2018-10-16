using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using @enum;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Calc : Window
    {
        private const string symbole_plus = "+";
        private const string symbole_moins = "-";
        private const string symbole_multiplier = "x";
        private const string symbole_diviser = ":";
        private const string symbole_egal = "=";
        private const string symbole_puissance = "^";

        private double nombreCourant;
        private double nombreStocke;
        private TypeOperation operationCourante;
        private bool virgule;
        private bool negatif;
        private int nb0;
        private int nbChiffres = 0;
        private string operationAAficher;
        private bool toucheCtrl = false;

        public Calc()
        {
            InitializeComponent();

            EcranChiffres.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = TypeOperation.Aucune;
            virgule = false;
            negatif = false;
            nb0 = 0;
            nbChiffres = 0;
        }

        void AfficheEcranOperation(string s)
        {
            EcranOperation.Text = s;
           

        }
        void AfficheEcranChiffres(string s)
        {
            EcranChiffres.Text = s;
        }

        private void BoutonChiffre(object sender, RoutedEventArgs e)
        {
            int chiffre = Int32.Parse(((Button)sender).Content.ToString());
            Chiffre(chiffre);
        }

        private void Chiffre(int chiffre)
        {
            nbChiffres++;
            int longueurNombreCourant = 0;
            string nbcourantstring;

            int TexteLongueur = EcranChiffres.Text.Length;

            if (!virgule)
            {
                if (!negatif) nombreCourant = nombreCourant * 10 + chiffre;
                else nombreCourant = nombreCourant * 10 - chiffre;
            }
            else
            {
                nb0++;
                if (!negatif) nombreCourant = nombreCourant + chiffre * Math.Pow(10, -nb0);
                else nombreCourant = nombreCourant - chiffre * Math.Pow(10, -nb0);
            }


            AfficheEcranChiffres(nombreCourant.ToString());

            if (virgule)
            {
                if (chiffre == 0)
                {
                    if (!EcranChiffres.Text.Contains(","))
                        EcranChiffres.Text += ",";
                }

                nbcourantstring = nombreCourant.ToString();
                longueurNombreCourant = nbcourantstring.Length;

                for (int i = longueurNombreCourant; i <= nbChiffres; i++)
                    EcranChiffres.Text += "0";

            }
        }

        private void BoutonCe(object sender, RoutedEventArgs e)
        {
            AfficheEcranChiffres("0");
            AfficheEcranOperation("");
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = TypeOperation.Aucune;
            virgule = false;
            negatif = false;
            nb0 = 0;
            nbChiffres = 0;
        }

        private void BoutonC(object sender, RoutedEventArgs e)
        {
            AfficheEcranChiffres("0");
            nombreCourant = 0;
            virgule = false;
            nb0 = 0;
            nbChiffres = 0;
        }

        private void BoutonEfface(object sender, RoutedEventArgs e)
        {
            int longueur = EcranChiffres.Text.Length;
            nb0--;
            if (nb0 < 0) nb0 = 0;

            if (longueur >= 2 && EcranChiffres.Text[0] != '-' || longueur >= 3 && EcranChiffres.Text[0] == '-')
            {
                EcranChiffres.Text = EcranChiffres.Text.Remove(longueur - 1);
                nombreCourant = Double.Parse(EcranChiffres.Text);

                if (!virgule)
                {
                    nbChiffres--;
                }
                else
                {

                    int partieEntiere = (int)nombreCourant;
                    string stringPartieEntiere = partieEntiere.ToString();
                    if (partieEntiere == nombreCourant && EcranChiffres.Text == stringPartieEntiere) // virgule effacée 
                    {
                        virgule = false;
                        nbChiffres = partieEntiere.ToString().Length;

                    }
                    else
                    {
                        virgule = true;
                        nbChiffres--;
                    }
                }



            }
            else
            {
                EcranChiffres.Text = "0";
                nombreCourant = 0;
                nbChiffres = 0;
                virgule = false;
            }
        }

        private void BoutonOperation(object sender, RoutedEventArgs e)
        {
            Operation();
            nbChiffres = 0;
            string op = ((Button)sender).Name.ToString();
            string symbole = "";
            if (op == Additionner.Name)
            {
                symbole = symbole_plus;
                GestionOperationCourante(TypeOperation.Addition, symbole);
            }
            else if (op == Soustraire.Name)
            {
                symbole = symbole_moins;
                GestionOperationCourante(TypeOperation.Soustraction, symbole);
            }
            else if (op == Multiplier.Name)
            {
                symbole = symbole_multiplier;
                GestionOperationCourante(TypeOperation.Multiplication, symbole);
            }
            else if (op == Diviser.Name)
            {
                symbole = symbole_diviser;
                GestionOperationCourante(TypeOperation.Division, symbole);
            }
            else if (op == Puissance.Name)
            {
                symbole = symbole_puissance;
                GestionOperationCourante(TypeOperation.Puissance, symbole);
            }


        }

        private void BoutonEgal(object sender, RoutedEventArgs e)
        {
            Operation();
            operationCourante = TypeOperation.Aucune;
            virgule = false;
            nb0 = 0;
            nbChiffres = 0;
            EcranOperation.Text = symbole_egal;
            nombreCourant = nombreStocke;
        }

        private void BoutonVirgule(object sender, RoutedEventArgs e)
        {
            if (!virgule)
                EcranChiffres.Text += ",";
            virgule = true;
        }

        private void BoutonPlusMoins(object sender, RoutedEventArgs e)
        {
            if (negatif) negatif = false;
            else negatif = true;
            nombreCourant = nombreCourant * -1;
            EcranChiffres.Text = nombreCourant.ToString();
        }

        private void BoutonPourcent(object sender, RoutedEventArgs e)
        {
            nombreCourant *= nombreStocke / 100;
            EcranChiffres.Text = nombreCourant.ToString();
        }

        private void BoutonInverse(object sender, RoutedEventArgs e)
        {
            nombreCourant = 1 / nombreCourant;
            EcranChiffres.Text = nombreCourant.ToString();
        }

        private void BoutonRacine2(object sender, RoutedEventArgs e)
        {
            nombreCourant = Math.Sqrt(nombreCourant); ;
            EcranChiffres.Text = nombreCourant.ToString();
        }

        private void Operation()
        {
            if (operationCourante == TypeOperation.Addition) nombreStocke += nombreCourant;
            else if (operationCourante == TypeOperation.Soustraction) nombreStocke -= nombreCourant;
            else if (operationCourante == TypeOperation.Multiplication) nombreStocke *= nombreCourant;
            else if (operationCourante == TypeOperation.Division) nombreStocke /= nombreCourant;
            else if (operationCourante == TypeOperation.Puissance) nombreStocke = Math.Pow(nombreStocke, nombreCourant);
            else if (operationCourante == TypeOperation.Aucune) nombreStocke = Double.Parse(EcranChiffres.Text);

            EcranChiffres.Text = nombreStocke.ToString();
            nombreCourant = 0; //TODO
        }


        void GestionOperationCourante(TypeOperation op, string symbole)
        {
            operationCourante = op;
            AfficheEcranOperation(nombreStocke + " " + symbole);
            if (operationCourante == TypeOperation.Aucune) AfficheEcranOperation(nombreStocke + " " + symbole + " " + nombreCourant);
            AfficheEcranChiffres("0");
            virgule = false;
            nb0 = 0;
            nbChiffres = 0;
        }

        void OperationAAficher()
        {
            operationAAficher = nombreStocke + " " + operationCourante + " " + nombreCourant + " =";
            AfficheEcranOperation(operationAAficher);
        }

        private void ToucheClavier(object sender, KeyEventArgs e)
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
                BoutonPourcent(null, null);
            }
            else if (e.Key == Key.Home)
            {
                BoutonCe(null, null);
            }
            else if (e.Key == Key.Add)
            {
                Operation();
                GestionOperationCourante(TypeOperation.Addition, symbole_plus);
            }
            else if (e.Key == Key.Subtract)
            {
                Operation();
                GestionOperationCourante(TypeOperation.Soustraction, symbole_moins);
            }
            else if (e.Key == Key.Divide)
            {
                Operation();
                GestionOperationCourante(TypeOperation.Division, symbole_diviser);
            }
            else if (e.Key == Key.Multiply)
            {
                Operation();
                GestionOperationCourante(TypeOperation.Multiplication, symbole_multiplier);
            }
            else if (e.Key == Key.Decimal)
            {
                BoutonVirgule(null, null);
            }
            else if (e.Key == Key.Enter)
            {
                BoutonEgal(null, null);
            }
            else if (e.Key == Key.Back)
            {
                BoutonEfface(null, null);
            }
            else if (e.Key == Key.C && toucheCtrl)
            {
                Clipboard.SetData(DataFormats.Text, (Object)nombreCourant);
                toucheCtrl = false;
            }
        }

        private void EcranChiffreClicDroit(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("clic droit non encore implémenté");
        }

        private void EgalClicDroit(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Donne le résultat de l'opération");
        }


        private void IncremantCommand()
        { }

        private void Calc_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
                toucheCtrl = true;
        }

        private void Calc_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
                toucheCtrl = false;
        }
    }
}