﻿using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContentRepo CR = new ContentRepo();
        public MainViewModel MVM;

        public MainWindow()
        {
            InitializeComponent();
            MVM = new MainViewModel();
            DataContext = MVM;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            AcceptDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.SelectedOrder.State = OrderState.Accepted;
            }
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil afvise orderen?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.SelectedOrder.State = OrderState.Declined;
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            MVM.SelectedOrder.State = OrderState.Done;
        }

        private void New_Menu(object sender, RoutedEventArgs e)
        {
            NewMenu dialog = new();
            if (dialog.ShowDialog() == true)
            {

            }
        }
        private void AddNewContent(object sender, RoutedEventArgs e)
        {

            NewContent dialog = new();
            if (dialog.ShowDialog() == true)
            {
                Content content = new Content(dialog.name, dialog.price);
                ContentViewModel CVM = new(content);
                CR.Add(content);
                MVM.Contents.Add(CVM);
            }
            
        }
        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            
            int id = int.Parse(MVM.SelectedContent.Id.ToString());
            
            CR.Remove(id);
            
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil afvise orderen?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                
            }
        }
    }
}