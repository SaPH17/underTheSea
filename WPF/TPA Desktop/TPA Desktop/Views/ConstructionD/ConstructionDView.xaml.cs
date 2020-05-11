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
using TPA_Desktop.Views.RaACreativeD;

namespace TPA_Desktop.Views.ConstructionD
{
    /// <summary>
    /// Interaction logic for ConstructionD.xaml
    /// </summary>
    public partial class ConstructionDView : Window
    {
        public ConstructionDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void addFinanceRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFinanceRequestView().Show();
        }

        private void addPurchaseRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPurchaseRequestView().Show();
        }

        private void viewRequestResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestResponseView().Show();
        }

        private void viewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            new TaskView().Show();
        }

        private void addConstructionProgressBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddConstructionProgressView().Show();
        }

        private void changeStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            new ChangeAttractionRideStatusView().Show();
        }

        private void viewAttractionOrRideBtn_Click(object sender, RoutedEventArgs e)
        {
            new AttractionRideView().Show();
        }
    }
}
