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

namespace TPA_Desktop.Views.DiningRoomD
{
    /// <summary>
    /// Interaction logic for CheckoutOrderView.xaml
    /// </summary>
    public partial class CheckoutOrderView : Window
    {
        public CheckoutOrderView()
        {
            InitializeComponent();
        }

        int totalPrice = 0;
        int tax = 0;
        int seatID = 0;

        private void searchOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            string seatIDStr = seatIDTxt.Text.Trim();

            bool success = int.TryParse(seatIDStr, out seatID);
            if (!success)
            {
                errorLbl.Text = "Seat ID is not a number";
            }
            else
            {
                errorLbl.Text = "";
                OrderMediator mediator = new OrderMediator();
                Order customerOrder = mediator.getOrderBySeat(seatID);

                if(customerOrder == null)
                {
                    errorLbl.Text = "Seat is empty!";
                    return;
                }
                var orderDetail = mediator.getAllOrderDetail(customerOrder.orderID);
                orderDetailView.ItemsSource = orderDetail;

                totalPrice = mediator.getTotalPrice(customerOrder.orderID);
                tax = ((totalPrice * 10) / 100);
                totalPriceTxt.Text = "Total Price = \t\tRp. " + totalPrice.ToString();
                taxTxt.Text = "Tax = \t\t\tRp. " + tax.ToString();
                totalPriceAfterTaxTxt.Text = "Total Price After Tax = \tRp. " + (totalPrice + tax).ToString();

            }
        }

        private void checkOutButton_Click(object sender, RoutedEventArgs e)
        {
            string paymentStr = paymentTxt.Text.Trim();
            int payment;

            bool success = int.TryParse(paymentStr, out payment);
            if (!success)
            {
                errorLbl.Text = "Payment must be a number!";
            }
            else if(totalPrice == 0 || tax == 0)
            {
                errorLbl.Text = "Please input Seat ID!";
            }
            else
            {
                int change = (totalPrice + tax) - payment;
                if(change > 0)
                {
                    errorLbl.Text = "Payment is not enough!";
                }
                else if(change <= 0)
                {
                    SeatMediator mediator = new SeatMediator();
                    OrderMediator omediator = new OrderMediator();
                    Order customerOrder = omediator.getOrderBySeat(seatID);
                     
                    changeTxt.Text = "Change = \t\tRp. " + Math.Abs(change).ToString();

                    RestaurantTransactionMediator tmediator = new RestaurantTransactionMediator();
                    RestaurantTransactionFactory tfactory = new RestaurantTransactionFactory();
                    RestaurantTransaction transaction = tmediator.addRestaurantTransaction(tfactory.createNewRestaurantTransaction(seatID));
                    if(tmediator.addDetailRestaurantTransaction(transaction.transactionID, customerOrder.orderID) == null)
                    {
                        MessageBox.Show("Checkout failed!");
                    }
                    else
                    {
                        MessageBox.Show("Checkout success!");
                    }

                    //update seat dan ordernya
                    Seat customerSeat = mediator.getSeat(seatID);
                    customerSeat.status = "Available";
                    customerSeat = mediator.updateSeat(seatID, customerSeat);
                    customerOrder.status = "Finished";
                    customerOrder = omediator.updateOrder(customerOrder.orderID, customerOrder);
                }          
            }
        }
    }
}
