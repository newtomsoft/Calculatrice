﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private string op_puissance;
        private string op_rien;

        private string symbole_plus;
        private string symbole_moins;
        private string symbole_multiplier;
        private string symbole_diviser;
        private string symbole_egal;
        private string symbole_puissance;

        private double nombreCourant;
        private double nombreStocke;
        private string operationCourante;
        private bool virgule;
        private bool negatif;
        private int nb0;
        private int nbChiffre;
        private string operationAAficher;

        public Calc()
        {
            InitializeComponent();
            op_plus = Additionner.Name;
            op_moins = Soustraire.Name;
            op_multiplier = Multiplier.Name;
            op_diviser = Diviser.Name;
            op_puissance = Puissance.Name;
            op_rien = "rien";

            symbole_plus = (string)Additionner.Content;
            symbole_moins = (string)Soustraire.Content;
            symbole_multiplier = (string)Multiplier.Content;
            symbole_diviser = (string)Diviser.Content;
            symbole_egal = (string)Resultat.Content;
            symbole_puissance = (string)Puissance.Content;

            EcranChiffres.Text = "0";
            nombreCourant = 0;
            nombreStocke = 0;
            operationCourante = op_rien;
            virgule = false;
            negatif = false;
            nb0 = 0;
            nbChiffre = 0;
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
            nbChiffre++;
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

            if (chiffre == 0 && nb0 > 0)
            {
                if (!EcranChiffres.Text.Contains(","))
                    EcranChiffres.Text += ",";


                for (int i = 0; i < TexteLongueur - nbChiffre + 1; i++)
                    EcranChiffres.Text += "0";
            }
        }

        private void BoutonCe(object sender, RoutedEventArgs e)
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

        private void BoutonC(object sender, RoutedEventArgs e)
        {
            AfficheEcranChiffres("0");
            nombreCourant = 0;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
        }

        private void BoutonEfface(object sender, RoutedEventArgs e)
        {
            int longueur = EcranChiffres.Text.Length;
            if (longueur >= 2 && EcranChiffres.Text[0] != '-' || longueur >= 3 && EcranChiffres.Text[0] == '-')
            {
                EcranChiffres.Text = EcranChiffres.Text.Remove(longueur - 1);
                nombreCourant = Double.Parse(EcranChiffres.Text);
            }
            else
            {
                EcranChiffres.Text = "0";
                nombreCourant = 0;
            }
        }

        private void BoutonOperation(object sender, RoutedEventArgs e)
        {
            Operation();

            string op = ((Button)sender).Name.ToString();
            string symbole = "";
            if (op == op_plus) symbole = symbole_plus;
            else if (op == op_moins) symbole = symbole_moins;
            else if (op == op_multiplier) symbole = symbole_multiplier;
            else if (op == op_diviser) symbole = symbole_diviser;
            else if (op == op_puissance) symbole = symbole_puissance;

            GestionOperationCourante(op, symbole);
        }

        private void BoutonEgal(object sender, RoutedEventArgs e)
        {
            Operation();
            operationCourante = op_rien;
            virgule = false;
            nb0 = 0;
            nbChiffre = 0;
            EcranOperation.Text = symbole_egal;
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
            if (operationCourante == op_plus) nombreStocke += nombreCourant;
            else if (operationCourante == op_moins) nombreStocke -= nombreCourant;
            else if (operationCourante == op_multiplier) nombreStocke *= nombreCourant;
            else if (operationCourante == op_diviser) nombreStocke /= nombreCourant;
            else if (operationCourante == op_puissance) nombreStocke = Math.Pow(nombreStocke, nombreCourant);
            else if (operationCourante == op_rien) nombreStocke = Double.Parse(EcranChiffres.Text);

            EcranChiffres.Text = nombreStocke.ToString();
            nombreCourant = 0;
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
        }

        private void EcranChiffreClicDroit(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("clic droit non encore implémenté");
        }

        private void EgalClicDroit(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("clic droit non encore implémenté");
        }
    }
}