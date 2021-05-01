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
using MyPetsApp.Utils;
using MyPetsApp.ViewModels;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Logique d'interaction pour LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LogInBtn_OnClick(object sender, RoutedEventArgs e)
        {
            LogInViewModel logInViewModel = new();
            logInViewModel.Connection(Username.Text, Password.Password);
            //if (ActualUserSingleton.GetInstance() != null)
            //{
                Window fenster = new MainWindow();
                fenster.DataContext = new UserViewModel();
                fenster.Show();

                this.Close();
            /*}
            else
            {
                error.Visibility = Visibility.Visible;
            }*/
        }
    }
}
