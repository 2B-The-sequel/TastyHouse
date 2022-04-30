using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodMenuUtility.Persistence
{
    public class  ProductRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private List<Product> Products;
        private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Product entity from database to "Products" list.
        // ======================================================
        public ProductRepo()
        {
            Products = new List<Product>();
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                string values = "Product_id, Name, Price, Type, Image";
                string table = "Product";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        int id = sqldatareader.GetInt32("Product_id");
                        string name = sqldatareader.GetString("Name");
                        double Price = sqldatareader.GetDouble("Price");
                        string Type = sqldatareader.GetString("Type");
                        byte[] Image = null;


                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            Image = (byte[])sqldatareader["Image"];
                        }


                        Product list = (id != -1)
                            ? new(id, name, Price, Type, Image)
                            : new(name, Price, Type, Image);
                        Products.Add(list);
                    }
                }
            }
        }
        public void AddNewProduct()
        {
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                string values = "Name, Price, Type, Image";
                string table = "Product";
                string CommandText = $"INSERT INTO {table} ({values}) VALUES (@Name, @Price, @Type, @Image)";
                SqlCommand sQLCommand = new(CommandText, connection);
                sQLCommand.Parameters.AddWithValue("@Name", Products[Products.Count - 1].Name);
                sQLCommand.Parameters.AddWithValue("@Price", Products[Products.Count - 1].Price);
                sQLCommand.Parameters.AddWithValue("@Type", Products[Products.Count - 1].Type);
                sQLCommand.Parameters.AddWithValue("@Image", Products[Products.Count - 1].Image);
                sQLCommand.ExecuteNonQuery();
            }
        }
        
    }
}
