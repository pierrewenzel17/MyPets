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
using MyPetsApp.Models;
using MyPetsApp.Utils;
using MyPetsApp.ViewModels;
using System.Text.RegularExpressions;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour ModifyUserView.xaml
    /// </summary>
    public partial class ModifyPersonView : UserControl
    {
        public ModifyPersonView()
        {
            InitializeComponent();
        }

        private void ChangePersonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string messagebox = "Format Invalide. Veulliez saisir des caractères valides pour :";

            //Nom_
            if (!Regex.IsMatch(tab_Nom_tb.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Nom_tb.Text == "")
            {
                messagebox += "\n- Nom";
            }

            //Prenom
            if (!Regex.IsMatch(tab_Prenom_tb.Text, @"^[a-zA-Zéèà'-ç ]*$") || tab_Prenom_tb.Text == "")
            {
                messagebox += "\n- Prenom";
            }

            //Adresse
            if (!Regex.IsMatch(tab_Adresse_tb.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || tab_Adresse_tb.Text == "")
            {
                messagebox += "\n- Adresse Postale";
            }

            //Code Postal
            if (!Regex.IsMatch(tab_CodePostal_tb.Text, "[0-9]{5}") || tab_CodePostal_tb.Text == "")
            {
                messagebox += "\n- Code Postal";
            }

            //Ville
            if (!Regex.IsMatch(tab_Ville_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_Ville_tb.Text == "")
            {
                messagebox += "\n- Nom de la Ville";
            }

            //Departement
            if (!Regex.IsMatch(tab_Departement_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || tab_Departement_tb.Text == "")
            {
                messagebox += "\n- Nom du Departement";
            }

            //Mail
            if (!Regex.IsMatch(tab_Mail_tb.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || tab_Mail_tb.Text == "")
            {
                messagebox += "\n- Adresse e-mail";
            }

            //Telephone
            if (!Regex.IsMatch(tab_Telephone_tb.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") || tab_Telephone_tb.Text == "")
            {
                messagebox += "\n- Numéro de Telephone";
            }

            //Hierarchie
            if (tab_Hierarchie_cb.Text == "" || tab_Hierarchie_cb.Text != "Salarié" || tab_Hierarchie_cb.Text != "Bénévole")
            {
                messagebox += "\n- Hierarchie invalide : Saisir Salarié OU Bénévole";
            }

            if (messagebox != "Format Invalide. Veulliez saisir des caractères valides pour :")
            {
                MessageBox.Show(messagebox, "Erreur de Saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Person person = new()
                {
                    PersonId = int.Parse(tab_UserID_tb.Text),
                    FirstName = tab_Prenom_tb.Text,
                    LastName = tab_Nom_tb.Text,
                    Email = tab_Mail_tb.Text,
                    PhoneNumber = tab_Telephone_tb.Text,
                    Address = tab_Adresse_tb.Text,
                    ZipCode = tab_CodePostal_tb.Text,
                    City = tab_Ville_tb.Text,
                    Hierarchy = tab_Hierarchie_cb.Text,
                    Password = tab_Password_tb.Text,
                    Zone = tab_Departement_tb.Text
                };

                ModifyPersonViewModel mpvm = new();
                mpvm.ModifyUser(person);
            }

        }
    }
}
