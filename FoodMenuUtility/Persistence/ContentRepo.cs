using FoodMenuUtility.Models;
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

        private readonly List<Content> contents;
        private readonly string connectionString = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Content entity from database to "Contents" list.
        // ======================================================
        
        public ContentRepo()
        {
            contents = GetAll();
        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public Content Create(string name, double price)
        {
            Content content = new(name, price);

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string Name = content.Name;
                double ExtraPrice = content.ExtraPrice;
                // Hvis der er brug for et billed til det.
                //byte[] Image = contents.image;

                string table = "Content";
                string coloumns = "Name, Extra_Price";
                string values = "@Name, @ExtraPrice";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Name", Name));
                sqlCommand.Parameters.Add(new SqlParameter("ExtraPrice", ExtraPrice));
                //sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = contents.Image;

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                content.Id = ID;
            }

            return content;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Content> GetAll()
        {
            List<Content> contents = new();
            using (SqlConnection connection = new(connectionString))
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
                        contents.Add(cont);
                    }
                }
            }
            return contents;
        }

        public Content GetById(int id)
        {
            Content result = null;
            foreach (Content contents in contents)
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
            using (SqlConnection connection = new(connectionString))
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

        public void Delete(int id)
        {
            int i = 0;
            bool found = false;
            while (i < contents.Count && !found)
            {
                if (contents[i].Id == id)
                    found = true;
                else
                    i++;
            }
            if (found)
                contents.Remove(contents[i]);

            using (SqlConnection connection = new(connectionString)) // missing inner, delete connection to product
            {
                connection.Open();
                string table = "Content";
                string query = $"DELETE from Product_Content WHERE FK_Content_id = {id}; Delete from {table} where Content_id = {id};";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}