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
    /// Interaction logic for AddPurchaseRequestView.xaml
    /// </summary>
    public partial class AddPurchaseRequestView : Window
    {
        public AddPurchaseRequestView()
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
                RequestMediator mediator = new RequestMediator();
                RequestFactory factory = new RequestFactory();
                Request request = mediator.addRequest(factory.createPurchaseRequest(title, description));
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
