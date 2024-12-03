using ExpenseManagementApp.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ExpenseManagementApp.Models;
using System.Configuration;
using System.Web.UI.WebControls;
using Orders = ExpenseManagementApp.Models.Orders;

namespace ExpenseManagementApp.DataBase
{
    public class DataAccess
    {
        private string _connectionString;


        public DataAccess(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<Category> GetCategories()
        {
            List<Category> categoriesList = new List<Category>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Category";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categoriesList.Add(new Category
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"].ToString(),
                            Description = reader["Description"].ToString()
                        });

                    }
                    return categoriesList;
                }
            }
        }
        public Category GetCategory(int CategoryID)
        {
            // List<Category> categoriesList = new List<Category>();
            Category categories = new Category();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Category where CategoryID=@CategoryID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categories = new Category
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"].ToString(),
                            Description = reader["Description"].ToString()
                        };

                    }
                    return categories;
                }
            }
        }
        public bool DeleteCategory(int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Category WHERE CategoryID=@CategoryID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        return true;
                    }
                    else return false;


                }
            }
        }
        public bool UpdateCategory(string CategoryName, string description, int CategoryID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE  Category SET CategoryName=@CategoryName , Description=@Description WHERE CategoryID=@CategoryID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        return true;
                    }
                    else return false;


                }
            }
        }
        public Items GetItems(int itemID)
        {
            Items items = new Items();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Items WHERE ItemID = @ItemID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemID", itemID);
                    con.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {


                        items.ItemId = sqlDataReader.GetInt32(0);
                        items.ItemName = sqlDataReader.GetString(1);
                        items.Price = sqlDataReader["Price"] != null ? Convert.ToDecimal(sqlDataReader["Price"]) : 0;
                        //items.Quantity = sqlDataReader.GetInt32(3);
                        items.Stock = sqlDataReader.GetInt32(4);
                        //list.Add(items);
                    }
                    con.Close();
                    return items;
                }
            }
        }
        public List<Items> GetItemsbyCategory(int categoryID)
        {

            List<Items> list = new List<Items>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Items WHERE CategoryID = @CategoryID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    con.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Items items = new Items();

                        items.ItemId = sqlDataReader.GetInt32(0);
                        items.ItemName = sqlDataReader.GetString(1);
                        items.Price = sqlDataReader["Price"] != null ? Convert.ToDecimal(sqlDataReader["Price"]) : 0;
                        //items.Quantity = sqlDataReader.GetInt32(3);
                        items.Stock = sqlDataReader.GetInt32(4);
                        list.Add(items);
                    }
                    con.Close();
                    return list;
                }
            }
        }
        public bool Addcategory(string categoryName, string description)
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Category (CategoryName, Description) VALUES (@CategoryName, @Description)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? DBNull.Value : (object)description);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public bool AddItemToCart(int userID, int itemID, int categoryID, int quantity, decimal price)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Cart (UserID, ItemID,CategoryID, Quantity, TotalPrice) VALUES (@UserID, @ItemID,@CategoryID, @Quantity, @TotalPrice)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@TotalPrice", price * quantity);

                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            return true;
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Items GetCartItem(int cartID, int userID)
        {
            try
            {
                Items items2 = new Items();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_GetCartItems", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Action", "GetCartItem");
                        cmd.Parameters.AddWithValue("@cartID", cartID);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                items2.CategoryName = reader["CategoryName"] != null ? reader["CategoryName"].ToString() : null;
                                items2.CartID = (int)reader["CartID"] != null ? (int)reader["CartID"] : 0;
                                items2.ItemName = reader["ItemName"] != null ? reader["ItemName"].ToString() : null;
                                items2.Quantity = (int)(reader["Quantity"] != null ? reader["Quantity"] : 0);
                                items2.Price = (decimal)(reader["Price"] != null ? reader["Price"] : 0);
                                items2.TotalPrice = (decimal)(reader["TotalPrice"] != null ? reader["TotalPrice"] : 0);
                                // items.Add(items2);
                            }

                        }
                    }
                }
                return items2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal CalculateSubtotal(int userID)
        {
            decimal subtotal = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT SUM(C.Quantity * I.Price) AS Subtotal
                         FROM Cart C
                         INNER JOIN Items I ON C.ItemID = I.ItemID
                         WHERE C.UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                            subtotal = Convert.ToDecimal(result);
                    }
                }
                return subtotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OrderItems(int userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {                

                    using (SqlCommand cmd = new SqlCommand("SP_PlaceOrder", con))
                    {
                        cmd.CommandType =CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        con.Open();
                      int rows= cmd.ExecuteNonQuery();
                        if (rows > 0)
                            return true;
                        else return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Items> GetCartItems(int userID)
        {
            try
            {
                List<Items> items = new List<Items>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_GetCartItems", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "GetCartAllItem");
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Items items2 = new Items();
                                items2.CategoryName = reader["CategoryName"] != null ? reader["CategoryName"].ToString() : null;
                                items2.CartID = (int)reader["CartID"] != null ? (int)reader["CartID"] : 0;
                                items2.ItemName = reader["ItemName"] != null ? reader["ItemName"].ToString() : null;
                                items2.Quantity = (int)(reader["Quantity"] != null ? reader["Quantity"] : 0);
                                items2.Price = (decimal)(reader["Price"] != null ? reader["Price"] : 0);
                                items2.TotalPrice = (decimal)(reader["TotalPrice"] != null ? reader["TotalPrice"] : 0);
                                items.Add(items2);
                            }

                        }
                    }
                    return items;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveCartItem(int cartID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Cart WHERE CartID = @CartID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        public bool UpdateCart(int cartID, int newQuantity, decimal price)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Cart SET Quantity = @Quantity, TotalPrice=@TotalPrice WHERE CartID = @CartID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TotalPrice", price * newQuantity);
                        cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@CartID", cartID);
                        con.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else return false;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Orders> GetOrderDetails(int userID)
        {
            try
            {
                List<Orders> orderDetails = new List<Orders>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_GetOrderDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                     
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderDetails.Add(new Orders()
                                {
                                    OrderID = reader.GetInt32(reader.GetOrdinal("OrderID")),
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                                    TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                                   TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                    ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    //ItemTotalPrice = reader.GetDecimal(reader.GetOrdinal("ItemTotalPrice")),
                                    ItemPrice = reader.GetDecimal(reader.GetOrdinal("ItemPrice"))
                                });
                            }

                        }
                    }
                    return orderDetails;
                }
            
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}