using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodMenuUtility.Persistence
{
    public class OrderRepo
    {
        private List<Order> orders;
        private string connectionString = Properties.Settings.Default.WPF_Connection;

        // Singleton
        private static OrderRepo _instance;
        public static OrderRepo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OrderRepo();
                return _instance;
            }
        }

        private OrderRepo()
        {
            orders = new List<Order>();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Order_id, Date, Estimate_Time";
                string table = "[Order]";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        int id = sqldatareader.GetInt32("Order_id");
                        DateTime date = sqldatareader.GetDateTime("Date");
                        DateTime time = sqldatareader.GetDateTime("Estimate_Time");

                        if (time != DateTime.MinValue)
                        {
                            Order order = new(id, date, time);
                            orders.Add(order);
                        }
                        else
                        {
                            Order order = new(id, date);
                            orders.Add(order);
                        }


                    }
                }
            }
        }
        public Order Create(int id, DateTime Date)
        {
            Order order;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                string table = "Order";
                string coloumns = "Order_id, Date, Estimate_Time";
                string values = "@Order_id, @Date, @Image, @Estimated_Time";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Order_id", id));
                sqlCommand.Parameters.Add(new SqlParameter("Date", Date));

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                order = new(ID, Date);
            }

            return order;
        }

        public void Add(int id)
        {
            Order order =new(id);
            orders.Add(order);

        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order GetById(int id)
        {
            Order result = null;
            foreach (Order order in orders)
            {
                if (order.Id.Equals(id))
                {
                    result = order;
                }
            }
            return result;
        }

        public void Update(int id)
        {
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                
                int ID = GetById(id).Id;
                DateTime date = GetById(id).Date;
                DateTime DoneTime = GetById(id).DoneTime;

                string table = "[Order]";
                string values = $"@{id}, @{date}, @{DoneTime}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Date = @'{date}', Estimate_Time = @'{DoneTime}'" +
                    $"WHERE Order_id = {id}";
            }
        }

        public void Delete(int id)
        {
            int i = 0;
            bool found = false;

            while (i < orders.Count && !found)
            {
                if (orders[i].Id == id)
                    found = true;
                else
                    i++;
            }

            if (found)
                orders.RemoveAt(i);

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string table = "[Order]";
                string query = $"DELETE FROM {table} WHERE {id} = Order_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string table = "Order_Product";
                string query = $"DELETE FROM {table} WHERE {id} = FK_Order_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void AcceptOrder(int id)
        {
            GetById(id).State = OrderState.Accepted;
        }


    }
}