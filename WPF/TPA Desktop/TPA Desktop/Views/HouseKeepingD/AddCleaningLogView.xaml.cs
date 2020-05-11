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

namespace TPA_Desktop.Views.HouseKeepingD
{
    /// <summary>
    /// Interaction logic for AddCleaningLogView.xaml
    /// </summary>
    public partial class AddCleaningLogView : Window
    {
        public AddCleaningLogView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string roomIDStr = roomIDTxt.Text.Trim();
            string desc = descTxt.Text;
            DateTime? cleaningDate = cleaningDatePicker.SelectedDate;
            int roomID;
            
            if(roomIDStr == "" || desc == "" || !cleaningDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                bool success = int.TryParse(roomIDStr, out roomID);
                if (!success)
                {
                    errorLbl.Text = "RoomID must be a number!";
                }
                else
                {
                    CleaningLogFactory factory = new CleaningLogFactory();
                    CleaningLogMediator mediator = new CleaningLogMediator();

                    CleaningLog cleaningLog = mediator.addCleaningLog(factory.createNewCleaningLog(roomID, desc, cleaningDate));
                    if(cleaningLog == null)
                    {
                        MessageBox.Show("Add cleaning log failed!");
                    }
                    else
                    {
                        MessageBox.Show("Add cleaning log success!");
                    }
                }
            }
        }
    }
}
