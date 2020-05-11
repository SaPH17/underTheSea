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
using TPA_Desktop.Factory;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Views.HRD
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : Window
    {
        public AddEmployeeView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string password = passwordTxt.Password;
            string salaryStr = salaryTxt.Text;
            string department = (string) ((ComboBoxItem)deptComboBox.SelectedValue).Content;
            DateTime? dob = dobDate.SelectedDate;
            int salary;
            bool flag = int.TryParse(salaryStr, out salary);

            if (!flag)
            {
                errorLbl.Text = "Salary must be a number!";
            }
            else if(name == "" || password == "" || !dob.HasValue || deptComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please fill all field!";
            }
            else
            {
                EmployeeMediator mediator = new EmployeeMediator();
                EmployeeFactory factory = new EmployeeFactory();

                Employee employee = mediator.addEmployee(factory.createNewEmployee(name, password, salary, dob, department));
                if(employee != null)
                {
                    MessageBox.Show("Employee " + employee.name + " has been Added!");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Add employee failed!");
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
