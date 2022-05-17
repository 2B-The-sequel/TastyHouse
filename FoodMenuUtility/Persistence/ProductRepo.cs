using FoodMenuUtility.Models;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System;

namespace FoodMenuUtility.Persistence
{
    public class ProductRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private readonly List<Product> Products;
        private readonly string connectionString = Properties.Settings.Default.WPF_Connection;

        // Singleton
        private static ProductRepo s_instance;
        public static ProductRepo Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = new ProductRepo();
                return s_instance;
            }
        }

        // ======================================================
        // Constructor: Adding every Content entity from database to "Contents" list.
        // ======================================================

        public ProductRepo()
        {
            Products = RetrieveAll();
        }

        public void Update(int id)
        {
            Product product = GetById(id);

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                string query = $"UPDATE Product SET Name=@Name, Price=@Price, Image=@Image WHERE Product_id=@Product_id";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("Product_id", product.Id));
                sqlCommand.Parameters.Add(new SqlParameter("Name", product.Name));
                sqlCommand.Parameters.Add(new SqlParameter("Price", product.Price));
                sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = product.Image;

                sqlCommand.ExecuteNonQuery();
            }

        }

        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public Product Create(string name, double price, ProductType type , byte[] image, List<int> ingredients)
        {
            Product product;
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string Name = name;
                double ExtraPrice = price;

                ProductType Type = type +1;
                byte[] Image = image;

                string table = "Product";
                string coloumns = "Product.Name, Product.Price, Product.FK_PT_id, Product.Image";
                string values = "@Name, @Price, @Type, @Image";

                if (Image == null)
                {
                    coloumns = "Product.Name, Product.Price, Product.FK_PT_id";
                    values = "@Name, @Price, @Type";
                }
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("@Name", Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", ExtraPrice));
                sqlCommand.Parameters.Add(new SqlParameter("@Type", Type));
                if (Image != null)
                {
                    sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = Image;
                }

                int ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
                product = new(ID, name, price, type, image);
            }

            for (int i = 0; i < ingredients.Count; i++)
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();

                string table = "Product_Ingredient";
                string coloumns = "FK_Ingredient_id, FK_Product_id";
                string values = "@ing_id, @pro_id";

                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values});";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("@pro_id", product.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@ing_id", ingredients[i]));//Kunne måske lave en foreach her så den ikke bruger ligeså lang tid

                sqlCommand.ExecuteNonQuery();

                product.Ingredients.Add(IngredientRepo.Instance.Retrieve(ingredients[i]));
            }

            return product;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Product> RetrieveAll()
        {
            List<Product> products = new();
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                byte[] image = null;
                // Hvis billeder skal være der skal de tilføjes til table og values
                string values = "Product_id, Name, Price, FK_PT_id, Image";

                string table = "Product";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
                while (sqldatareader.Read() != false)
                {
                    int id = sqldatareader.GetInt32("Product_id");
                    string name = sqldatareader.GetString("Name");
                    double price = sqldatareader.GetDouble("Price");
                    int type = sqldatareader.GetInt32("FK_PT_id");
                    if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                    {
                        image = (byte[])sqldatareader["Image"];
                    }

                    type--;
                    Product product = new(id, name, price, (ProductType)type, image);

                    products.Add(product);
                }
            }

            List<int> FK_Ingredients = new();
            List<int> FK_Products = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();

                string table = "Product_Ingredient";
                string values = "FK_Ingredient_id, FK_Product_id";
                string CommandText = $"SELECT {values} FROM {table}";

                SqlCommand sQLCommand = new(CommandText, connection);
                using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
                while (sqldatareader.Read() != false)
                {
                    FK_Ingredients.Add(sqldatareader.GetInt32("FK_Ingredient_id"));
                    FK_Products.Add(sqldatareader.GetInt32("FK_Product_id"));
                }

                for (int i = 0; i < FK_Products.Count; i++)
                {
                    foreach (Product product in products)
                    {
                        if (product.Id == FK_Products[i])
                            product.Ingredients.Add(IngredientRepo.Instance.Retrieve(FK_Ingredients[i]));
                    }
                }
            }

            return products;
        }

        public Product Retrieve(int id)
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
            using SqlConnection connection = new(connectionString);
            connection.Open();
            int id = product.Id;
            string Name = product.Name;
            double Price = product.Price;

            ProductType Type = product.ProductType;
            byte[] Image = product.Image;


            string table = "Content";
            string values = $"@{id}, @{Name}, @{Price}, @{Type}, @{Image}";
            string query =
                $"UPDATE {table}" +
                $"SET Name = @'{Name}', Price = @'{Price}', FK_TP_id = @'{(int)Type}', Image = @'{Image}' " +
                $"WHERE Product_id = {id}";
        }

        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Delete(int id)
        {
            int i = 0;
            bool found = false;

            while(i < Products.Count && !found)
            {
                if (Products[i].Id == id)
                    found = true;
                else
                    i++;
            }

            if (found)
                Products.RemoveAt(i);

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string table = "Product";
                string query = $"DELETE FROM {table} WHERE {id} = Product_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string table = "Product_Ingredient";
                string query = $"DELETE FROM {table} WHERE {id} = FK_Product_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
