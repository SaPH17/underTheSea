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

namespace TPA_Desktop.Views.HRD
{
    /// <summary>
    /// Interaction logic for PersonalRequestView.xaml
    /// </summary>
    public partial class PersonalRequestView : Window
    {
        public PersonalRequestView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            PersonalRequestMediator mediator = new PersonalRequestMediator();
            personalRequestView.ItemsSource = mediator.getAllPersonalRequest("Leave");
            reasonLbl.Visibility = Visibility.Hidden;
            reasonTxt.Visibility = Visibility.Hidden;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string requestIDStr = requestIDTxt.Text.Trim();
            int requestID;
            string reason = reasonTxt.Text.Trim();

            bool success = int.TryParse(requestIDStr, out requestID);
            if (!success)
            {
                errorLbl.Text = "RequestID must be a number";
            }
            else if(responseComboBox.SelectedItem == null || ((string)((ComboBoxItem)responseComboBox.SelectedValue).Content == "Decline" && reason == ""))
            {
                errorLbl.Text = "Please input all field!";
            }
            else
            {
                string response = (string)((ComboBoxItem)responseComboBox.SelectedValue).Content;

                PersonalRequestMediator mediator = new PersonalRequestMediator();
                PersonalRequest request = mediator.getPersonalRequest(requestID);
                if(request == null)
                {
                    errorLbl.Text = "Request doesn't exist!";
                }
                else
                {
                    if(response == "Accept")
                    {
                        response += "ed";
                    }
                    else
                    {
                        response += "d";
                    }

                    request.status = response;
                    if(response == "Declined")
                    {
                        request.response = reason;
                    }
                    PersonalRequest r = mediator.updatePersonalRequest(requestID, request);
                    if(r == null)
                    {
                        MessageBox.Show("Request response failed");
                    }
                    else
                    {
                        MessageBox.Show("Request response success");
                    }
                    refresh();
                }
            }
        }

        private void responseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (string)((ComboBoxItem)responseComboBox.SelectedValue).Content;
            if(text == "Decline")
            {
                reasonLbl.Visibility = Visibility.Visible;
                reasonTxt.Visibility = Visibility.Visible;
            }
            else
            {
                reasonLbl.Visibility = Visibility.Hidden;
                reasonTxt.Visibility = Visibility.Hidden;
            }
        }
    }
}
