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
using MyPetsApp.Utils;
using MyPetsApp.ViewModels;
using MyPetsCore.DTOs;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = ActualUserSingleton.GetInstance();
        }

        public void saveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string messagebox = "Format Invalide. Veulliez saisir des caractères valides pour :";

            //Adresse
            if (!Regex.IsMatch(Adresse_tb.Text, @"^[a-zA-Z0-9éèà'-ç ]*$") || Adresse_tb.Text == "")
            {
                messagebox += "\n- Adresse Postale";
            }

            //Code Postal
            if (!Regex.IsMatch(CodePostal_tb.Text, "[0-9]{5}") || CodePostal_tb.Text == "")
            {
                messagebox += "\n- Code Postal";
            }

            //Ville
            if (!Regex.IsMatch(Ville_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || Ville_tb.Text == "")
            {
                messagebox += "\n- Nom de la Ville";
            }

            //Departement
            if (!Regex.IsMatch(Departement_tb.Text, @"^[a-zA-Zéèà'-ç/ ]*$") || Departement_tb.Text == "")
            {
                messagebox += "\n- Nom du Departement";
            }

            //Mail
            if (!Regex.IsMatch(Mail_tb.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || Mail_tb.Text == "")
            {
                messagebox += "\n- Adresse e-mail";
            }

            //Telephone
            if (!Regex.IsMatch(Telephone_tb.Text, @"(?:(?:\+|00)33|0)\s*[1-9](?:[\s.-]*\d{2}){4}") || Telephone_tb.Text == "")
            {
                messagebox += "\n- Numéro de Telephone";
            }

            if (Actual_Password.Password == ActualUserSingleton.GetInstance().Password)
            {
                String newPassword = Actual_Password.Password;

                if ((Password.Password != Password_Confirmed.Password) & (Password.Password != ""))
                {
                    notSameMdp.Visibility = Visibility.Visible;
                    messagebox += "\n- Mots de passe différents";
                }
                else
                {
                    notSameMdp.Visibility = Visibility.Hidden;
                    newPassword = Password_Confirmed.Password;
                }

                NeedMdp.Visibility = Visibility.Hidden;
                mdpIsInvalid.Visibility = Visibility.Hidden;

                Person person = new()
                {
                    PersonId = ActualUserSingleton.GetInstance().PersonId,
                    FirstName = ActualUserSingleton.GetInstance().FirstName,
                    LastName = ActualUserSingleton.GetInstance().LastName,
                    Email = Mail_tb.Text,
                    PhoneNumber = Telephone_tb.Text,
                    Address = Adresse_tb.Text,
                    ZipCode = CodePostal_tb.Text,
                    City = Ville_tb.Text,
                    Hierarchy = ActualUserSingleton.GetInstance().Hierarchy,
                    Password = newPassword,
                    Zone = Departement_tb.Text
                };

                UserViewModel uvm = new();
                uvm.ModifyUser(person);

                MessageBox.Show(messagebox, "Modification effectuée !", MessageBoxButton.OK, MessageBoxImage.Information);

                Password.Password = "";
                Password_Confirmed.Password = "";
                Actual_Password.Password = "";
            }
            else if (Actual_Password.Password.Length == 0)
            {
                NeedMdp.Visibility = Visibility.Visible;
                messagebox += "\n- Mot de passe actuel nécéssaire";
            }
            else
            {
                mdpIsInvalid.Visibility = Visibility.Visible;
                NeedMdp.Visibility = Visibility.Hidden;
                messagebox += "\n- Mot de passe incorrect";
            }

            if(messagebox != "Format Invalide. Veulliez saisir des caractères valides pour :")
                MessageBox.Show(messagebox, "Erreur de Saisie", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
