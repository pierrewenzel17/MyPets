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
    /// Logique d'interaction pour ModifyInvestigationView.xaml
    /// </summary>
    public partial class ModifyInvestigationView : UserControl
    {
        public ModifyInvestigationView()
        {
            InitializeComponent();
        }

        public void ChangeInvestigationBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string messagebox = "Format Invalide. Veulliez saisir des caractères valides pour :";

            //---------- REGEX PLAIGNANT ------------
            //Nom_
            if (!Regex.IsMatch(tab_Nom_p.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Nom_p.Text == "")
            {
                messagebox += "\n- Nom plaignant";
            }

            //Prenom
            if (!Regex.IsMatch(tab_Prenom_p.Text, @"^[a-zA-Zéèà'-ç ]*$") || tab_Prenom_p.Text == "")
            {
                messagebox += "\n- Prenom plaignant";
            }

            //Adresse
            if (!Regex.IsMatch(tab_Adresse_p.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Adresse_p.Text == "")
            {
                messagebox += "\n- Adresse Postale plaignant";
            }

            //Code Postal
            if (!Regex.IsMatch(tab_CodePostal_p.Text, "[0-9]{5}") || tab_CodePostal_p.Text == "")
            {
                messagebox += "\n- Code Postal plaignant";
            }

            //Ville
            if (!Regex.IsMatch(tab_Ville_p.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_Ville_p.Text == "")
            {
                messagebox += "\n- Nom de la Ville plaignant";
            }

            //Mail
            if (!Regex.IsMatch(tab_Mail_p.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || tab_Mail_p.Text == "")
            {
                messagebox += "\n- Adresse e-mail plaignant";
            }

            //Telephone
            if (!Regex.IsMatch(tab_Telephone_p.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") || tab_Telephone_p.Text == "")
            {
                messagebox += "\n- Numéro de Telephone plaignant";
            }

            //---------- REGEX SUSPECT ------------
            //Nom_
            if (!Regex.IsMatch(tab_Nom_s.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Nom_s.Text == "")
            {
                messagebox += "\n- Nom suspect";
            }

            //Prenom
            if (!Regex.IsMatch(tab_Prenom_s.Text, @"^[a-zA-Zéèà'-ç ]*$") || tab_Prenom_s.Text == "")
            {
                messagebox += "\n- Prenom suspect";
            }

            //Adresse
            if (!Regex.IsMatch(tab_Adresse_s.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Adresse_s.Text == "")
            {
                messagebox += "\n- Adresse Postale suspect";
            }

            //Code Postal
            if (!Regex.IsMatch(tab_CodePostal_s.Text, "[0-9]{5}") || tab_CodePostal_s.Text == "")
            {
                messagebox += "\n- Code Postal suspect";
            }

            //Ville
            if (!Regex.IsMatch(tab_Ville_s.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_Ville_s.Text == "")
            {
                messagebox += "\n- Nom de la Ville suspect";
            }
            
            //Mail
            if (!Regex.IsMatch(tab_Mail_s.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || tab_Mail_s.Text == "")
            {
                messagebox += "\n- Adresse e-mail suspect";
            }

            //Telephone
            if (!Regex.IsMatch(tab_Telephone_s.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") || tab_Telephone_s.Text == "")
            {
                messagebox += "\n- Numéro de Telephone suspect";
            }

            //--------- REGEX INFO ENQUETE -------
            //Raison
            if (!Regex.IsMatch(tab_raison.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_raison.Text == "")
            {
                messagebox += "\n- Raison invalide";
            }

            //Race
            if (!Regex.IsMatch(tab_breed.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_breed.Text == "")
            {
                messagebox += "\n- Race invalide";
            }

            //Nombre d'animaux
            if (!Regex.IsMatch(tab_nb_pet.Text, "[0-9]") || tab_nb_pet.Text == "")
            {
                messagebox += "\n- Nombre d'animaux";
            }

            //Nombre d'animaux
            if (tab_investigator.Text == "")
            {
                messagebox += "\n- Veuillez saisir un Enquêteur";
            }

            if (messagebox != "Format Invalide. Veulliez saisir des caractères valides pour :")
                MessageBox.Show(messagebox, "Erreur de Saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                InvestigationService InvServ = new();

                InvestigationPerson supect = new()
                {
                    InvestigationPersonId = int.Parse(tab_SuspectID_tb.Text),
                    LastName = tab_Nom_s.Text,
                    FirstName = tab_Prenom_s.Text,
                    Address = tab_Adresse_s.Text,
                    City = tab_Ville_s.Text,
                    ZipCode = tab_CodePostal_s.Text,
                    PhoneNumber = tab_Telephone_s.Text,
                    Email = tab_Mail_s.Text,
                    Type = 1
                };
                InvestigationPerson p = new()
                {
                    InvestigationPersonId = int.Parse(tab_Plaignant_tb.Text),
                    LastName = tab_Nom_p.Text,
                    FirstName = tab_Prenom_p.Text,
                    Address = tab_Adresse_p.Text,
                    City = tab_Ville_p.Text,
                    ZipCode = tab_CodePostal_p.Text,
                    PhoneNumber = tab_Telephone_p.Text,
                    Email = tab_Mail_p.Text,
                    Type = 2
                };
                Investigation investigation = new()
                {
                    InvestigationId = int.Parse(tab_Investigation_tb.Text),
                    Breed = tab_breed.Text,
                    HolderInvestigatorId = (Person)tab_investigator.SelectionBoxItem,
                    InvestigationOffenderId = supect,
                    InvestigationPlaintiffId = p,
                    NumberOfPets = int.Parse(tab_nb_pet.Text),
                    Reason = tab_raison.Text
                };

                Task.Run(() => InvServ.Update(investigation)).GetAwaiter().GetResult();
            }
        }
    }
}
