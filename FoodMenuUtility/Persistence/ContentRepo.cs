﻿using FoodMenuUtility.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodMenuUtility.Persistence
{
    public class ContentRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private List<Content> Contents;
        private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Content entity from database to "Contents" list.
        // ======================================================
        public ContentRepo()
        {
            Contents = new List<Content>();
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Content_id, Name, Extra_Price";
                string table = "Content";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        int id = sqldatareader.GetInt32("Content_id");
                        string name = sqldatareader.GetString("Name");
                        double extraPrice = sqldatareader.GetDouble("Extra_Price");

                        /*
                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            Image = (byte[])sqldatareader["Image"];
                        }
                        */

                        Content cont = (id != -1)
                            ? new(id, name, extraPrice)
                            : new(name, extraPrice);
                        Contents.Add(cont);
                    }
                }
            }
        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public int Add(Content contents)
        {
            int result;
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                result = contents.Id;
                string Name = contents.Name;
                double ExtraPrice = contents.ExtraPrice;
                // Hvis der er brug for et billed til det.
                //byte[] Image = contents.image;

                string table = "Content";
                string coloumns = "Name, Extra_price";
                string values = "@Name, @ExtraPrice";
                string query =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.Add("@ExtraPrice", SqlDbType.Float).Value = ExtraPrice;
                //sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = contents.Image;

                sqlCommand.ExecuteNonQuery();
            }
            return result;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Content> GetAll()
        {
            return Contents;
        }

        public Content GetById(int id)
        {
            Content result = null;
            foreach (Content contents in Contents)
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

        public void Update(Content content)
        {
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                int id = content.Id;
                string Name = content.Name;
                double ExtraPrice = content.ExtraPrice;

                string table = "Content";
                string values = $"@{id}, @{Name}, @{ExtraPrice}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Name = @'{Name}', Extra_Price = @'{ExtraPrice}', " +
                    $"WHERE Content_id = {id}";
            }
        }

        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Remove(int id)
        {
            int i = 0;
            bool found = false;
            while (i < Contents.Count && !found)
            {
                if (Contents[i].Id == id)
                    found = true;
                else
                    i++;
            }
            if (found)
                Contents.Remove(Contents[i]);

            using (SqlConnection connection = new(CnnStr)) // missing inner, delete connection to product
            {
                connection.Open();
                string table = "Content";
                string query = $"DELETE FROM {table} WHERE {id} = Content_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}