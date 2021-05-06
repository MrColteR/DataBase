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
    /// Логика взаимодействия для SearchDetail.xaml
    /// </summary>
    public partial class SearchDetail : Window
    {
        private DetailsDto detailsDto;
        private void UpdateWindow()
        {
            dgSearchDetail.ItemsSource = ProcessFactory.GetDetailsProcess().GetList();
        }
        public SearchDetail()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string forSearch = tbName.Text;
            IDetailsProcess searchDetailProcess = ProcessFactory.GetDetailsProcess();
            IList<DetailsDto> details = searchDetailProcess.SearchDetail(forSearch);
            dgSearchDetail.ItemsSource = details;

            if (detailsDto == null)
            {
                detailsDto = new DetailsDto();
                detailsDto.Name = tbName.Text;

                IDetailsProcess detailProcess = ProcessFactory.GetDetailsProcess();
                detailProcess.SearchDetail(detailsDto.ToString());
            }
        }
    }
}
