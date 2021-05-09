using System;
using System.Windows;
using System.Windows.Controls;
using MyPetsApp.Utils;
using MyPetsApp.ViewModels;

namespace MyPetsApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (ActualUserSingleton.GetInstance().Hierarchy != "Administrateur")
            {
                ListViewMenu.Items.RemoveAt(1);
                ListViewMenu.Items.RemoveAt(1);
            }
        }

        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            if (ActualUserSingleton.GetInstance().Hierarchy != "Administrateur")
            {
                DataContext = index switch
                {
                    0 => new UserViewModel(),
                    1 => new InvestigationViewModel(),
                    2 => new NewInvestigationViewModel(),
                    _ => DataContext
                };
            }
            else
            {
                DataContext = index switch
                {
                    0 => new UserViewModel(),
                    1 => new PersonViewModel(),
                    2 => new NewPersonViewModel(),
                    3 => new InvestigationViewModel(),
                    4 => new NewInvestigationViewModel(),
                    _ => DataContext
                };
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (60 * index), 0, 0);
        }

        private void DisconnectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ActualUserSingleton.Reset();
            
            Window window = new LoginView();
            window.Show();

            this.Close();
        }
    }
}
