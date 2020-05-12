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

namespace TPA_Desktop.Views.MaintenanceD
{
    /// <summary>
    /// Interaction logic for MaintenanceScheduleView.xaml
    /// </summary>
    public partial class MaintenanceScheduleView : Window
    {
        public MaintenanceScheduleView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            MaintenanceScheduleMediator mediator = new MaintenanceScheduleMediator();
            maintenanceScheduleView.ItemsSource = mediator.getAllMaintenanceSchedule();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string scheduleIDStr = scheduleIDTxt.Text.Trim();
            string attractionIDStr = attractionIDTxt.Text.Trim();
            int scheduleID, attractionID;
            DateTime? scheduleDate = scheduleDatePicker.SelectedDate;

            bool success = int.TryParse(scheduleIDStr, out scheduleID);
            bool success2 = int.TryParse(attractionIDStr, out attractionID);

            if (!success || !success2)
            {
                errorLbl.Text = "Schedule ID must be a number!";
            }
            else if (!scheduleDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                MaintenanceScheduleMediator mediator = new MaintenanceScheduleMediator();

                MaintenanceSchedule schedule = mediator.getMaintenanceSchedule(scheduleID);
                schedule.attractionID = attractionID;
                schedule.scheduleDate = scheduleDate;

                schedule = mediator.updateMaintenanceSchedule(scheduleID, schedule);
                if (schedule == null)
                {
                    MessageBox.Show("Update maintenance schedule failed!");
                }
                else
                {
                    MessageBox.Show("Update maintenance schedule success!");
                }
                refresh();
            }
        }
    }
}
