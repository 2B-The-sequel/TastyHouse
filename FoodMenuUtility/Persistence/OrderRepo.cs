﻿using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodMenuUtility.Persistence
{
    public class OrderRepo
    {
        private readonly List<Order> _orders;
        private readonly string _connectionString = Properties.Settings.Default.WPF_Connection;

        // Singleton
        private static OrderRepo s_instance;
        public static OrderRepo Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = new OrderRepo();
                return s_instance;
            }
        }

        private OrderRepo()
        {
            _orders = new List<Order>();

            using SqlConnection connection = new(_connectionString);

            connection.Open();
            // Hvis billeder skal være der skal de tilføjes til table og values
            string values = "Order_id, Date, Estimate_Time";
            string table = "[Order]";
            string CommandText = $"SELECT {values} FROM {table}";
            SqlCommand sQLCommand = new(CommandText, connection);
            using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
            while (sqldatareader.Read() != false)
            {
                int id = sqldatareader.GetInt32("Order_id");
                DateTime date = sqldatareader.GetDateTime("Date");
                //DateTime time = sqldatareader.GetDateTime("Estimate_Time")
                DateTime time = DateTime.MinValue;

                Order order = new(id, date, time);
                _orders.Add(order);
            }
        }

        public int SetId()
        {
            int i=0;
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();

                string table = "[Order]";
                string values = "COUNT(Order_Id) AS IdCount";
                string CommandText = $"SELECT {values} FROM {table} ";

                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        i = sqldatareader.GetInt32("IdCount");
                    }
                }
            }
            return i+1;
        }

        public void AddProductstoOrderFromSQL()
        {
            List<int> FK_Order = new();
            List<int> FK_Products = new();

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();

                string table = "Order_Product";
                string values = "FK_Order_id, FK_Product_id";
                string CommandText = $"SELECT {values} FROM {table}";

                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        FK_Order.Add(sqldatareader.GetInt32("FK_Order_id"));
                        FK_Products.Add(sqldatareader.GetInt32("FK_Product_id"));
                    }

                    for (int i = 0; i < FK_Order.Count; i++)
                    {
                        foreach (Order order in _orders)
                        {
                            if (order.Id == FK_Order[i])
                                AddProducts(FK_Products[i], order.Id);
                        }
                    }
                }
            }
        }

        public void AddAssociationOrderProduct(int Order_id, int pro_id)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                int Ord_id = Order_id;
                int Product_id = pro_id;
                
                string table = "Order_Product";
                string coloumns = "FK_Order_id, FK_Product_id";
                string values = "@Ord_id, @pro_id";

                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values});";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("@Ord_id", Ord_id));
                sqlCommand.Parameters.Add(new SqlParameter("@pro_id", Product_id));
                
                //Kunne måske lave en foreach her så den ikke bruger ligeså lang tid

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void AddProducts(int ord_id,int pro_id)
        {
            Retrieve(ord_id).Products.Add(ProductRepo.Instance.Retrieve(pro_id));
        }

        public Order Create(DateTime Date,List<int> Product_IDs)
        {
            Order order;

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                int i = 1;
                int d = 3;

                string table = "[Order]";
                string coloumns = "FK_Promo_id,FK_Customer_id,FK_State_id,FK_DM_id,FK_PM_id,Date";
                string values = "@FK_Promo_id,@FK_Customer_id,@FK_State_id,@FK_DM_id,@FK_PM_id,@Date";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("@Date", Date));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_Promo_id", i));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_Customer_id", i));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_State_id", 3));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_DM_id", i));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_PM_id", i));

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                order = new(ID, Date);
                _orders.Add(order);


                foreach (Product product in Cart)
                {
                    if  (product.Id == ID)
                    { AddAssociationOrderProduct(ID, product.Id); }
                }
                
            }

            return order;
        }

        public List<Order> RetrieveAll()
        {
            return _orders;
        }

        public Order Retrieve(int id)
        {
            Order result = null;
            foreach (Order order in _orders)
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
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                
                int ID = Retrieve(id).Id;
                DateTime date = Retrieve(id).Date;
                DateTime DoneTime = Retrieve(id).DoneTime;

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

            while (i < _orders.Count && !found)
            {
                if (_orders[i].Id == id)
                    found = true;
                else
                    i++;
            }

            if (found)
                _orders.RemoveAt(i);

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                string table = "[Order]";
                string query = $"DELETE FROM {table} WHERE {id} = Order_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                string table = "Order_Product";
                string query = $"DELETE FROM {table} WHERE {id} = FK_Order_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}