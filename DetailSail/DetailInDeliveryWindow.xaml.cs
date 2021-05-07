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
    /// Логика взаимодействия для DetailInDeliveryWindow.xaml
    /// </summary>
    public partial class DetailInDeliveryWindow : Window
    {
        private void UpdateWindow()
        {
            dgDetailInDelivery.ItemsSource = ProcessFactory.GetDetailInDeliveryProcess().GetList();
        }
        public DetailInDeliveryWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            IDetailInDeliveryProcess detailInDeliveryDto = ProcessFactory.GetDetailInDeliveryProcess();
            IList<DetailInDeliveryDto> detailInDelivery = detailInDeliveryDto.ExportDetailInDelivery();
            string place = @"D:\VSC\VS\GG\ExportDetailInDeliveryExcel.csv";
            FileStream fs = new FileStream(place, FileMode.CreateNew);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251))) // Encoding.GetEncoding(1251) для русского языка
            {
                sw.WriteLine("Number" + ";" + "SupplyID" + ";" + "HistoryID" + ";" + "DetailID");
                foreach (DetailInDeliveryDto dir in detailInDelivery)
                {
                    sw.WriteLine(dir.Number + ";" + dir.SupplyID + ";" + dir.HistoryID + ";" + dir.DetailID);
                }
            }
        }
    }
}
