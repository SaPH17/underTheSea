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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Views.All
{
    /// <summary>
    /// Interaction logic for BiodataView.xaml
    /// </summary>
    public partial class BiodataView : Page
    {
        public BiodataView()
        {
            InitializeComponent();
            initializeContent();
        }

        private void initializeContent()
        {
            DepartmentMediator dmediator = new DepartmentMediator();
            nameLbl.Text = "Name : " + Session.getSession().employee.name;
            departmentLbl.Text = "From " + dmediator.getDepartment((int)Session.getSession().employee.departmentID).departmentName;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Session.getSession().employee = null;
            Session.getSession().window.Close();
            Session.getSession().window = null;
            new LoginPage().Show();
        }

        private void viewResponseBtn_Click(object sender, RoutedEventArgs e)
        {
            new PersonalRequestResponseView().Show();
        }

        private void addLeaveRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddLeaveRequestView().Show();
        }

        private void addResignRequestButton_Click(object sender, RoutedEventArgs e)
        {
            new AddResignRequestView().Show();
        }
    }
}
