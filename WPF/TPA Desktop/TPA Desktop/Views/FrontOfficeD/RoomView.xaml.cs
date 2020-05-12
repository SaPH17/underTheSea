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

namespace TPA_Desktop.Views.FrontOfficeD
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : Window
    {
        public RoomView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RoomMediator mediator = new RoomMediator();
            roomView.ItemsSource = mediator.getAllRoom();
        }
    }
}
