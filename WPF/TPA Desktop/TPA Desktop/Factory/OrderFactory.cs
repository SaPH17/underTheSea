using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Mediator;
using TPA_Desktop.Model;

namespace TPA_Desktop.Factory
{
    class OrderFactory
    {
        public Order createNewOrder(int seatID)
        {
            OrderMediator mediator = new OrderMediator();

            Order order = new Order();
            order.orderID = mediator.getLastID() + 1;
            order.seatID = seatID;
            order.status = "Waiting";

            return order;
        }

        public OrderDetail createNewOrderDetail(int orderID, int foodID, int quantity)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.orderID = orderID;
            orderDetail.foodID = foodID;
            orderDetail.quantity = quantity;

            return orderDetail;
        }
    }
}
