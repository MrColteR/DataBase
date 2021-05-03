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
    /// Логика взаимодействия для AddDetails.xaml
    /// </summary>
    public partial class AddDetails : Window
    {
        private DetailsDto detailsDto;
        private void LoadSupply()
        {
            if (detailsDto == null)
            {
                return;
            }

            tbArticle.Text = detailsDto.Article.ToString();
            tbPrice.Text = detailsDto.Price.ToString();
            tbNote.Text = detailsDto.Note.ToString();
            tbName.Text = detailsDto.Name.ToString();
        }
        public AddDetails(DetailsDto details = null)
        {
            detailsDto = details;
            InitializeComponent();
            LoadSupply();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbArticle.Text))
            {
                MessageBox.Show("Артикул должен быть заполнен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                MessageBox.Show("Цена должна быть указана", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbNote.Text))
            {
                MessageBox.Show("Описание должно быть указано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Название детали должно быть указано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (detailsDto == null)
            {
                detailsDto = new DetailsDto();
                detailsDto.Article = Convert.ToInt32(tbArticle.Text);
                detailsDto.Price = Convert.ToInt32(tbPrice.Text);
                detailsDto.Note = Convert.ToString(tbNote.Text);
                detailsDto.Name = Convert.ToString(tbName.Text);

                IDetailsProcess detailsProcess = ProcessFactory.GetDetailsProcess();
                detailsProcess.Add(detailsDto);
            }
            else
            {
                detailsDto.Article = Convert.ToInt32(tbArticle.Text);
                detailsDto.Price = Convert.ToInt32(tbPrice.Text);
                detailsDto.Note = Convert.ToString(tbNote.Text);
                detailsDto.Name = Convert.ToString(tbName.Text);

                IDetailsProcess detailsProcess = ProcessFactory.GetDetailsProcess();
                detailsProcess.Update(detailsDto);
            }

            Close();
        }
    }
}
