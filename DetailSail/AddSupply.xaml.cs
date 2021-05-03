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
    /// Логика взаимодействия для AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Window
    {
        private SupplyDto supplyDto;
        private void LoadSupply()
        {
            if (supplyDto == null)
            {
                return;
            }

            tbAmount.Text = supplyDto.Amount.ToString();
            tbDate.Text = supplyDto.Date.ToString();
            tbSupplierID.Text = supplyDto.SupplierID.ToString();
        }
        public AddSupply(SupplyDto supply = null)
        {
            supplyDto = supply;
            InitializeComponent();
            LoadSupply();
        }

        private void btClose_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSave_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAmount.Text))
            {
                MessageBox.Show("Количество должно быть заполнено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbDate.Text))
            {
                MessageBox.Show("Дата должна быть указана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbSupplierID.Text))
            {
                MessageBox.Show("ID поставищика должен быть указан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (supplyDto == null)
            {
                supplyDto = new SupplyDto();
                supplyDto.Amount = Convert.ToInt32(tbAmount.Text);
                supplyDto.Date = Convert.ToDateTime(tbDate.Text);
                supplyDto.SupplierID = Convert.ToInt32(tbSupplierID.Text);

                ISupplyProcess supplyProcess = ProcessFactory.GetSupplyProcess();
                supplyProcess.Add(supplyDto);
            }
            else
            {
                supplyDto.Amount = Convert.ToInt32(tbAmount.Text);
                supplyDto.Date = Convert.ToDateTime(tbDate.Text);
                supplyDto.SupplierID = Convert.ToInt32(tbSupplierID.Text);

                ISupplyProcess supplyProcess = ProcessFactory.GetSupplyProcess();
                supplyProcess.Update(supplyDto);
            }

            Close();
        }
    }
}
