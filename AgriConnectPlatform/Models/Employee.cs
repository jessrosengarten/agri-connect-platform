using Microsoft.Data.SqlClient;
using System.Text;

namespace AgriConnectPlatform.Models
{
    /// <summary>
    /// Class to represent an Employee
    /// </summary>
    public class Employee
    {
        // Properties representing an Employee
        public int EmployeeID { get; set; }        
        public string EmployeeName { get; set; }    
        public string EmployeeEmail { get; set; }   
        public string EmployeePassword { get; set; } 
        public DateTime RegistrationDate { get; set; }


        // Constructor to initialize an Employee object
        public Employee(string employeeName, string employeeEmail, string employeePassword, DateTime registrationDate)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            EmployeePassword = employeePassword;
            RegistrationDate = registrationDate;
        }

        // Method to get an Employee by email from the database
        public static Employee GetEmployee(string employeeEmail)
        {
            Employee employee = null;
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True"; 

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlSelect = "SELECT * FROM Employees WHERE EmployeeEmail = @EmployeeEmail";
                SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@EmployeeEmail", employeeEmail);

                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee(
                            reader["EmployeeName"].ToString(),
                            reader["EmployeeEmail"].ToString(),
                            reader["EmployeePassword"].ToString(),
                            Convert.ToDateTime(reader["RegistrationDate"])
                        );
                        employee.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                    }
                }
            }
            return employee;
        }


        // Method to add a new Employee to the database
        public static void AddEmployee(string employeeName, string employeeEmail, string employeePassword)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AgriEnergyConnectDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlInsert = "INSERT INTO Employees (EmployeeName, EmployeeEmail, EmployeePassword, RegistrationDate) " +
                                   "VALUES (@EmployeeName, @EmployeeEmail, @EmployeePassword, @RegistrationDate)";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@EmployeeName", employeeName);
                cmdInsert.Parameters.AddWithValue("@EmployeeEmail", employeeEmail);
                cmdInsert.Parameters.AddWithValue("@EmployeePassword", employeePassword);
                cmdInsert.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                con.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }

        // Method to add a new Farmer profile
        public void AddFarmer(string farmerName, string farmerEmail, string farmerPassword)
        {
            Farmer.AddFarmer(farmerName, farmerEmail, farmerPassword);
        }
    }
}
