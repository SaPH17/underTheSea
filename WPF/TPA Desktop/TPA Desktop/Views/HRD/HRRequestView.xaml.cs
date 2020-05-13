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
using TPA_Desktop.Model;

namespace TPA_Desktop.Views.HRD
{
    /// <summary>
    /// Interaction logic for HRRequestView.xaml
    /// </summary>
    public partial class HRRequestView : Window
    {
        public HRRequestView()
        {
            InitializeComponent();
            newSalaryLbl.Visibility = Visibility.Hidden;
            newSalaryTxt.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HRRequestMediator mediator = new HRRequestMediator();
            HRRequestResponseView.ItemsSource = mediator.getAllHRRequest();
        }

        private void HRrequestIDTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string requestIDStr = HRrequestIDTxt.Text.Trim();
            int requestID;

            bool success = int.TryParse(requestIDStr, out requestID);
            if(!success && HRrequestIDTxt.Text != "")
            {
                errorLbl.Text = "Request ID must be a number!";
            }
            else
            {
                HRRequestMediator mediator = new HRRequestMediator();
                HRRequest request = mediator.getHRRequest(requestID);
                if(request == null)
                {
                    return;
                }
                if(request.type == "Raise")
                {
                    newSalaryLbl.Visibility = Visibility.Visible;
                    newSalaryTxt.Visibility = Visibility.Visible;
                }
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string requestIDStr = HRrequestIDTxt.Text.Trim();
            int requestID;

            bool success = int.TryParse(requestIDStr, out requestID);
            if (!success)
            {
                errorLbl.Text = "Request ID must be a number!";
            }
            else
            {
                HRRequestMediator mediator = new HRRequestMediator();
                HRRequest request = mediator.getHRRequest(requestID);
                if(request.status == "Pending")
                {
                    errorLbl.Text = "Please wait for manager's response!";
                }
                else if(request.status == "Declined")
                {
                    errorLbl.Text = "Request is declined!";
                }
                else
                {
                    if (request.type == "Raise")
                    {
                        int salary;
                        success = int.TryParse(newSalaryTxt.Text.Trim(), out salary);

                        if (newSalaryTxt.Text == "")
                        {
                            errorLbl.Text = "Please input new salary!";
                        }
                        else if (!success)
                        {
                            errorLbl.Text = "New salary must be a number!";
                        }
                        else
                        {
                            EmployeeMediator emediator = new EmployeeMediator();
                            Employee employee = emediator.getEmployee((int)request.employeeID);
                            employee.salary = salary;
                            employee = emediator.updateEmployee(employee.employeeID, employee);
                            if (employee == null)
                            {
                                MessageBox.Show("Raise salary failed!");
                            }
                            else
                            {
                                MessageBox.Show("Raise salary success!");
                            }
                        }
                    }
                    else
                    {
                        EmployeeMediator emediator = new EmployeeMediator();
                        Employee employee = emediator.getEmployee((int)request.employeeID);
                        employee.status = "Inactive";
                        employee = emediator.updateEmployee(employee.employeeID, employee);
                        if(employee == null)
                        {
                            MessageBox.Show("Fire employee failed!");
                        }
                        else
                        {
                            MessageBox.Show("Fire employee success!");
                        }
                    }
                }
                
            }
        }
    }
}
