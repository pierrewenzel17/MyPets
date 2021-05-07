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

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour NewPerson.xaml
    /// </summary>
    public partial class NewPerson : UserControl
    {
        public NewPerson()
        {
            InitializeComponent();
        }

        public void createbtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (New_Nom_tb.Text == "" ||
                New_Prenom_tb.Text == "" ||
                New_Adresse_tb.Text == "" ||
                New_CodePostal_tb.Text == "" ||
                New_Departement_tb.Text == "" ||
                New_Mail_tb.Text == "" ||
                New_Telephone_tb.Text == "" ||
                New_Ville_tb.Text == "")
            {
                New_NeedInfo.Visibility = Visibility.Visible;
            }
            else
            {
                New_NeedInfo.Visibility = Visibility.Hidden;

                if (New_Password.Password != New_Password_Confirmed.Password)
                {
                    New_notSameMdp.Visibility = Visibility.Visible;
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

                    NewPersonModel npm = new();
                    npm.CreateUser(person);
                }

            }
        }
    }
}
