using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodMenuUtility.Persistence
{
    public class IngredientRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private List<Ingredient> Ingredients;
        private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Ingredient entity from database to "Ingredients" list.
        // ======================================================
        public IngredientRepo()
        {
            Ingredients = new List<Ingredient>();
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Ingredient_id, Name, Extra_Price, Image";
                string table = "Ingredient";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        int id = sqldatareader.GetInt32("Ingredient_id");
                        string name = sqldatareader.GetString("Name");
                        double extraPrice = sqldatareader.GetDouble("Extra_Price");
                        byte[] image = null;

                        
                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            image = (byte[])sqldatareader["Image"];
                        }
                        

                        Ingredient cont = (id != -1)
                            ? new(id, name, extraPrice, image)
                            : new(name, extraPrice, image);
                        Ingredients.Add(cont);
                    }
                }
            }
        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public Ingredient Create(string name, double price, byte[] image)
        {
            Ingredient Ingredient = new(name, price, image);

            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                string Name = Ingredient.Name;
                double ExtraPrice = Ingredient.ExtraPrice;
                byte[] Image = Ingredient.Image;

                string table = "Ingredient";
                string coloumns = "Name, Extra_Price, Image";
                string values = "@Name, @ExtraPrice, @Image";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Name", Name));
                sqlCommand.Parameters.Add(new SqlParameter("ExtraPrice", ExtraPrice));
                sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = Ingredient.Image;

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                Ingredient.Id = ID;
            }

            return Ingredient;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Ingredient> GetAll()
        {
            return Ingredients;
        }

        public Ingredient GetById(int id)
        {
            Ingredient result = null;
            foreach (Ingredient Ingredients in Ingredients)
            {
                if (Ingredients.Id.Equals(id))
                {
                    result = Ingredients;
                }
            }
            return result;
        }
        // ======================================================
        // Repository CRUD: Update (Updating existing entity in database)
        // ======================================================

        public void Update(Ingredient Ingredient)
        {
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                int id = Ingredient.Id;
                string Name = Ingredient.Name;
                double ExtraPrice = Ingredient.ExtraPrice;
                byte[] Image = Ingredient.Image;

                string table = "Ingredient";
                string values = $"@{id}, @{Name}, @{ExtraPrice}, @{Image}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Name = @'{Name}', Extra_Price = @'{ExtraPrice}', Image = @'{Image}'" +
                    $"WHERE Ingredient_id = {id}";
            }
        }

        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Remove(int id)
        {
            int i = 0;
            bool found = false;
            while (i < Ingredients.Count && !found)
            {
                if (Ingredients[i].Id == id)
                    found = true;
                else
                    i++;
            }
            if (found)
                Ingredients.Remove(Ingredients[i]);

            using (SqlConnection connection = new(CnnStr)) // missing inner, delete connection to product
            {
                connection.Open();
                string table = "Ingredient";
                string query = $"DELETE from Product_Ingredient WHERE FK_Ingredient_id = {id}; Delete from {table} where Ingredient_id = {id};";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}