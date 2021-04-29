using System.Windows;
using MyPetsApp.ViewModels;
using MyPetsApp.Views;

namespace MyPetsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new LoginView();
            window.Show();
            base.OnStartup(e);
        }
    }
}
