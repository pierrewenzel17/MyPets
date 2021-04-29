﻿using System;
using System.Windows;
using System.Windows.Controls;
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
        }

        private void ListViewMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            DataContext = index switch
            {
                0 => new UserViewModel(),
                1 => new PersonViewModel(),
                2 => new InvestigationViewModel(),
                _ => DataContext
            };
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (60 * index), 0, 0);
        }

        private void DisconnectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Window window = new LoginView();
            window.Show();

            this.Close();
        }
    }
}
