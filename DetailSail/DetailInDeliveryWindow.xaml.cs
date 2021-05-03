using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BuisnessLayer;
using VRA.Dto;

namespace DetailSail
{
    /// <summary>
    /// Логика взаимодействия для DetailInDeliveryWindow.xaml
    /// </summary>
    public partial class DetailInDeliveryWindow : Window
    {
        private void UpdateWindow()
        {
            dgDetailInDelivery.ItemsSource = ProcessFactory.GetDetailInDeliveryProcess().GetList();
        }
        public DetailInDeliveryWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
