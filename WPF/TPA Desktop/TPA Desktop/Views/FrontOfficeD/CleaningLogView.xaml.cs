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
    /// Interaction logic for CleaningLogView.xaml
    /// </summary>
    public partial class CleaningLogView : Window
    {
        public CleaningLogView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CleaningLogMediator mediator = new CleaningLogMediator();
            cleaningLogView.ItemsSource = mediator.getAllCleaningLog();
        }
    }
}
