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
using System.Windows.Shapes;
using MyPetsApp.Models;
using MyPetsApp.Utils;
using MyPetsApp.ViewModels;
using System.Text.RegularExpressions;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour NewPersonView.xaml
    /// </summary>
    public partial class NewPersonView : UserControl
    {
        public NewPersonView()
        {
            InitializeComponent();
        }

        public void createbtn_OnClick(object sender, RoutedEventArgs e)
        {
            string messagebox = "Format Invalide. Veulliez saisir des caractères valides pour :";

            //Nom_
            if (!Regex.IsMatch(New_Nom_tb.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Nom_tb.Text == "")
            {
                messagebox += "\n- Nom";
            }

            //Prenom
            if (!Regex.IsMatch(New_Prenom_tb.Text, @"^[a-zA-Zéèà'-ç ]*$") || New_Prenom_tb.Text == "")
            {
                messagebox += "\n- Prenom";
            }

            //Adresse
            if (!Regex.IsMatch(New_Adresse_tb.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Adresse_tb.Text == "")
            {
                messagebox += "\n- Adresse Postale";
            }

            //Code Postal
            if (!Regex.IsMatch(New_CodePostal_tb.Text, "[0-9]{5}") || New_CodePostal_tb.Text == "")
            {
                messagebox += "\n- Code Postal";
            }

            //Ville
            if (!Regex.IsMatch(New_Ville_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || New_Ville_tb.Text == "")
            {
                messagebox += "\n- Nom de la Ville";
            }

            //Departement
            if (!Regex.IsMatch(New_Departement_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || New_Departement_tb.Text == "")
            {
                messagebox += "\n- Nom du Departement";
            }

            //Mail
            if (!Regex.IsMatch(New_Mail_tb.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || New_Mail_tb.Text == "")
            {
                messagebox += "\n- Adresse e-mail";
            }

            //Telephone
            if (!Regex.IsMatch(New_Telephone_tb.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") || New_Telephone_tb.Text == "")
            {
                messagebox += "\n- Numéro de Telephone";
            }

            if (New_Nom_tb.Text == "" ||
                New_Prenom_tb.Text == "" ||
                New_Adresse_tb.Text == "" ||
                New_CodePostal_tb.Text == "" ||
                New_Departement_tb.Text == "" ||
                New_Mail_tb.Text == "" ||
                New_Telephone_tb.Text == "" ||
                New_Ville_tb.Text == "" ||
                New_Hierarchie_cb.Text == "")
            {
                New_NeedInfo.Visibility = Visibility.Visible;
            }
            else
            {
                New_NeedInfo.Visibility = Visibility.Hidden;

                if (New_Password.Password != New_Password_Confirmed.Password)
                {
                    New_notSameMdp.Visibility = Visibility.Visible;
                    messagebox += "\n- Mots de passe différents";
                }
                else
                {
                    New_notSameMdp.Visibility = Visibility.Hidden;

                    Person person = new()
                    {
                        FirstName = New_Nom_tb.Text,
                        LastName = New_Prenom_tb.Text,
                        Email = New_Mail_tb.Text,
                        PhoneNumber = New_Telephone_tb.Text,
                        Address = New_Adresse_tb.Text,
                        ZipCode = New_CodePostal_tb.Text,
                        City = New_Ville_tb.Text,
                        Hierarchy = New_Hierarchie_cb.Text,
                        Password = New_Password_Confirmed.Password,
                        Zone = New_Departement_tb.Text
                    };

                    NewPersonViewModel npm = new();
                    npm.CreateUser(person);

                    //Reset des champs
                    New_Nom_tb.Text = "";
                    New_Prenom_tb.Text = "";
                    New_Adresse_tb.Text = "";
                    New_CodePostal_tb.Text = "";
                    New_Departement_tb.Text = "";
                    New_Mail_tb.Text = "";
                    New_Telephone_tb.Text = "";
                    New_Ville_tb.Text = "";
                    New_Password.Password = "";
                    New_Password_Confirmed.Password = "";
                    New_Hierarchie_cb.Text = "";
                }
            }

            if (messagebox != "Format Invalide. Veulliez saisir des caractères valides pour :")
                MessageBox.Show(messagebox, "Erreur de Saisie", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
