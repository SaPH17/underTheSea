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

namespace TPA_Desktop.Views.HouseKeepingD
{
    /// <summary>
    /// Interaction logic for CleaningScheduleView.xaml
    /// </summary>
    public partial class CleaningScheduleView : Window
    {
        public CleaningScheduleView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            CleaningScheduleMediator mediator = new CleaningScheduleMediator();
            cleaningScheduleView.ItemsSource = mediator.getAllCleaningSchedule();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string scheduleIDStr = scheduleIDTxt.Text.Trim();
            int scheduleID;

            bool success = int.TryParse(scheduleIDStr, out scheduleID);
            if (!success)
            {
                errorLbl.Text = "Schedule ID must be a number!";
            }
            else
            {
                CleaningScheduleMediator mediator = new CleaningScheduleMediator();
                CleaningSchedule schedule = mediator.getCleaningSchedule(scheduleID);
                if(schedule == null)
                {
                    errorLbl.Text = "Schedule ID is invalid!";
                    return;
                }
                schedule.status = "Done";
                schedule = mediator.updateCleaningSchedule(scheduleID, schedule);
                if(schedule == null)
                {
                    MessageBox.Show("Change cleaning schedule status failed!");
                }
                else
                {
                    MessageBox.Show("Change cleaning schedule status success!");
                }
                refresh();
            }
        }
    }
}
