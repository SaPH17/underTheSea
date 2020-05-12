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
    /// Interaction logic for RaiseSalaryView.xaml
    /// </summary>
    public partial class RaiseSalaryView : Window
    {
        public RaiseSalaryView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTxt.Text;
            string description = descTxt.Text;
            string employeeIDStr = employeeIDTxt.Text;
            int employeeID;
            bool success = int.TryParse(employeeIDStr, out employeeID);

            if (title == "" || description == "")
            {
                errorLbl.Text = "Please fill all field!";
            }
            else if (!success)
            {
                errorLbl.Text = "EmployeeID must be a number!";
            }
            else
            {
                HRRequestMediator mediator = new HRRequestMediator();
                HRRequestFactory factory = new HRRequestFactory();
                HRRequest request = mediator.addRequest(factory.createRaiseRequest(title, description, employeeID));
                if (request != null)
                {
                    MessageBox.Show("Request " + request.title + " has been Added!");
                }
                else
                {
                    MessageBox.Show("Sending request failed");
                }
                this.Close();
            }
        }
    }
}
