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
using TPA_Desktop.Mediator;

namespace TPA_Desktop.Views.DiningRoomD
{
    /// <summary>
    /// Interaction logic for SeatView.xaml
    /// </summary>
    public partial class SeatView : Window
    {
        public SeatView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SeatMediator mediator = new SeatMediator();
            seatView.ItemsSource = mediator.getAllSeat();
        }
    }
}
