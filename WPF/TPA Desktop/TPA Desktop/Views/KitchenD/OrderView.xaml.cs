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

namespace TPA_Desktop.Views.KitchenD
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void orderIDTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string orderIDStr = orderIDTxt.Text.Trim();
            int orderID;

            bool success = int.TryParse(orderIDStr, out orderID);
            if (!success && orderIDTxt.Text != "")
            {
                errorLbl.Text = "Order ID is not a number";
            }
            else
            {
                errorLbl.Text = "";
                OrderMediator mediator = new OrderMediator();
                if (mediator.getOrder(orderID) == null)
                {
                    orderDetailView.ItemsSource = null;
                    return;
                }
                orderDetailView.ItemsSource = mediator.getAllOrderDetail(orderID);
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string orderIDStr = orderIDTxt.Text.Trim();
            int orderID;

            bool success = int.TryParse(orderIDStr, out orderID);
            if (!success)
            {
                errorLbl.Text = "Order ID is not a number";
            }
            else if(statusComboBox.SelectedItem == null)
            {
                errorLbl.Text = "Please input all field";
            }
            else
            {
                OrderMediator mediator = new OrderMediator();

                string status = (string)((ComboBoxItem)statusComboBox.SelectedValue).Content;
                Order order = mediator.getOrder(orderID);
                if(order == null)
                {
                    errorLbl.Text = "Order doesn't exist";
                }
                else
                {
                    order.status = status;
                    order = mediator.updateOrder(orderID, order);
                    if(order == null)
                    {
                        MessageBox.Show("Change status failed!");
                    }
                    else
                    {
                        MessageBox.Show("Change Status success");
                    }
                    refresh();
                }
            }
        }

        private void refresh()
        {
            OrderMediator mediator = new OrderMediator();
            orderView.ItemsSource = mediator.getAllOrder();
        }

    }
}
