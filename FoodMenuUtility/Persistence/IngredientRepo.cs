using FoodMenuUtility.Models;
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

        private readonly List<Ingredient> _ingredients;
        private readonly string _connectionString = Properties.Settings.Default.WPF_Connection;

        // Singleton
        private static IngredientRepo s_instance;
        public static IngredientRepo Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = new IngredientRepo();
                return s_instance;
            }
        }

        // ======================================================
        // Constructor: Adding every Ingredient entity from database to "Ingredients" list.
        // ======================================================
        
        private IngredientRepo() // Constructor er private så man ikke kan lave flere instanser af IngredientRepo.
        {
            _ingredients = new List<Ingredient>();

            using SqlConnection connection = new(_connectionString);

            connection.Open();
            // Hvis billeder skal være der skal de tilføjes til table og values
            string values = "Ingredient_id, Name, Extra_Price, Image, Sold_Out";
            string table = "Ingredient";
            string CommandText = $"SELECT {values} FROM {table}";
            SqlCommand sQLCommand = new(CommandText, connection);
            using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
            while (sqldatareader.Read() != false)
            {
                int id = sqldatareader.GetInt32("Ingredient_id");
                string name = sqldatareader.GetString("Name");
                double extraPrice = sqldatareader.GetDouble("Extra_Price");
                byte[] image = (byte[])sqldatareader["Image"];
                bool soldout = sqldatareader.GetBoolean("Sold_Out");

                Ingredient ingredient = new(id, name, extraPrice, image, soldout);
                _ingredients.Add(ingredient);
            }
        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public Ingredient Create(string name, double price, byte[] image, bool soldOut)
        {
            Ingredient ingredient;
            
            using (SqlConnection connection = new(_connectionString))
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
                _ingredients.Add(ingredient);
            }

            return ingredient;
        }

        // ======================================================
        // Repository CRUD: Retrieve (Reading entity from database)
        // ======================================================

        public List<Ingredient> RetrieveAll()
        {
            return _ingredients;
        }

        public Ingredient Retrieve(int id)
        {
            Ingredient result = null;
            foreach (Ingredient ingredient in _ingredients)
            {
                if (ingredient.Id.Equals(id))
                {
                    result = ingredient;
                }
            }
            return result;
        }

        // ======================================================
        // Repository CRUD: Update (Updating existing entity in database)
        // ======================================================

        public void Update(int id)
        {
            Ingredient ingredient = Retrieve(id);

            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string query = $"UPDATE Ingredient SET Name=@Name, Extra_Price=@Extra_Price, Image=@Image, Sold_Out=@Sold_Out WHERE Ingredient_id=@Ingredient_id";

            SqlCommand sqlCommand = new(query, connection);

            sqlCommand.Parameters.Add(new SqlParameter("Name", ingredient.Name));
            sqlCommand.Parameters.Add(new SqlParameter("Extra_Price", ingredient.ExtraPrice));
            sqlCommand.Parameters.Add(new SqlParameter("Sold_Out", ingredient.SoldOut ? 1 : 0));
            sqlCommand.Parameters.Add(new SqlParameter("Ingredient_id", ingredient.Id));
            sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = ingredient.Image;

            sqlCommand.ExecuteNonQuery();
        }

        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Delete(int id)
        {
            int i = 0;
            bool found = false;
            while (i < _ingredients.Count && !found)
            {
                if (_ingredients[i].Id == id)
                    found = true;
                else
                    i++;
            }
            if (found)
                _ingredients.Remove(_ingredients[i]);

            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                string query = $"DELETE from Product_Ingredient WHERE FK_Ingredient_id=@Ingredient_id; DELETE FROM Ingredient WHERE Ingredient_id=@Ingredient_id;";
                
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.Parameters.Add(new SqlParameter("Ingredient_id", id));

                sqlCommand.ExecuteNonQuery();
            }

            foreach (Product product in ProductRepo.Instance.RetrieveAll())
            {
                product.Ingredients.RemoveAll(x => x.Id == id);
            }
        }
    }
}