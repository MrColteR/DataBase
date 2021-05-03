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
using VRA.Dto;
using BuisnessLayer;

namespace DetailSail
{
    /// <summary>
    /// Логика взаимодействия для AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        private SupplierDto supplierDto;
        private void LoadSupplier()
        {
            if (supplierDto == null)
            {
                return;
            }

            tbName.Text = supplierDto.Name;
            tbAddress.Text = supplierDto.Address;
            tbPhone.Text = supplierDto.Phone;
        }
        public AddSupplier(SupplierDto supplier = null)
        {
            supplierDto = supplier;
            InitializeComponent();
            LoadSupplier();
        }

        private void bt_Save_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя поставщика должно быть заполнена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Адрес поставщика должен быть заполнен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                MessageBox.Show("Телефон поставщика должен быть заполнен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (supplierDto == null)
            { 
                supplierDto = new SupplierDto();
                supplierDto.Name = tbName.Text;
                supplierDto.Address = tbAddress.Text;
                supplierDto.Phone = tbPhone.Text;

                ISupplierProcess supplierProcess = ProcessFactory.GetSupplierProcess();
                supplierProcess.Add(supplierDto);
            }
            else
            {
                supplierDto.Name = tbName.Text;
                supplierDto.Address = tbAddress.Text;
                supplierDto.Phone = tbPhone.Text;

                ISupplierProcess supplierProcess = ProcessFactory.GetSupplierProcess();
                supplierProcess.Update(supplierDto);
            }

            Close();
        }
        private void Button_Close_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
