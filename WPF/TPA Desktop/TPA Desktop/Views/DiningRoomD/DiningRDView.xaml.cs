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
using TPA_Desktop.Views.KitchenD;

namespace TPA_Desktop.Views.DiningRoomD
{
    /// <summary>
    /// Interaction logic for DiningRD.xaml
    /// </summary>
    public partial class DiningRDView : Window
    {
        public DiningRDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddOrderView().Show();
        }

        private void viewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new OrderView().Show();
        }

        private void viewSeatBtn_Click(object sender, RoutedEventArgs e)
        {
            new SeatView().Show();
        }

        private void viewFeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            new FeedbackView().Show();
        }

        private void checkTicketBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void checkoutOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckoutOrderView().Show();
        }
    }
}
