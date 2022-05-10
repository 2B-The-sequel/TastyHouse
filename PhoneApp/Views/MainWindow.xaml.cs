﻿using PhoneApp.ViewModels;
using PhoneApp.Views;
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

namespace DesignIdeTastyHouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainViewModel mvm;
        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainViewModel();  
            DataContext = mvm;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage mp = new();
            MainFrameWindow.Navigate(mp);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility = Visibility.Visible;

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Index.Visibility = Visibility.Visible;
            MainFrameWindow.Visibility = Visibility.Hidden;
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactPage copa = new();
            MainFrameWindow.Navigate(copa);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility= Visibility.Visible;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            CartPage capa = new();
            MainFrameWindow.Navigate(capa);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility = Visibility.Visible;
        }
    }
}