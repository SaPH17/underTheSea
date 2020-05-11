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
using System.Windows.Shapes;
using TPA_Desktop.Views.All;

namespace TPA_Desktop.Views.SalesMarketingD
{
    /// <summary>
    /// Interaction logic for SalesMDView.xaml
    /// </summary>
    public partial class SalesMDView : Window
    {
        public SalesMDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void addAdvertisementLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddAdvertisementLogView().Show();
        }

        private void viewAdvertisementLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdvertisementLogView().Show();
        }

        private void addPurchaseRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchaseRequestView().Show();
        }

        private void viewRequestResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestResponseView().Show();
        }

        private void addFundRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFinanceRequestView().Show();
        }
    }
}
