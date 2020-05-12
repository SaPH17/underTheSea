using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;
using TPA_Desktop.Repository;

namespace TPA_Desktop.Mediator
{
    class OrderMediator
    {
        public dynamic getAllOrder()
        {
            OrderRepository repository = new OrderRepository();
            return repository.getAllOrder();
        }

        public dynamic getAllOrderDetail(int orderID)
        {
            OrderRepository repository = new OrderRepository();
            return repository.getAllOrderDetail(orderID);
        }
        
        public Order updateOrder(int orderID, Order order)
        {
            OrderRepository repository = new OrderRepository();
            return repository.updateOrder(orderID, order);
        }

        public OrderDetail updateOrderDetail(int orderID, OrderDetail orderDetail)
        {
            OrderRepository repository = new OrderRepository();
            return repository.updateOrderDetail(orderID, orderDetail);
        }

        public Order getOrder(int orderID)
        {
            OrderRepository repository = new OrderRepository();
            return repository.getOrder(orderID);
        }

        public Order addOrder(Order order)
        {
            OrderRepository repository = new OrderRepository();
            return repository.addOrder(order);
        }

        public OrderDetail addOrderDetail(OrderDetail orderDetail)
        {
            OrderRepository repository = new OrderRepository();
            return repository.addOrderDetail(orderDetail);
        }

        public OrderDetail getOrder(int orderID, int foodID)
        {
            OrderRepository repository = new OrderRepository();
            return repository.getOrderDetail(orderID, foodID);
        }

        public Order getOrderBySeat(int seatID)
        {
            OrderRepository repository = new OrderRepository();
            return repository.getOrderBySeat(seatID);
        }

        public int getLastID()
        {
            OrderRepository repository = new OrderRepository();
            return repository.getLastID();
        }

        public int getTotalPrice(int orderID)
        {
            OrderRepository repository = new OrderRepository();
            return repository.getTotalPrice(orderID);
        }
    }
}
