﻿using System.Windows;

namespace DataToExcelLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainViewModel();
            DataContext = vm;
        }
    }
}
