using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.Model;

namespace TPA_Desktop.Repository
{
    class OrderRepository
    {
        public dynamic getAllOrder()
        {
            Connection con = Connection.getConnection();

            var result = (from o in con.db.Order
                          where o.status != "Finished"
                          select new
                          {
                              o.orderID,
                              o.seatID,
                              o.status
                          });
            return result.ToList();
        }

        public dynamic getAllOrderDetail(int orderID)
        {
            Connection con = Connection.getConnection();

            var result = (from o in con.db.OrderDetail
                          join f in con.db.Food on o.foodID equals f.foodID
                          where o.orderID == orderID
                          select new
                          {
                              o.orderID,
                              f.name,
                              o.quantity,
                              f.price
                          });
            return result.ToList();
        }

        public Order updateOrder(int orderID, Order order)
        {
            Connection con = Connection.getConnection();

            Order newOrder = con.db.Order.Find(orderID);
            newOrder = order;
            con.db.SaveChanges();
            return newOrder;
        }

        public OrderDetail updateOrderDetail(int orderID, OrderDetail orderDetail)
        {
            Connection con = Connection.getConnection();

            OrderDetail newOrderDetail = (from od in con.db.OrderDetail
                                          join o in con.db.Order on od.orderID equals o.orderID
                                          where o.status != "Finished" && od.foodID == orderDetail.foodID && od.orderID == orderID
                                          select od).FirstOrDefault();
            newOrderDetail = orderDetail;
            con.db.SaveChanges();

            return newOrderDetail;

        }

        public Order getOrder(int orderID)
        {
            Connection con = Connection.getConnection();

            Order order = con.db.Order.Find(orderID);
            if(order == null || order.status == "Finished")
            {
                return null;
            }
            return order;
        }

        public Order addOrder(Order order)
        {
            Connection con = Connection.getConnection();

            con.db.Order.Add(order);
            con.db.SaveChanges();

            return order;
        }

        public OrderDetail addOrderDetail(OrderDetail orderDetail)
        {
            Connection con = Connection.getConnection();

            con.db.OrderDetail.Add(orderDetail);
            con.db.SaveChanges();

            return orderDetail;
        }

        public OrderDetail getOrderDetail(int orderID, int foodID)
        {
            Connection con = Connection.getConnection();
            return (from od in con.db.OrderDetail
                    join o in con.db.Order on od.orderID equals o.orderID
                    where o.status != "Finished" && od.foodID == foodID && od.orderID == orderID select od).FirstOrDefault();
             
        }

        public Order getOrderBySeat(int seatID)
        {
            Connection con = Connection.getConnection();
            Order order = (from o in con.db.Order where o.status != "Finished" && o.seatID == seatID select o).FirstOrDefault();

            return order;
        }

        public int getLastID()
        {
            Connection con = Connection.getConnection();

            Order order = (from o in con.db.Order orderby o.orderID descending select o).FirstOrDefault();
            if(order == null)
            {
                return 0;
            }
            return order.orderID;
        }

        public int getTotalPrice(int orderID)
        {
            Connection con = Connection.getConnection();

            int totalPrice = 0;

            List<OrderDetail> orderDetails = (from o in con.db.OrderDetail where o.orderID == orderID select o).ToList();

            foreach(OrderDetail o in orderDetails)
            {
                int temp = (int)con.db.Food.Find(o.foodID).price;
                totalPrice += (int)(temp * o.quantity);        
            }

            return totalPrice;
        }

    }
}
