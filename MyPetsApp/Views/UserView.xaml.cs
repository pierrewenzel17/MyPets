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
            if (Actual_Password.Password == ActualUserSingleton.GetInstance().Password)
            {
                String newPassword = Actual_Password.Password;

                if (Password.Password != Password_Confirmed.Password)
                {
                    notSameMdp.Visibility = Visibility.Visible;
                    newPassword = Password_Confirmed.Password;
                }
                else
                {
                    notSameMdp.Visibility = Visibility.Hidden;
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

                Password.Password = "";
                Password_Confirmed.Password = "";
                Actual_Password.Password = "";
            }
            else if (Actual_Password.Password.Length == 0)
            {
                NeedMdp.Visibility = Visibility.Visible;
            }
            else
            {
                mdpIsInvalid.Visibility = Visibility.Visible;
                NeedMdp.Visibility = Visibility.Hidden;
            }
        }
    }
}
