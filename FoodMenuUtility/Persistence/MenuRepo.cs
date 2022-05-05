using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
/*
namespace FoodMenuUtility.Persistence
{
    public class MenuRepo
    {
        // ======================================================
        // Fields & Props
        // ======================================================

        private List<Menu> Menus;
        private string CnnStr = Properties.Settings.Default.WPF_Connection;

        // ======================================================
        // Constructor: Adding every Menu entity from database to "Menus" list.
        // ======================================================
        public MenuRepo()
        {
            Menus = new List<Menu>();
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                string values = "Menu_id, Name, Price, Image";
                string table = "Menu";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        int id = sqldatareader.GetInt32("Menu_id");
                        string name = sqldatareader.GetString("Name");
                        double Price = sqldatareader.GetDouble("Price");
                        byte[] Image = null;


                        if (!Convert.IsDBNull(sqldatareader["Image"]))//crash if null
                        {
                            Image = (byte[])sqldatareader["Image"];
                        }
                        

                        Menu list = (id != -1)
                            ? new(id, name, Image, Price)
                            : new(name, Image, Price);
                        Menus.Add(list);
                    }
                }
            }
        }




        // ======================================================
        // Repository CRUD: Create (Adding entity to database)
        // ======================================================

        public int Add(Menu Menus)
        {
            int result;
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                result = Menus.Id;
                string Name = Menus.Name;
                double Price = Menus.Price;
                byte[] Image = Menus.Image;

                string table = "Menu";
                string coloumns = "Name, Price, Image";
                string values = "@Name, @Price, @Image";
                string query =
                    $"INSERT INTO {table} ({coloumns})" +
                    $"VALUES ({values})";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Float).Value = Price;
                sqlCommand.Parameters.Add("@Image", SqlDbType.VarBinary).Value = Menus.Image;

                sqlCommand.ExecuteNonQuery();
            }
            return result;
        }

        // ======================================================
        // Repository CRUD: Read (Reading entity from database)
        // ======================================================

        // Get all from database
        public List<Menu> GetAll()
        {
            return Menus;
        }

        public Menu GetById(int id)
        {
            Menu result = null;
            foreach (Menu Menus in Menus)
            {
                if (Menus.Id.Equals(id))
                {
                    result = Menus;
                }
            }
            return result;
        }
        // ======================================================
        // Repository CRUD: Update (Updating existing entity in database)
        // ======================================================

        public void Update(Menu Menu)
        {
            using (SqlConnection connection = new(CnnStr))
            {
                connection.Open();
                int id = Menu.Id;
                string Name = Menu.Name;
                double Price = Menu.Price;
                byte[] Image = Menu.Image;

                string table = "Menu";
                string values = $"@{id}, @{Name}, @{Price}";
                string query =
                    $"UPDATE {table}" +
                    $"SET Name = @'{Name}', Price = @'{Price}', Image = @'{Image}'" +
                    $"WHERE Menu_id = {id}";
            }
        }
        // ======================================================
        // Repository CRUD: Delete (Delete existing entity from database)
        // ======================================================

        public void Remove(int id)
        {
            foreach (Menu cs in Menus)
            {
                if (cs.Id == id)
                {
                    Menus.Remove(cs);
                }
            }
            using (SqlConnection connection = new(CnnStr)) // missing inner, delete connection to product
            {
                connection.Open();
                string table = "Menu";
                string query = $"DELETE FROM {table} WHERE {id} = Menu_id";
                SqlCommand sqlCommand = new(query, connection);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
*/
