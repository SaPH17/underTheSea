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

namespace TPA_Desktop.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string customerIDStr = customerIDTxt.Text.Trim();
            string title = titleTxt.Text.Trim();
            string desc = descTxt.Text.Trim();
            int customerID;

            bool success = int.TryParse(customerIDStr, out customerID);
            if (!success)
            {
                errorLbl.Text = "Customer ID must be a number!";
            }
            else if(deptComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string department = (string)((ComboBoxItem)deptComboBox.SelectedValue).Content;
                FeedbackMediator mediator = new FeedbackMediator();
                FeedbackFactory factory = new FeedbackFactory();

                Feedback feedback = mediator.addFeedback(factory.createNewFeedback(customerID, department, title, desc));
                if(feedback == null)
                {
                    MessageBox.Show("Add feedback failed!");
                }
                else
                {
                    MessageBox.Show("Add feedback success!");
                }
            }

        }

        private void deptComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (string)((ComboBoxItem)deptComboBox.SelectedValue).Content;
            if(text == "Hotel")
            {
                customerIDTxt.Text = "";
                customerIDTxt.IsEnabled = true;
            }
            else
            {
                customerIDTxt.Text = "0";
                customerIDTxt.IsEnabled = false;
            }
        }
    }
}
