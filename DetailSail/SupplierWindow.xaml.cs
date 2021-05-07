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
using System.IO;

namespace DetailSail
{
    /// <summary>
    /// Логика взаимодействия для Supplier.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        public SupplierWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void UpdateWindow()
        {
            dgSupplier.ItemsSource = ProcessFactory.GetSupplierProcess().GetList();
        }

        private void btAdd_click(object sender, RoutedEventArgs e)
        {
            AddSupplier wnd = new AddSupplier();
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void dtDelete_Click(object sender, RoutedEventArgs e)
        {
            SupplierDto item = dgSupplier.SelectedItem as SupplierDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставщика для увольнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить поставщика " + item.Name + " адрес " + item.Address, "Удаление поставщика", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            ISupplierProcess supplierProcess = ProcessFactory.GetSupplierProcess();
            supplierProcess.Delete(item.SupplierID);
            //ProcessFactory.GetSupplierProcess().Delete(item.SupplierID);
            UpdateWindow();
        }

        private void dtUpdate_Click(object sender, RoutedEventArgs e)
        {
            SupplierDto item = dgSupplier.SelectedItem as SupplierDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставщика для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddSupplier wnd = new AddSupplier(item);
            wnd.ShowDialog();
            UpdateWindow();
        }
        private void dtSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchSupplier wnd = new SearchSupplier();
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            ISupplierProcess supplierDto = ProcessFactory.GetSupplierProcess();
            IList<SupplierDto> suppliers = supplierDto.ExportSupplier();
            string place = @"D:\VSC\VS\GG\ExportSupplierExcel.csv";
            FileStream fs = new FileStream(place, FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251))) // Encoding.GetEncoding(1251) для русского языка
            {
                sw.WriteLine("SupplierID" + ";" + "Name" + ";" + "Address" + ";" + "Phone");
                foreach (SupplierDto dir in suppliers)
                {
                    sw.WriteLine(dir.SupplierID + ";" + dir.Name + ";" + dir.Address + ";" + dir.Phone);
                }
            }
        }
    }
}
