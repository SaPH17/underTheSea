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

namespace TPA_Desktop.Views.FrontOfficeD
{
    /// <summary>
    /// Interaction logic for AddCleaningScheduleView.xaml
    /// </summary>
    public partial class AddCleaningScheduleView : Window
    {
        public AddCleaningScheduleView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string roomIDStr = roomIDTxt.Text.Trim();
            DateTime? cleaningDate = cleaningDatePicker.SelectedDate;
            int roomID;

            bool success = int.TryParse(roomIDStr, out roomID);
            if (!success)
            {
                errorLbl.Text = "Room ID must be a number!";
            }
            else if (!cleaningDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                CleaningScheduleMediator mediator = new CleaningScheduleMediator();
                CleaningScheduleFactory factory = new CleaningScheduleFactory();

                CleaningSchedule cleaningSchedule = mediator.addCleaningSchedule(factory.createNewCleaningSchedule(roomID, cleaningDate));
                if(cleaningSchedule == null)
                {
                    MessageBox.Show("Add cleaning schedule failed!");
                }
                else
                {
                    MessageBox.Show("Add cleaning schedule success!");
                }
                this.Close();
            }
        }
    }
}
