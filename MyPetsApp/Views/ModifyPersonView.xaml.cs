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
            Console.WriteLine("COUCOU" + tab_UserID_tb.Text);
            
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
