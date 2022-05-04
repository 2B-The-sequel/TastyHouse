﻿using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Persistence
{
    public class ProductRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private List<Product> Products;
        private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Content entity from database to "Contents" list.
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
                        double price = sqldatareader.GetDouble("Price");
                        string type = sqldatareader.GetString("Type");
                        byte[] image = null;

                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            image = (byte[])sqldatareader["Image"];
                        }
                        

                        Product product = (id != -1)
                            ? new(id, name, price, type, image)
                            : new(name, price, type, image);
                        Products.Add(product);
                    }
                }
            }
        }




        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public int Add(Product product)
        {
            int result;
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                result = product.Id;
                string Name = product.Name;
                double ExtraPrice = product.Price;
                string Type = product.Type;
                byte[] Image = product.Image;

                string table = "Product";
                string coloumns = "Product_id, Name, Price, Type, Image";
                string values = "@Product_id, @Name, @Price, @Type, @Image";
                string query =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Float).Value = product.Price;
                sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar).Value = product.Type;
                sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = product.Image;

                sqlCommand.ExecuteNonQuery();
            }
            return result;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Product> GetAll()
        {
            return Products;
        }

        public Product GetById(int id)
        {
            Product result = null;
            foreach (Product product in Products)
            {
                if (product.Id.Equals(id))
                {
                    result = product;
                }
            }
            return result;
        }
        // ======================================================
        // Repository CRUD: Update (Updating existing entity in database)
        // ======================================================

        public void Update(Product product)
        {
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                int id = product.Id;
                string Name = product.Name;
                double Price = product.Price;
                string Type = product.Type;
                byte[] Image = product.Image;

                string table = "Content";
                string values = $"@{id}, @{Name}, @{Price}, @{Type}, @{Image}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Name = @'{Name}', Price = @'{Price}', Type = @'{Type}', Image = @'{Image}' " +
                    $"WHERE Product_id = {id}";
            }
        }
        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Remove(int id)
        {
            foreach (Product PT in Products)
            {
                if (PT.Id == id)
                {
                    Products.Remove(PT);
                }
            }
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                string table = "Product";
                string query = $"DELETE FROM {table} WHERE {id} = Product_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
