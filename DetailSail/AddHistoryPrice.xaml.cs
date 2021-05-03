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
    /// Логика взаимодействия для AddHistoryPrice.xaml
    /// </summary>
    public partial class AddHistoryPrice : Window
    {
        private HistoryPriceDto priceHistoryDto;
        private void LoadPriceHistory()
        {
            if (priceHistoryDto == null)
            {
                return;
            }

            tbSupplierID.Text = priceHistoryDto.SupplierID.ToString();
            tbDetailsID.Text = priceHistoryDto.DetailsID.ToString();
            tbNewPrice.Text = priceHistoryDto.NewPrice.ToString();
            tbDateOfChangePrice.Text = priceHistoryDto.DateOfChangePrice.ToString();
        }
        public AddHistoryPrice(HistoryPriceDto priceHistory = null)
        {
            priceHistoryDto = priceHistory;
            InitializeComponent();
            LoadPriceHistory();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSupplierID.Text))
            {
                MessageBox.Show("ID поставщика должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbDetailsID.Text))
            {
                MessageBox.Show("ID детали должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbNewPrice.Text))
            {
                MessageBox.Show("Новая цена должна быть заполнена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbDateOfChangePrice.Text))
            {
                MessageBox.Show("Дата смены цены должна быть заполнена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (priceHistoryDto == null)
            {
                priceHistoryDto = new HistoryPriceDto();
                priceHistoryDto.SupplierID = Convert.ToInt32(tbSupplierID.Text);
                priceHistoryDto.DetailsID = Convert.ToInt32(tbDetailsID.Text);
                priceHistoryDto.NewPrice = Convert.ToInt32(tbNewPrice.Text);
                priceHistoryDto.DateOfChangePrice = Convert.ToDateTime(tbDateOfChangePrice.Text);

                IHistoryPriceProcess historyPriceProcess = ProcessFactory.GetHistoryPriceProcess();
                historyPriceProcess.Add(priceHistoryDto);
            }
            else
            {
                priceHistoryDto.SupplierID = Convert.ToInt32(tbSupplierID.Text);
                priceHistoryDto.DetailsID = Convert.ToInt32(tbDetailsID.Text);
                priceHistoryDto.NewPrice = Convert.ToInt32(tbNewPrice.Text);
                priceHistoryDto.DateOfChangePrice = Convert.ToDateTime(tbDateOfChangePrice.Text);

                IHistoryPriceProcess historyPriceProcess = ProcessFactory.GetHistoryPriceProcess();
                historyPriceProcess.Update(priceHistoryDto);
            }

            Close();
        }
    }
}
