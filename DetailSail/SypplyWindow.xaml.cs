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
    /// Логика взаимодействия для SypplyWindow.xaml
    /// </summary>
    public partial class SypplyWindow : Window
    {
        public SypplyWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }
        private void UpdateWindow() 
        {
            dgSupply.ItemsSource = ProcessFactory.GetSupplyProcess().GetList();
        }

        private void btClose_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            SupplyDto item = dgSupply.SelectedItem as SupplyDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddSupply wnd = new AddSupply(item);
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            SupplyDto item = dgSupply.SelectedItem as SupplyDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставку для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить поставку " + item.Date + " дата " + item.Amount, "Удаление поставки", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            ISupplyProcess supplyProcess = ProcessFactory.GetSupplyProcess();
            supplyProcess.Delete(item.SupplyID);
            //ProcessFactory.GetSupplierProcess().Delete(item.SupplierID);
            UpdateWindow();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSupply wnd = new AddSupply();
            wnd.ShowDialog();
            UpdateWindow();
        }
    }
}
