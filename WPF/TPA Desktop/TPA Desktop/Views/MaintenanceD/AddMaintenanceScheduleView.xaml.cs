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
    /// Interaction logic for AddMaintenanceScheduleView.xaml
    /// </summary>
    public partial class AddMaintenanceScheduleView : Window
    {
        public AddMaintenanceScheduleView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string attractionIDStr = attractionIDTxt.Text.Trim();
            int attractionID;
            DateTime? scheduleDate = scheduleDatePicker.SelectedDate;

            bool success = int.TryParse(attractionIDStr, out attractionID);
            if (!success)
            {
                errorLbl.Text = "Schedule ID must be a number!";
            }
            else if (!scheduleDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                AttractionRideMediator amediator = new AttractionRideMediator();
                if(amediator.getAttractionOrRide(attractionID) == null)
                {
                    errorLbl.Text = "Invalid attraction ID";

                }
                else
                {
                    MaintenanceScheduleMediator mediator = new MaintenanceScheduleMediator();
                    MaintenanceScheduleFactory factory = new MaintenanceScheduleFactory();

                    MaintenanceSchedule schedule = mediator.addMaintenanceSchedule(factory.createNewMaintenanceSchedule(attractionID, scheduleDate));
                    if (schedule == null)
                    {
                        MessageBox.Show("Add maintenance schedule failed!");
                    }
                    else
                    {
                        MessageBox.Show("Add maintenance schedule success!");
                    }
                    this.Close();
                }
            }
        }
    }
}
