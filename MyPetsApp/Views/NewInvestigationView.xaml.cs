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
                MessageBox.Show("Création bien effectuée", "Création d'une enquête", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
