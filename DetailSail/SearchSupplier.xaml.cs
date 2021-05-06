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
    /// Логика взаимодействия для SearchSupplier.xaml
    /// </summary>
    public partial class SearchSupplier : Window
    {
        private SupplierDto supplierDto;

        private void UpdateWindow()
        {
            dgSearchSupplier.ItemsSource = ProcessFactory.GetSupplierProcess().GetList();
        }
        public SearchSupplier()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSearch_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string forSearch = tbName.Text;
            ISupplierProcess searchSupplierProcess = ProcessFactory.GetSupplierProcess();
            IList<SupplierDto> suppliers = searchSupplierProcess.SearchSupplier(forSearch);
            dgSearchSupplier.ItemsSource = suppliers;

            if (supplierDto == null)
            {
                supplierDto = new SupplierDto();
                supplierDto.Name = tbName.Text;

                ISupplierProcess supplierProcess = ProcessFactory.GetSupplierProcess();
                supplierProcess.SearchSupplier(supplierDto.ToString());
            }
        }
    }
}
