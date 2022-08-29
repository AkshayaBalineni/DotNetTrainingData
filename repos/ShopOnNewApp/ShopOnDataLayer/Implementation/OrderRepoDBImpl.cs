using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Implementation
{
    public class OrderRepoDBImpl : IOrderRepo
    {
        private readonly string connectionString = null;
        public OrderRepoDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            connectionString = connectionUtil.GetConnectionString();
        }
        public Order AddOrder(Order order)
        {
            string sqlst = "sp_InsertOrder";
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst, connection, transaction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter orderDate = command.Parameters.Add("@orderDate", System.Data.SqlDbType.Date);
                        orderDate.Value = order.OrderDate;
                        orderDate.Direction = System.Data.ParameterDirection.Input;

                        SqlParameter customerId = command.Parameters.Add("@customerId", System.Data.SqlDbType.Int);
                        customerId.Value = order.CustomerId == 0 ? null : order.CustomerId;
                        customerId.Direction = System.Data.ParameterDirection.Input;

                        SqlParameter totalAmount = command.Parameters.Add("@totalAmount", System.Data.SqlDbType.Float);
                        totalAmount.Value = order.TotalAmount;
                        totalAmount.Direction = System.Data.ParameterDirection.Input;

                        SqlParameter orderId = command.Parameters.Add("@orderId", System.Data.SqlDbType.Int);
                        orderId.Value = order.OrderId;
                        orderId.Direction = System.Data.ParameterDirection.Output;

                        SqlParameter aspCustomerID = command.Parameters.Add("@aspCustomerID", System.Data.SqlDbType.NVarChar, 450);
                        aspCustomerID.Value = order.AspCustomerId;
                        aspCustomerID.Direction = System.Data.ParameterDirection.Input;

                        var rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            var newOrderId = Convert.ToInt32(command.Parameters["@orderId"].Value);
                            order.OrderId = newOrderId;
                            var isInsterted = InsertOrdrItem(connection, transaction, newOrderId, order.GetOrderItems());
                            order.TotalAmount = order.GetOrderTotal();
                            if (isInsterted)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }

                        }

                    }
                }
            }

            catch (Exception e)
            {
                transaction.Rollback();
            }
            return order;
        }
        private bool InsertOrdrItem(SqlConnection connection, SqlTransaction transaction, int newOrderId, IEnumerable<OrderItem> orderItems)
        {
            bool isInserted = false;
            string sqlst = "sp_orderItem";
            try
            {
                foreach (var item in orderItems)
                {
                    isInserted = false;
                    using (SqlCommand command = new SqlCommand(sqlst, connection, transaction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter orderId = command.Parameters.Add("@orderId", System.Data.SqlDbType.Int);
                        orderId.Value = newOrderId;
                        orderId.Direction = System.Data.ParameterDirection.Input;

                        SqlParameter qty = command.Parameters.Add("@Qty", System.Data.SqlDbType.Int);
                        qty.Value = item.ProductQty;
                        qty.Direction = System.Data.ParameterDirection.Input;

                        SqlParameter pId = command.Parameters.Add("@pId", System.Data.SqlDbType.Int);
                        pId.Value = item.Product.PId;
                        pId.Direction = System.Data.ParameterDirection.Input;

                        var rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            isInserted = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return isInserted;
        }
        public IEnumerable<Order> GetCustomerOrder(int customerId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sqlSt = $"select  o.orderid, " +
                    $"o.orderstatus, " +
                    $"o.customerid, " +
                    $"o.totalAmount, " +
                    $"o.orderdate " +
                    $"from orderd as o where o.customerid=@customerId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlSt, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Order newOrder = new Order();

                            newOrder.OrderId = Convert.ToInt32(reader["orderid"]);
                            newOrder.OrderStatus = reader["orderstatus"].ToString();
                            newOrder.OrderDate = Convert.ToDateTime(reader["orderdate"]);
                            newOrder.TotalAmount = newOrder.GetOrderTotal();
                            orders.Add(newOrder);
                        }      
                    }
                }
            }
            catch (Exception)
            {

            }
            return orders;
        }

        public Order GetOrder(int orderId)
        {
            Order order = new Order();
            try
            {
                string sqlSt = $"select  o.orderid, " +
                    $"o.orderstatus, " +
                    $"o.customerid, " +
                    $"o.totalAmount, " +
                    $"o.orderdate " +
                    $"from orderd as o where o.orderid=@OrderId";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    using(SqlCommand command = new SqlCommand(sqlSt,connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", order.OrderId);
                        SqlDataReader reader = command.ExecuteReader();
                        order.OrderDate = Convert.ToDateTime(reader["orderdate"]);
                        order.OrderId = Convert.ToInt32(reader["orderid"]);
                        order.CustomerId = Convert.ToInt32(reader["customerid"]);
                        order.OrderStatus = reader["orderstatus"].ToString();
                        order.TotalAmount = order.GetOrderTotal();
                    }
                }
            }
            catch(Exception)
            {

            }
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sqlst = $"Select o.orderid, " +
                    $"o.orderstatus, " +
                    $"o.customerid, " +
                    $"o.totalAmount, " +
                    $"o.orderdate " +
                    $"from orderd as o WITH(NOLOCK);";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlst, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = Convert.ToInt32(reader["orderid"]);
                            order.OrderDate = Convert.ToDateTime(reader["orderdate"]);
                            order.CustomerId = Convert.ToInt32(reader["customerid"]);
                            order.OrderStatus = reader["orderstatus"].ToString();
                            order.TotalAmount = order.GetOrderTotal();

                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return orders;
        }

    }
}
