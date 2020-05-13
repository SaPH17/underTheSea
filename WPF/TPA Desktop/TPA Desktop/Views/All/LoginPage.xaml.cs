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
using TPA_Desktop.Views;
using TPA_Desktop.Views.AccountingFD;
using TPA_Desktop.Views.AttractionD;
using TPA_Desktop.Views.ConstructionD;
using TPA_Desktop.Views.DiningRoomD;
using TPA_Desktop.Views.FrontOfficeD;
using TPA_Desktop.Views.HouseKeepingD;
using TPA_Desktop.Views.HRD;
using TPA_Desktop.Views.KitchenD;
using TPA_Desktop.Views.MaintenanceD;
using TPA_Desktop.Views.Manager;
using TPA_Desktop.Views.PurchasingD;
using TPA_Desktop.Views.RaACreativeD;
using TPA_Desktop.Views.SalesMarketingD;

namespace TPA_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text.Trim();
            string password = passwordTxt.Password.Trim();

            if(name == "")
            {
                errorLbl.Text = "Please fill name!";
            }
            else if(password == "")
            {
                errorLbl.Text = "Please fill password!";
            }
            else
            {
                
                EmployeeMediator mediator = new EmployeeMediator();
                Employee employee = mediator.getEmployee(name, password);
                
                if(name == "customer" && password == "customer123")
                {
                    this.Visibility = Visibility.Hidden;
                    CustomerView cview = new CustomerView();
                    Session.getSession().window = cview;
                    cview.Show();
                }
                else if (employee == null)
                {
                    errorLbl.Text = "Name/Password is incorrect";
                }
                else
                {
                    Session.getSession().employee = employee;

                    Window[] views = new Window[]{ new AttractionDView(), new MaintenanceDView(), new RaACreativeDView(), new ConstructionDView(), new DiningRDView(),
                            new KitchenDView(), new PurchasingDView(), new AccountingFDView(), new FrontOfficeDView(), new HouseKeepingDView(),
                                new SalesMDView(), new HRDView(), new ManagerView() };

                    this.Visibility = Visibility.Hidden;
                    int departmentID = (int) employee.departmentID - 1;
                    Session.getSession().window = views[departmentID];
                    views[departmentID].Show();
                }
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
