using Microsoft.Data.SqlClient;
using System.Data;

namespace AgriConnectPlatform.Models
{
    /// <summary>
    /// Class to represent a Product
    /// </summary>
    public class Product
    {
        // Properties representing a Product
        public int ProductID { get; set; }       
        public int FarmerID { get; set; } 
        public string ProductName { get; set; }   
        public string Description { get; set; }    
        public string Category { get; set; }       
        public DateTime AdditionDate { get; set; }

        // Constructor to initialize a Product object
        public Product(int farmerID, string productName, string description, string category, DateTime additionDate)
        {
            FarmerID = farmerID;
            ProductName = productName;
            Description = description;
            Category = category;
            AdditionDate = additionDate;
        }

        // Method to add a new Product to the database
        public static void AddProduct(int farmerID, string productName, string description, string category)
        {
            // Define the connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            // Create a connection and command objects
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlInsert = "INSERT INTO Products (FarmerID, ProductName, Description, Category, AdditionDate) " +
                                   "VALUES (@FarmerID, @ProductName, @Description, @Category, @AdditionDate)";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@FarmerID", farmerID);
                cmdInsert.Parameters.AddWithValue("@ProductName", productName);
                cmdInsert.Parameters.AddWithValue("@Description", description);
                cmdInsert.Parameters.AddWithValue("@Category", category);
                cmdInsert.Parameters.AddWithValue("@AdditionDate", DateTime.Now);

                con.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }

        // Method to get Products by FarmerID from the database
        public static DataTable GetProductsByFarmerID(int farmerID)
        {
            DataTable productsTable = new DataTable();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Products WHERE FarmerID = @FarmerID";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@FarmerID", farmerID);

                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect))
                {
                    adapter.Fill(productsTable);
                }
            }
            return productsTable;
        }


        // Method to view products associated with a farmer by their ID
        public static void ViewProducts(int farmerId)
        {
            DataTable productsTable = new DataTable();

            // Define the connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            // SQL query to fetch products associated with the given farmer ID
            string sqlSelect = "SELECT * FROM Products WHERE FarmerID = @FarmerID";

            // Create a connection and command objects
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmdSelect = new SqlCommand(sqlSelect, con))
            {
                // Add parameters to the command
                cmdSelect.Parameters.AddWithValue("@FarmerID", farmerId);

                try
                {
                    // Open connection
                    con.Open();

                    // Execute command and fill the DataTable with results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect))
                    {
                        adapter.Fill(productsTable);
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exception
                    Console.WriteLine("Error fetching products: " + ex.Message);
                    throw;
                }
            }
        }

        // Method to get all products from the database
        public static DataTable GetAllProducts()
        {
            DataTable productsTable = new DataTable();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Products";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);

                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect))
                {
                    adapter.Fill(productsTable);
                }
            }
            return productsTable;
        }

        // Method to filter products by category from the database
        public static DataTable FilterProductsByCategory(string category)
        {
            DataTable productsTable = new DataTable();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Products WHERE Category = @Category";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@Category", category);

                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect))
                {
                    adapter.Fill(productsTable);
                }
            }
            return productsTable;
        }

    }
}
