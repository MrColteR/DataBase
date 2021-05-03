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
    /// Логика взаимодействия для DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private void UpdateWindow()
        {
            dgDetails.ItemsSource = ProcessFactory.GetDetailsProcess().GetList();
        }
        public DetailsWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            DetailsDto item = dgDetails.SelectedItem as DetailsDto;
            if (item == null)
            {
                MessageBox.Show("Выберите деталь для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddDetails wnd = new AddDetails(item);
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            DetailsDto item = dgDetails.SelectedItem as DetailsDto;
            if (item == null)
            {
                MessageBox.Show("Выберите деталь для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить деталь " + item.Name + " цена " + item.Price, "Удаление детали", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IDetailsProcess detailsProcess = ProcessFactory.GetDetailsProcess();
            detailsProcess.Delete(item.DetailsID);
            //ProcessFactory.GetSupplierProcess().Delete(item.SupplierID);
            UpdateWindow();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDetails wnd = new AddDetails();
            wnd.ShowDialog();
            UpdateWindow();
        }
    }
}
