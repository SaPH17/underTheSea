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

namespace TPA_Desktop.Views.All
{
    /// <summary>
    /// Interaction logic for AddPersonalRequestView.xaml
    /// </summary>
    public partial class AddLeaveRequestView : Window
    {
        public AddLeaveRequestView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTxt.Text;
            string description = descTxt.Text;
            

            if (title == "" || description == "")
            {
                errorLbl.Text = "Please fill all field!";
            }
            else
            {
                PersonalRequestMediator mediator = new PersonalRequestMediator();
                PersonalRequestFactory factory = new PersonalRequestFactory();
                PersonalRequest request;

                request = mediator.addPersonalRequest(factory.createLeaveRequest(title, description));

                if (request != null)
                {
                    MessageBox.Show("Request " + request.title + " has been Added!");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Sending request failed");
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
