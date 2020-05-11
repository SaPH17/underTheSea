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

namespace TPA_Desktop.Views.HRD
{
    /// <summary>
    /// Interaction logic for HRDView.xaml
    /// </summary>
    public partial class HRDView : Window
    {
        public HRDView()
        {
            InitializeComponent();
            Biodata.Content = new BiodataView();
            
        }

        private void viewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeView().Show();
        }

        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeView().Show(); 
        }

        private void fireEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            new FireEmployeeView().Show();
        }

        private void raiseSalaryBtn_Click(object sender, RoutedEventArgs e)
        {
            new RaiseSalaryView().Show();
        }

        private void paySalaryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void viewLeavePermitBtn_Click(object sender, RoutedEventArgs e)
        {
            new PersonalRequestView().Show();
        }

        private void viewResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new HRRequestView().Show();
        }

        private void viewFinanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new RequestResponseView().Show();
        }

        private void sendFinanceBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFinanceRequestView().Show();
        }
    }
}
