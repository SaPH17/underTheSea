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
    /// Interaction logic for AddResignRequestView.xaml
    /// </summary>
    public partial class AddResignRequestView : Window
    {
        public AddResignRequestView()
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

                request = mediator.addPersonalRequest(factory.createResignRequest(title, description));

                if (request != null)
                {
                    MessageBox.Show("Request " + request.title + " has been Added!");
                }
                else
                {
                    MessageBox.Show("Sending request failed");
                }
                this.Close();
            }
        }
    }
}
