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
    /// Interaction logic for AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Window
    {
        public AddOrderView()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string seatIDStr = seatIDTxt.Text.Trim();
            string foodIDStr = foodIDTxt.Text.Trim();
            string quantityStr = quantityTxt.Text.Trim();
            int seatID, foodID, quantity;

            bool success = int.TryParse(seatIDStr, out seatID);
            bool success2 = int.TryParse(foodIDStr, out foodID);
            bool success3 = int.TryParse(quantityStr, out quantity);

            if (!success)
            {
                errorLbl.Text = "Seat ID must be a number";
            }
            else if (!success2)
            {
                errorLbl.Text = "Food ID must be a number";
            }
            else if (!success3)
            {
                errorLbl.Text = "Quantity must be a number";
            }
            else
            {
                OrderMediator mediator = new OrderMediator();
                SeatMediator smediator = new SeatMediator();
                FoodMediator fmediator = new FoodMediator();
                OrderFactory factory = new OrderFactory();

                Order order = mediator.getOrderBySeat(seatID);
                Seat seat = smediator.getSeat(seatID);
                Food food = fmediator.getFood(foodID);

                if (seat == null)
                {
                    errorLbl.Text = "Seat doesn't exist";
                    return;
                }

                if(food == null)
                {
                    errorLbl.Text = "Food doesn't exist";
                    return;
                }

                if (order == null)
                { 
                    mediator.addOrder(factory.createNewOrder(seatID));

                    seat.status = "Unavailable";
                    seat = smediator.updateSeat(seatID, seat);
                }

                order = mediator.getOrderBySeat(seatID);
                OrderDetail existingOrder = mediator.getOrderDetail(order.orderID, foodID);
                OrderDetail orderDetail;
                if (existingOrder == null)
                {
                    orderDetail = mediator.addOrderDetail(factory.createNewOrderDetail(order.orderID, foodID, quantity));
                }
                else
                {
                    existingOrder.quantity += quantity;
                    orderDetail = mediator.updateOrderDetail(order.orderID, existingOrder);
                }
                if (orderDetail == null)
                {
                    MessageBox.Show("Input order failed!");
                }
                else
                {
                    MessageBox.Show("Input order success!");
                }
            }
        }
    }
}
