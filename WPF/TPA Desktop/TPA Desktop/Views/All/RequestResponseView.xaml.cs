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

namespace TPA_Desktop.Views.All
{
    /// <summary>
    /// Interaction logic for RequestResponseView.xaml
    /// </summary>
    public partial class RequestResponseView : Window
    {
        public RequestResponseView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RequestMediator mediator = new RequestMediator();
            requestResponseView.ItemsSource = mediator.getAllRequest((int)Session.session.employee.departmentID);
        }
    }
}
