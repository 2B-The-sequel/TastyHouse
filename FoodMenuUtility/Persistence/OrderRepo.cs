using FoodMenuUtility.Models;
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
            string values = "Order_id, Date, Estimate_Time,FK_State_id,FK_PM_id,FK_DM_id";
            string table = "[Order]";
            string CommandText = $"SELECT {values} FROM {table}";
            SqlCommand sQLCommand = new(CommandText, connection);
            using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
            while (sqldatareader.Read() != false)
            {
                int id = sqldatareader.GetInt32("Order_id");
                DateTime date = sqldatareader.GetDateTime("Date");
                DateTime doneTime = sqldatareader.GetDateTime("Estimate_Time");
                int state = sqldatareader.GetInt32("FK_State_id");
                int payMethod = sqldatareader.GetInt32("FK_PM_id");
                int delMethod = sqldatareader.GetInt32("FK_DM_id");
                
                Order order = new(id, date, doneTime,state,payMethod,delMethod);
                _orders.Add(order);
            }
            AddProductstoOrderFromSQL();
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
                                AddProducts(order.Id, FK_Products[i]);
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

        public Order Create(DateTime dateOrdered,DateTime timeDone, List<int> Product_IDs, DeliveryMethod delMethod, PaymentMethod payMethod)
        {
            Order order;

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                int i = 1;
                int d = 3;

                string table = "[Order]";
                string coloumns = "FK_Promo_id,FK_Customer_id,FK_State_id,FK_DM_id,FK_PM_id,Date,Estimate_Time";
                string values = "@FK_Promo_id,@FK_Customer_id,@FK_State_id,@FK_DM_id,@FK_PM_id,@Date,@Estimate_Time";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("@Date", dateOrdered));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_Promo_id", i));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_Customer_id", i));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_State_id", d));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_DM_id", (int)delMethod));
                sqlCommand.Parameters.Add(new SqlParameter("@FK_PM_id", (int)payMethod));
                sqlCommand.Parameters.Add(new SqlParameter("@Estimate_Time", timeDone));

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                order = new(dateOrdered, timeDone,3, (int)payMethod, (int)delMethod);
                _orders.Add(order);

                foreach (int product in Product_IDs)
                {
                    AddAssociationOrderProduct(ID, product);
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
                Order order = Retrieve(id);

                string query = $"UPDATE [Order] SET Date=@Date, Estimate_Time=@DoneTime, FK_State_id = @State WHERE Order_id=@OrderID";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Date", order.Date));
                sqlCommand.Parameters.Add(new SqlParameter("DoneTime", order.DoneTime));
                sqlCommand.Parameters.Add(new SqlParameter("State", order.State));
                sqlCommand.Parameters.Add(new SqlParameter("OrderID", ID));

                sqlCommand.ExecuteNonQuery();


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