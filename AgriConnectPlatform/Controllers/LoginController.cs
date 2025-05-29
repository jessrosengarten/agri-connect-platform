using AgriConnectPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AgriConnectPlatform.Controllers
{
    public class LoginController : Controller
    {

        // Returns the login view
        public ActionResult Login()
        {
            return View();
        }


        // Verify the farmer or employee login details
        [HttpPost]
        public ActionResult VerifyLogin(IFormCollection collection) 
        {
            try 
            {
                // Extract the email and password from the form collection
                string email = collection["txtEmail"];
                string password = collection["txtPassword"];

                // Get the farmer and employee details by email
                Farmer farmer = Farmer.GetFarmer(email);
                Employee employee = Employee.GetEmployee(email);

                // Check if the user is a farmer and if the farmer's email and password are correct
                if (farmer != null && farmer.FarmerEmail.Equals(email) && farmer.FarmerPassword.Equals(password))
                {
                    // Set the current farmer ID and redirect to the FarmerHome action
                    Farmer.getFarmerID = farmer.FarmerID;
                    return RedirectToAction("FarmerHome", "Farmer", new { farmerId = farmer.FarmerID, farmerName = farmer.FarmerName, farmerEmail = farmer.FarmerEmail });
                }

                // Check if the user is an employee and if the employee's email and password are correct
                else if (employee != null && employee.EmployeeEmail.Equals(email) && employee.EmployeePassword.Equals(password))
                {

                    // Redirect to the Employee controller's home action
                    return RedirectToAction("EmployeeHome", "Employee", new { employeeName = employee.EmployeeName, employeeEmail = employee.EmployeeEmail });
                }

                // If credentials are not correct for a farmer or an employee, the below message will appear
                else
                {
                    ViewBag.errorMsg = "Invalid Login Details";
                    return View("Login");
                }

            }
            catch (Exception ex) 
            {
                // Handle any exceptions and display an error message
                ViewBag.errorMsg = ex.Message;
                return View("Login");
            }
        }

        // Returns the FarmerHome view
        public ActionResult FarmerHome()
        {
            return View();
        }


    }
}
