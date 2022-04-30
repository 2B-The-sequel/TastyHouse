﻿using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Persistance
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
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Product_id, Name, Price, Type";
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

                        /*
                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            Image = (byte[])sqldatareader["Image"];
                        }
                        */

                        Product product= (id != -1)
                            ? new(id, name, price, type)
                            : new(name, price, type);
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
                // Hvis der er brug for et billed til det.
                //byte[] Image = contents.image;

                string table = "Product";
                string coloumns = "Product_id, Name, Price, Type";
                string values = "@Product_id, @Name, @Price, @Type";
                string query =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = product.Name;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Float).Value = product.Price;
                sqlCommand.Parameters.Add("@Type", SqlDbType.NVarChar).Value = product.Type;
                //sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = contents.Image;

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
            foreach (Product contents in Products)
            {
                if (contents.Id.Equals(id))
                {
                    result = contents;
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

                string table = "Content";
                string values = $"@{id}, @{Name}, @{Price}, @{Type}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Name = @'{Name}', Price = @'{Price}', Type = @'{Type}' " +
                    $"WHERE Product_id = {id}";
            }



        }
        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Remove(int id)
        {
            foreach (Product cs in Products)
            {
                if (cs.Id == id)
                {
                    Products.Remove(cs);
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