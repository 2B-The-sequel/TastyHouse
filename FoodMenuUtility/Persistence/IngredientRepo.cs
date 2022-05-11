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

        // Singleton
        private static IngredientRepo _instance;
        public static IngredientRepo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IngredientRepo();
                return _instance;
            }
        }

        // ======================================================
        // Constructor: Adding every Ingredient entity from database to "Ingredients" list.
        // ======================================================
        private IngredientRepo() // Constructor er private så man ikke kan lave flere instanser af IngredientRepo.
        {
            Ingredients = new List<Ingredient>();
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Ingredient_id, Name, Extra_Price, Image, Sold_Out";
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
                        byte[] image = image = (byte[])sqldatareader["Image"];
                        bool soldout = sqldatareader.GetBoolean("Sold_Out");

                        Ingredient ingredient = new(id, name, extraPrice, image, soldout);
                        Ingredients.Add(ingredient);
                    }
                }
            }
        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public Ingredient Create(string name, double price, byte[] image, bool soldOut)
        {
            Ingredient ingredient;
            
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();

                string table = "Ingredient";
                string coloumns = "Name, Extra_Price, Image, Sold_Out";
                string values = "@Name, @ExtraPrice, @Image, @Sold_Out";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Name", name));
                sqlCommand.Parameters.Add(new SqlParameter("ExtraPrice", price));
                sqlCommand.Parameters.Add(new SqlParameter("Sold_Out", soldOut ? 1 : 0));
                sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = image;

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                ingredient = new(ID, name, price, image, soldOut);
            }

            return ingredient;
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