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
    /// Interaction logic for FeedbackView.xaml
    /// </summary>
    public partial class FeedbackView : Window
    {
        public FeedbackView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FeedbackMediator mediator = new FeedbackMediator();
            if(Session.getSession().employee.departmentID == 6)
            {
                feedbackView.ItemsSource = mediator.getAllFeedback("Restaurant");
            }
            else
            {
                feedbackView.ItemsSource = mediator.getAllFeedback("Hotel");
            }
        }
    }
}
