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

namespace TPA_Desktop.Views.PurchasingD
{
    /// <summary>
    /// Interaction logic for PurchasingD.xaml
    /// </summary>
    public partial class PurchasingDView : Window
    {
        public PurchasingDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void addPurchaseLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchaseLogView().Show();
        }

        private void addFinanceRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFinanceRequestView().Show();
        }

        private void viewPurchaseRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestView().Show();
        }

        private void viewPurchaseLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new PurchaseLogView().Show();
        }

        private void viewRequestResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestResponseView().Show();
        }
    }
}
