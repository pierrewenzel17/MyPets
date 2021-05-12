using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MyPetsApp.Models;
using MyPetsApp.Services;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour NewInvestigationView.xaml
    /// </summary>
    public partial class NewInvestigationView : UserControl
    {
        public NewInvestigationView()
        {
            InitializeComponent();
        }

        public void createInvbtn_OnClick(object sender, RoutedEventArgs e)
        {
            string messagebox = "Format Invalide. Veulliez saisir des caractères valides pour :";

            //---------- REGEX PLAIGNANT ------------
            //Nom_
            if (!Regex.IsMatch(New_Nom_p.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Nom_p.Text == "")
            {
                messagebox += "\n- Nom plaignant";
            }

            //Prenom
            if (!Regex.IsMatch(New_Prenom_p.Text, @"^[a-zA-Zéèà'-ç ]*$") || New_Prenom_p.Text == "")
            {
                messagebox += "\n- Prenom plaignant";
            }

            //Adresse
            if (!Regex.IsMatch(New_Adresse_p.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Adresse_p.Text == "")
            {
                messagebox += "\n- Adresse Postale plaignant";
            }

            //Code Postal
            if (!Regex.IsMatch(New_CodePostal_p.Text, "[0-9]{5}") || New_CodePostal_p.Text == "")
            {
                messagebox += "\n- Code Postal plaignant";
            }

            //Ville
            if (!Regex.IsMatch(New_Ville_p.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || New_Ville_p.Text == "")
            {
                messagebox += "\n- Nom de la Ville plaignant";
            }

            //Mail
            if (!Regex.IsMatch(New_Mail_p.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") ||
                New_Mail_p.Text == "")
            {
                messagebox += "\n- Adresse e-mail plaignant";
            }

            //Telephone
            if (!Regex.IsMatch(New_Telephone_p.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") ||
                New_Telephone_p.Text == "")
            {
                messagebox += "\n- Numéro de Telephone plaignant";
            }

            //---------- REGEX SUSPECT ------------
            //Nom_
            if (!Regex.IsMatch(New_Nom_s.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Nom_s.Text == "")
            {
                messagebox += "\n- Nom suspect";
            }

            //Prenom
            if (!Regex.IsMatch(New_Prenom_s.Text, @"^[a-zA-Zéèà'-ç ]*$") || New_Prenom_s.Text == "")
            {
                messagebox += "\n- Prenom suspect";
            }

            //Adresse
            if (!Regex.IsMatch(New_Adresse_s.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || New_Adresse_s.Text == "")
            {
                messagebox += "\n- Adresse Postale suspect";
            }

            //Code Postal
            if (!Regex.IsMatch(New_CodePostal_s.Text, "[0-9]{5}") || New_CodePostal_s.Text == "")
            {
                messagebox += "\n- Code Postal suspect";
            }

            //Ville
            if (!Regex.IsMatch(New_Ville_s.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || New_Ville_s.Text == "")
            {
                messagebox += "\n- Nom de la Ville suspect";
            }

            //Mail
            if (!Regex.IsMatch(New_Mail_s.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") ||
                New_Mail_s.Text == "")
            {
                messagebox += "\n- Adresse e-mail suspect";
            }

            //Telephone
            if (!Regex.IsMatch(New_Telephone_s.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") ||
                New_Telephone_s.Text == "")
            {
                messagebox += "\n- Numéro de Telephone suspect";
            }

            //--------- REGEX INFO ENQUETE -------
            //Raison
            if (!Regex.IsMatch(raison.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || raison.Text == "")
            {
                messagebox += "\n- Raison invalide";
            }

            //Race
            if (!Regex.IsMatch(breed.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || breed.Text == "")
            {
                messagebox += "\n- Race invalide";
            }

            //Nombre d'animaux
            if (!Regex.IsMatch(nb_pet.Text, "[0-9]") || nb_pet.Text == "")
            {
                messagebox += "\n- Nombre d'animaux";
            }

            //Nombre d'animaux
            if (investigator.Text == "")
            {
                messagebox += "\n- Veuillez saisir un Enquêteur";
            }

            if (New_Nom_s.Text == "" ||
                New_Prenom_s.Text == "" ||
                New_Adresse_s.Text == "" ||
                New_CodePostal_s.Text == "" ||
                New_Mail_s.Text == "" ||
                New_Telephone_s.Text == "" ||
                New_Ville_s.Text == "" ||
                New_Nom_p.Text == "" ||
                New_Prenom_p.Text == "" ||
                New_Adresse_p.Text == "" ||
                New_CodePostal_p.Text == "" ||
                New_Mail_p.Text == "" ||
                New_Telephone_p.Text == "" ||
                New_Ville_p.Text == "" ||
                breed.Text == "" ||
                nb_pet.Text == "" ||
                raison.Text == "" ||
                investigator.SelectionBoxItem is null)
            {

                New_NeedInfo.Visibility = Visibility.Visible;
            }
            else
            {
                New_NeedInfo.Visibility = Visibility.Hidden;
                InvestigationService investigationService = new();
                InvestigationPerson supect = new()
                {
                    LastName = New_Nom_s.Text,
                    FirstName = New_Prenom_s.Text,
                    Address = New_Adresse_s.Text,
                    City = New_Ville_s.Text,
                    ZipCode = New_CodePostal_s.Text,
                    PhoneNumber = New_Telephone_s.Text,
                    Email = New_Mail_s.Text,
                    Type = 1
                };
                InvestigationPerson p = new()
                {
                    LastName = New_Nom_p.Text,
                    FirstName = New_Prenom_p.Text,
                    Address = New_Adresse_p.Text,
                    City = New_Ville_p.Text,
                    ZipCode = New_CodePostal_p.Text,
                    PhoneNumber = New_Telephone_p.Text,
                    Email = New_Mail_p.Text,
                    Type = 2
                };
                Investigation investigation = new()
                {
                    Breed = breed.Text,
                    HolderInvestigatorId = (Person) investigator.SelectionBoxItem,
                    InvestigationOffenderId = supect,
                    InvestigationPlaintiffId = p,
                    NumberOfPets = int.Parse(nb_pet.Text),
                    Reason = raison.Text
                };
                Task.Run(() => investigationService.Create(investigation)).GetAwaiter().GetResult();

                New_Nom_s.Text = "";
                New_Prenom_s.Text = "";
                New_Adresse_s.Text = "";
                New_CodePostal_s.Text = "";
                New_Mail_s.Text = "";
                New_Telephone_s.Text = "";
                New_Ville_s.Text = "";
                New_Nom_p.Text = "";
                New_Prenom_p.Text = "";
                New_Adresse_p.Text = "";
                New_CodePostal_p.Text = "";
                New_Mail_p.Text = "";
                New_Telephone_p.Text = "";
                New_Ville_p.Text = "";
                breed.Text = "";
                nb_pet.Text = "";
                raison.Text = "";

                investigator.ItemsSource = Task.Run(() => new PersonService().Get()).GetAwaiter().GetResult();
                MessageBox.Show("Création bien effectuée", "Création d'une enquête", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            if (messagebox != "Format Invalide. Veulliez saisir des caractères valides pour :")
            {
                MessageBox.Show(messagebox, "Erreur de Saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
