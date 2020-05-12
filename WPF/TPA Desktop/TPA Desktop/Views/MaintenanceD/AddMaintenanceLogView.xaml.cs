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

namespace TPA_Desktop.Views.MaintenanceD
{
    /// <summary>
    /// Interaction logic for AddMaintenanceLogView.xaml
    /// </summary>
    public partial class AddMaintenanceLogView : Window
    {
        public AddMaintenanceLogView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string scheduleIDStr = scheduleIDTxt.Text.Trim();
            string employeeIDStr = employeeIDTxt.Text.Trim();
            string title = titleTxt.Text.Trim();
            string desc = descTxt.Text.Trim();
            int scheduleID, employeeID;

            bool success = int.TryParse(scheduleIDStr, out scheduleID);
            bool success2 = int.TryParse(employeeIDStr, out employeeID);
            if(!success || !success2)
            {
                errorLbl.Text = "ID must be a number!";
            }
            else if(title == "" || desc == "")
            {
                errorLbl.Text = "Please fill all field";
            }
            else
            {
                if(new MaintenanceScheduleMediator().getMaintenanceSchedule(scheduleID) == null)
                {
                    errorLbl.Text = "Schedule ID is invalid!";
                }
                else if(new EmployeeMediator().getEmployee(employeeID) == null)
                {
                    errorLbl.Text = "Employee ID is invalid!";
                }
                else
                {
                    MaintenanceLogMediator mediator = new MaintenanceLogMediator();
                    MaintenanceLogFactory factory = new MaintenanceLogFactory();

                    MaintenanceLog log = mediator.addMaintenanceLog(factory.createNewMaintenanceLog(scheduleID, employeeID, title, desc));

                    if(log == null)
                    {
                        MessageBox.Show("Add maintenance log failed!");
                    }
                    else
                    {
                        MessageBox.Show("Add maintenance log success!");
                    }
                    this.Close();
                }

            }
        }
    }
}
