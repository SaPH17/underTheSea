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

namespace TPA_Desktop.Views.RaACreativeD
{
    /// <summary>
    /// Interaction logic for RaACreativeD.xaml
    /// </summary>
    public partial class RaACreativeDView : Window
    {
        public RaACreativeDView()
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

        private void addIdeaBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddIdeaView().Show();
        }

        private void viewIdeaResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new IdeaView().Show();
        }

        private void viewAttractionRideBtn_Click(object sender, RoutedEventArgs e)
        {
            new AttractionRideView().Show();
        }

        private void viewConstructionProgressBtn_Click(object sender, RoutedEventArgs e)
        {
            new ConstructionProgressView().Show();
        }
    }
}
