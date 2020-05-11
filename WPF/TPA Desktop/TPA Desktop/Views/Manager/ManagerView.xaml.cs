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

namespace TPA_Desktop.Views.Manager
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
        }

        private void viewResignRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new PersonalRequestView().Show();
        }

        private void viewIncomeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void viewIdeaRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new IdeaView().Show();
        }
    }
}
