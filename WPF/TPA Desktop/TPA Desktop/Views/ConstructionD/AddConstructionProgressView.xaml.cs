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

namespace TPA_Desktop.Views.ConstructionD
{
    /// <summary>
    /// Interaction logic for AddConstructionProgress.xaml
    /// </summary>
    public partial class AddConstructionProgressView : Window
    {
        public AddConstructionProgressView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string attractionIDStr = attractionIDTxt.Text.Trim();
            string title = titleTxt.Text.Trim();
            string desc = descTxt.Text.Trim();
            DateTime? progressDate = progressDatePicker.SelectedDate;
            int attractionID;

            bool success = int.TryParse(attractionIDStr, out attractionID);
            if (!success)
            {
                errorLbl.Text = "TaskID must be a number!";
            }
            else if(title == "" || desc == "" || !progressDate.HasValue)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                ConstructionProgressMediator mediator = new ConstructionProgressMediator();
                ConstructionProgressFactory factory = new ConstructionProgressFactory();

                ConstructionProgress cp = mediator.addConstructionProgress(factory.createNewConstructionProgress(attractionID,  title, desc, progressDate));
                if(cp == null)
                {
                    MessageBox.Show("Add construction progress failed!");
                }
                else
                {
                    MessageBox.Show("Add construction progress success!");
                }
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
