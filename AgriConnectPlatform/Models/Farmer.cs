using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgriConnectPlatform.Models

{
    /// <summary>
    /// Class to represent a Farmer
    /// </summary>
    public class Farmer
    {
        // Properties representing a Farmer
        public int FarmerID { get; set; }         
        public string FarmerName { get; set; }  
        public string FarmerEmail { get; set; } 
        public string FarmerPassword { get; set; } 
        public DateTime RegistrationDate { get; set; }

        public static int getFarmerID;


        // Constructor to initialize a Farmer object
        public Farmer(string farmerName, string farmerEmail, string farmerPassword, DateTime registrationDate)
        {
            FarmerName = farmerName;
            FarmerEmail = farmerEmail;
            FarmerPassword = farmerPassword;
            RegistrationDate = registrationDate;

        }

        // Method to get a Farmer by email from the database
        public static Farmer GetFarmer(string farmerEmail)
        {
            Farmer farmer = null; // Initialize the farmer object to null

            // Define the connection string 
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Farmers WHERE FarmerEmail = @FarmerEmail"; // Use parameterized query to avoid SQL injection
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@FarmerEmail", farmerEmail);

                con.Open(); // Open the connection
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create a new Farmer object with data from the database
                        farmer = new Farmer(
                            reader["FarmerName"].ToString(),
                            reader["FarmerEmail"].ToString(),
                            reader["FarmerPassword"].ToString(),
                            Convert.ToDateTime(reader["RegistrationDate"])
                        );
                        farmer.FarmerID = Convert.ToInt32(reader["FarmerID"]);
                    }
                }
            }
            return farmer; // Return the farmer object
        }

        // Method to get a Farmer by ID from the database
        public static Farmer GetFarmerById(int farmerId)
        {
            Farmer farmer = null;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Farmers WHERE FarmerID = @FarmerID";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@FarmerID", farmerId);

                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        farmer = new Farmer(
                            reader["FarmerName"].ToString(),
                            reader["FarmerEmail"].ToString(),
                            reader["FarmerPassword"].ToString(),
                            Convert.ToDateTime(reader["RegistrationDate"])
                        );
                        farmer.FarmerID = Convert.ToInt32(reader["FarmerID"]);
                    }
                }
            }
            return farmer;
        }

        // Method to add a new Farmer to the database
        public static void AddFarmer(string farmerName, string farmerEmail, string farmerPassword) 
        {
            // Define the connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                string sqlInsert = "INSERT INTO Farmers (FarmerName, FarmerEmail, FarmerPassword, RegistrationDate) " +
                                   "VALUES (@FarmerName, @FarmerEmail, @FarmerPassword, @RegistrationDate)";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@FarmerName", farmerName);
                cmdInsert.Parameters.AddWithValue("@FarmerEmail", farmerEmail);
                cmdInsert.Parameters.AddWithValue("@FarmerPassword", farmerPassword);
                cmdInsert.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                con.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }

        // Method to view products associated with a farmer by their ID
        public static DataTable ViewProducts(int farmerId)
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

            return productsTable;
        }

        // Method to filter farmers based on name
        public static List<Farmer> FilterFarmers(string name)
        {
            List<Farmer> farmers = new List<Farmer>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Farmers WHERE @FarmerName IS NULL OR FarmerName LIKE @FarmerName";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@FarmerName", string.IsNullOrEmpty(name) ? (object)DBNull.Value : "%" + name + "%");

                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Farmer farmer = new Farmer(
                            reader["FarmerName"].ToString(),
                            reader["FarmerEmail"].ToString(),
                            reader["FarmerPassword"].ToString(),
                            Convert.ToDateTime(reader["RegistrationDate"])
                        );
                        farmer.FarmerID = Convert.ToInt32(reader["FarmerID"]);
                        farmers.Add(farmer);
                    }
                }
            }

            return farmers;
        }
    }
}
