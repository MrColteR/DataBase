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
    /// Логика взаимодействия для HistoryPriceWindow.xaml
    /// </summary>
    public partial class HistoryPriceWindow : Window
    {
        private void UpdateWindow()
        {
            dgHistoryPrice.ItemsSource = ProcessFactory.GetHistoryPriceProcess().GetList();
        }
        public HistoryPriceWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void tbClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbAdd_Click(object sender, RoutedEventArgs e)
        {
            AddHistoryPrice wnd = new AddHistoryPrice();
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void tbDelete_Click(object sender, RoutedEventArgs e)
        {
            HistoryPriceDto item = dgHistoryPrice.SelectedItem as HistoryPriceDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставку для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить поставку " + item.DateOfChangePrice , "Удаление поставки", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IHistoryPriceProcess historyPriceProcess = ProcessFactory.GetHistoryPriceProcess();
            historyPriceProcess.Delete(item.HistoryID);
            //ProcessFactory.GetSupplierProcess().Delete(item.SupplierID);
            UpdateWindow();
        }

        private void tbUpdate_Click(object sender, RoutedEventArgs e)
        {
            HistoryPriceDto item = dgHistoryPrice.SelectedItem as HistoryPriceDto;
            if (item == null)
            {
                MessageBox.Show("Выберите поставку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddHistoryPrice wnd = new AddHistoryPrice(item);
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            IHistoryPriceProcess supplyDto = ProcessFactory.GetHistoryPriceProcess();
            IList<HistoryPriceDto> supply = supplyDto.ExportHistory();
            string oldFile = @"D:\VSC\VS\GG\ExportHistoryExcel.csv";
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }

            string place = @"D:\VSC\VS\GG\ExportHistoryExcel.csv";
            FileStream fs = new FileStream(place, FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251))) // Encoding.GetEncoding(1251) для русского языка
            {
                sw.WriteLine("HistoryID" + ";" + "NewPrice" + ";" + "DateOfChangePrice" + ";" + "DetailsID" + ";" + "SupplierID");
                foreach (HistoryPriceDto dir in supply)
                {
                    sw.WriteLine(dir.HistoryID + ";" + dir.NewPrice + ";" + dir.DateOfChangePrice + ";" + dir.DetailsID + ";" + dir.SupplierID);
                }
            }
        }
    }
}
