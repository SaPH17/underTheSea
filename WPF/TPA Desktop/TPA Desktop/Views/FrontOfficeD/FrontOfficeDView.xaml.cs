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
using TPA_Desktop.Views.DiningRoomD;
using TPA_Desktop.Views.HouseKeepingD;

namespace TPA_Desktop.Views.FrontOfficeD
{
    /// <summary>
    /// Interaction logic for FrontOfficeDView.xaml
    /// </summary>
    public partial class FrontOfficeDView : Window
    {
        public FrontOfficeDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void viewFeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            new FeedbackView().Show();
        }

        private void addCleaningScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCleaningScheduleView().Show();
        }

        private void viewCleaningLogBtn_Click(object sender, RoutedEventArgs e)
        {
            new CleaningLogView().Show();
        }

        private void viewAllRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            new RoomView().Show();
        }

        private void checkinCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckInView().Show();
        }

        private void checkoutCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckOutView().Show();
        }

        private void viewReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            new ReservationView().Show();
        }
    }
}
