using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetailSail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow wnd = new SupplierWindow();
            wnd.ShowDialog();
        }

        private void btClose_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btSupply_click(object sender, RoutedEventArgs e)
        {
            SypplyWindow wnd = new SypplyWindow();
            wnd.ShowDialog();
        }

        private void btDetails_click(object sender, RoutedEventArgs e)
        {
            DetailsWindow wnd = new DetailsWindow();
            wnd.ShowDialog();
        }

        private void btHistory_click(object sender, RoutedEventArgs e)
        {
            HistoryPriceWindow wnd = new HistoryPriceWindow();
            wnd.ShowDialog();
        }

        private void btDetailInDelivery_click(object sender, RoutedEventArgs e)
        {
            DetailInDeliveryWindow wnd = new DetailInDeliveryWindow();
            wnd.ShowDialog();
        }
    }
}
