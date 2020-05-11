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

namespace TPA_Desktop.Views.ConstructionD
{
    /// <summary>
    /// Interaction logic for ChangeAttractionRideStatusView.xaml
    /// </summary>
    public partial class ChangeAttractionRideStatusView : Window
    {
        public ChangeAttractionRideStatusView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string attractionIDStr = attractionIDTxt.Text.Trim();

            int attractionID;

            bool success = int.TryParse(attractionIDStr, out attractionID);
            if (!success)
            {
                errorLbl.Text = "TaskID must be a number!";
            }
            else if(statusComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string status = (string)((ComboBoxItem)statusComboBox.SelectedValue).Content;

                AttractionRideMediator mediator = new AttractionRideMediator();
                AttractionOrRide aor = mediator.getAttractionOrRide(attractionID);
                aor.status = status;
                aor = mediator.updateAttractionOrRide(attractionID, aor);
                if(aor == null)
                {
                    MessageBox.Show("Update status failed!");
                }
                else
                {
                    MessageBox.Show("Update status successful!");
                }
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
